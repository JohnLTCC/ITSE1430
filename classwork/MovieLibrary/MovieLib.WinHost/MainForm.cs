using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using MovieLib.Memory;

namespace MovieLib.WinHost
{
    public partial class MainForm : Form
    {
        // B is the correct answer
        public MainForm ()
        {
            InitializeComponent();
        }

        //Extension methods
        // Extend a type with a new method
        // Works with any type
        //

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            // If database is empty
            IEnumerable<Movie> items = _movies.GetAll();
            if(!items.Any())
            {
                if(MessageBox.Show(this, "Do you want to seed the database?", "Seed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Seeds the database
                    _movies.Seed();
                    UpdateUI();
                }
            }
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var form = new AboutBox();
            form.ShowDialog(this);
        }

        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var dlg = new MovieForm();
            do
            {
                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;

                // Saves the movie
                var error = _movies.Add(dlg.Movie);
                if (String.IsNullOrEmpty(error))
                {
                    UpdateUI();
                    return;
                };

                MessageBox.Show(this, error, "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (true);
        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            var dlg = new MovieForm();
            dlg.Movie = movie;

            do
            {
                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;

                //TODO: Update movie
                var error = _movies.Update(movie.Id, dlg.Movie);
                if (String.IsNullOrEmpty(error))
                {
                    UpdateUI();
                    return;
                }

                MessageBox.Show(this, error, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (true);
        }

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            if (MessageBox.Show(this, $"Are you sure you want to delete {movie.Title}?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            _movies.Delete(movie.Id);
            UpdateUI();
        }

        private Movie GetSelectedMovie ()
        {
            return _lstMovies.SelectedItem as Movie;
        }

        private void UpdateUI ()
        {
            _lstMovies.Items.Clear();



            //Approach 1
            //foreach (var movie in movies)
            //    _lstMovies.Items.Add(movie);

            //Approach 2
            //var movies = _movies.GetAll()
            //                    .OrderBy(x => x.Title)
            //                    .ThenBy(x => x.ReleaseYear);
            
            //Approach 3
            var movies = from m in _movies.GetAll()
                         orderby m.Title, m.ReleaseYear
                         select m;

            _lstMovies.Items.AddRange(movies.ToArray());

        }

        //private void BreakMovies ( IEnumerable<Movie> movies )
        //{
        //    if (movies.Any())
        //    {
        //        var firstMovie = movies[0];
        //
        //        firstMovie.Title = "Star Wars";
        //    }
        //}

        protected override void OnFormClosing ( FormClosingEventArgs e )
        {
            // Asks if the user wants to quit in a message box
            if (MessageBox.Show(this, "Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                e.Cancel = true;
        }

        private readonly IMovieDatabase _movies = new MemoryMovieDatabase();
    }
}
