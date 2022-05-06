using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Nile.Stores.Sql
{
    public class SqlProductDatabase : ProductDatabase
    {
        public SqlProductDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }
        private readonly string _connectionString;
        protected override Product AddCore ( Product product )
        {
            //Open Connection
            using(var conn = OpenConnection())
            {
                //Create Command
                var cmd = new SqlCommand("AddProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@isDiscontinued", product.IsDiscontinued);

                object result = cmd.ExecuteScalar();

                product.Id = Convert.ToInt32(result);
            }

            return product;
        }
        protected override IEnumerable<Product> GetAllCore ()
        {
            DataSet ds = new DataSet();
            using(var conn = OpenConnection())
            {
                var cmd = new SqlCommand("GetAllProducts", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                var da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            };

            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if(table != null)
            {
                return table.Rows.OfType<DataRow>().Select(LoadProduct);
            }
            return Enumerable.Empty<Product>();
        }
        protected override Product GetCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("GetProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return LoadProduct(reader);
                    };
                };
            };
            return null;
        }
        protected override void RemoveCore ( int id )
        {
            using(var conn = OpenConnection())
            {
                var cmd = new SqlCommand("RemoveProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }
        protected override Product UpdateCore ( Product existing, Product newItem )
        {
            using (var conn = OpenConnection())
            {
                //Create Command
                var cmd = new SqlCommand("UpdateProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", existing.Id);
                cmd.Parameters.AddWithValue("@name", newItem.Name);
                cmd.Parameters.AddWithValue("@price", newItem.Price);
                cmd.Parameters.AddWithValue("@description", newItem.Description);
                cmd.Parameters.AddWithValue("@isDiscontinued", newItem.IsDiscontinued);

                cmd.ExecuteNonQuery();
            }

            return newItem;
        }

        #region Helper Methods
        private SqlConnection OpenConnection ()
        {
            //IDisposable
            var conn = new SqlConnection(_connectionString);
            conn.Open();

            return conn;
        }
        private Product LoadProduct( SqlDataReader reader)
        {
            return new Product() {
                Id              = reader.GetFieldValue<int>("id"),
                Name            = reader.GetFieldValue<string>("name"),
                Price           = reader.GetFieldValue<decimal>("price"),
                Description     = reader.GetFieldValue<string>("description"),
                IsDiscontinued  = reader.GetFieldValue<bool>("isDiscontinued"),
            };
        }
        private Product LoadProduct ( DataRow row )
        {
            return new Product() {
                Id              = row.Field<int>("id"),
                Name            = row.Field<string>("name"),
                Price           = row.Field<decimal>("price"),
                Description     = row.Field<string>("description"),
                IsDiscontinued  = row.Field<bool>("isDiscontinued"),
            };
        }
        #endregion
    }
}
