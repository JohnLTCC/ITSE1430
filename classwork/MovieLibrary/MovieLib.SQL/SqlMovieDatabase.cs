using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MovieLib.Sql
{
    public class SqlMovieDatabase : MovieDatabase
    {
        public SqlMovieDatabase (string connectionString)
        {
            _connectionString = connectionString;
        }
        private readonly string _connectionString;

        protected override Movie AddCore ( Movie movie )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("AddMovie", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Add parameters
                // Approach 1 - AddWithValue : Prefered with sql
                cmd.Parameters.AddWithValue("@name", movie.Title);
                cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@runLength", movie.Duration);
                cmd.Parameters.AddWithValue("@IsClassic", movie.IsClassic);

                // Approach 2 - Add : works as a backup if 1 doesn't work
                var paramRating = cmd.Parameters.Add("rating", SqlDbType.NVarChar);
                paramRating.Value = movie.Rating;

                // Approach 3 - Creating a parameter : need complete control over parameter
                var paramDescription = new SqlParameter("@description", movie.Description);
                cmd.Parameters.Add(paramDescription);

                // Approach 4 - Generic : when necessary
                var paramGenre = cmd.CreateParameter();
                paramGenre.ParameterName = "@genre";
                paramGenre.DbType = DbType.String;
                paramGenre.Value = movie.Genre;
                cmd.Parameters.Add(paramGenre);

                object result = cmd.ExecuteScalar();

                movie.Id = Convert.ToInt32(result);
            };

            return movie;
        }
        protected override void DeleteCore ( int id )
        {
            using (var connn = OpenConnection())
            {
                //Command - Approach 2
                var cmd = connn.CreateCommand();
                cmd.CommandText = "DeleteMovie";
                cmd.CommandType = CommandType.StoredProcedure;

                //Always use parameters to prevent SqlInjections
                // name: user input
                //Select * FROM Movies WHERE name = ' + name + '
                // name '; DELETE FROM Movies; + '
                // Select* FROM Movies WHERE name = ''; DELETE FROM Movies; + ''

                //Add parameter - approach 1
                cmd.Parameters.AddWithValue("@id", id);

                //Execute - no results
                cmd.ExecuteNonQuery();
            };
        }
        protected override Movie FindByName ( string name )
        {
            //Streamed read
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("FindByName", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", name);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return LoadMovie(reader);
                    };
                };
            };
            return null;
        }
        protected override IEnumerable<Movie> GetAllCore ()
        {
            DataSet ds = new DataSet();
            using (var conn = OpenConnection())
            {
                //Create command - approach 1
                var command = new SqlCommand("GetMovies", conn);

                //Buffered IO
                var da = new SqlDataAdapter(command);

                da.Fill(ds);
            };

            //Get the first table, have to use OfType<T> to get IEnumerable<T>
            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if(table != null)
            {
                return table.Rows.OfType<DataRow>().Select(LoadMovie);
            }
            return Enumerable.Empty<Movie>();
        }
        protected override Movie GetCore ( int id )
        {
            //Streamed read
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("GetMovie", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return LoadMovie(reader);
                    };
                };
            };
            return null;
        }
        protected override void UpdateCore ( int id, Movie movie )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("UpdateMovie", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Add parameters
                // Approach 1 - AddWithValue : Prefered with sql
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", movie.Title);
                cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@runLength", movie.Duration);
                cmd.Parameters.AddWithValue("@IsClassic", movie.IsClassic);

                // Approach 2 - Add : works as a backup if 1 doesn't work
                var paramRating = cmd.Parameters.Add("rating", SqlDbType.NVarChar);
                paramRating.Value = movie.Rating;

                // Approach 3 - Creating a parameter : need complete control over parameter
                var paramDescription = new SqlParameter("@description", movie.Description);
                cmd.Parameters.Add(paramDescription);

                // Approach 4 - Generic : when necessary
                var paramGenre = cmd.CreateParameter();
                paramGenre.ParameterName = "@genre";
                paramGenre.DbType = DbType.String;
                paramGenre.Value = movie.Genre;
                cmd.Parameters.Add(paramGenre);

                cmd.ExecuteNonQuery();
            };
        }
        #region Helper Methods
        private SqlConnection OpenConnection ()
        {
            //IDisposable
            var conn = new SqlConnection(_connectionString);
            conn.Open();

            return conn;
        }
        private static Movie LoadMovie ( SqlDataReader reader ) => new Movie() {
            Id          = Convert.ToInt32(reader[0]),                                //Array-based index and convert
            Title       = reader["Name"]?.ToString(),                                //Array-based name and convert
            Description = reader.IsDBNull(2) ? "" : reader.GetFieldValue<string>(2), //Field-based index
            Duration    = reader.GetFieldValue<int>("RunLength"),                    //Field-based name
            Rating      = reader.GetString(3),                                       //Type-based Ordinal
            ReleaseYear = reader.GetInt32("ReleaseYear"),                            //Type-based name
            Genre       = reader.GetFieldValue<string>("Genre"),
            IsClassic   = reader.GetFieldValue<bool>("IsClassic"),
        };
        private Movie LoadMovie ( DataRow row )
        {
            return new Movie() {
                Id          = Convert.ToInt32(row[0]),      //Array-based index and convert
                Title       = row["Name"].ToString(),       //Array-based name and convert
                Description = row.Field<string>(2),         //Field-based index
                Duration    = row.Field<int>("RunLength"),  //Field-based name
                Rating      = row.Field<string>("Rating"),
                ReleaseYear = row.Field<int>("ReleaseYear"),
                Genre       = row.Field<string>("Genre"),
                IsClassic   = row.Field<bool>("IsClassic"),
            };
        }
        #endregion
    }
}
