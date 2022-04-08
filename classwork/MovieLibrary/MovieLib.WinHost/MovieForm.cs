using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieLib.WinHost
{
    public partial class MovieForm : Form
    {
        public MovieForm ()
        {
            InitializeComponent();
        }

        public Movie Movie { get; set; }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            if (Movie != null)
            {
                _txtTitle.Text = Movie.Title;
                _txtReleaseYear.Text = Movie.ReleaseYear.ToString();
                _txtDuration.Text = Movie.Duration.ToString();
                _chkIsClassic.Checked = Movie.IsClassic;
                _ddlRating.Text = Movie.Rating;
                _txtGenre.Text = Movie.Genre;
                _txtDescription.Text = Movie.Description;
            }
        }
        private void OnSave ( object sender, EventArgs e )
        {
            if (!ValidateChildren())
                return;
            // Create a new movie
            var movie = new Movie();

            // Set properties from UI
            movie.Title = _txtTitle.Text;
            movie.ReleaseYear = ReadAsInt32(_txtReleaseYear, -1);
            movie.Duration = ReadAsInt32(_txtDuration, -1);
            movie.IsClassic = _chkIsClassic.Checked;
            movie.Rating = _ddlRating.Text;
            movie.Genre = _txtGenre.Text;
            movie.Description = _txtDescription.Text;

            // Validate
            if (!ObjectValidator.TryValidateObject(movie, out var errors))
            {
                Movie = movie;
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            MessageBox.Show(this, "Movie is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void OnCancel ( object sender, EventArgs e )
        {
            /// Confirms cancel
            if (MessageBox.Show(this, "Are you sure you want to exit?\nThis will leave any changes unsaved.", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void OnValidateTitle ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Title is required");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }
        private void OnValidateReleaseYear ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            var value = ReadAsInt32(control, -1);
            if (value < Movie.MinimumReleaseYear)
            {
                _errors.SetError(control, $"Release year must be at least {Movie.MinimumReleaseYear}");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }
        private void OnValidateDuration ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            var value = ReadAsInt32(control, -1);
            if (value < 0)
            {
                _errors.SetError(control, "Duration must be at least 0 minute");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }
        private void OnValidateGenre ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Genre is required");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private int ReadAsInt32 ( Control control, int defaultValue )
        {
            if (Int32.TryParse(control.Text, out var result))
                return result;

            return defaultValue;
        }
    }
}
