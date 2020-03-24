using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MovieLibrary.Business;

namespace MovieLibrary.WinForms
{
    public partial class MovieForm : Form
    {
        public MovieForm ()
        {
            InitializeComponent();
        }

        // call the more specific constructor first - constructor chaining
        public MovieForm ( Movie movie ) : this(movie != null ? "Edit" : "Add", movie)
        {
            /*InitializeComponent ();
            Movie = movie;
            Text = movie != null ? "Edit" : "Add";*/
        }

        public MovieForm ( string title, Movie movie ) : this()
        {
            Text = title;
            Movie = movie;
        }

       /* private void Initialize ( string title, Movie movie )
        {
            InitializeComponent();
            Text = title;
            Movie = movie;
        }*/

        public Movie Movie { get; set; }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            //populate combo
            var genres = Genres.GetALL();
            ddlGenres.Items.AddRange(genres);

            if (Movie != null)
            {
                txtTitle.Text = Movie.Title;
                txtDescription.Text = Movie.Description;
                txtReleaseYear.Text = Movie.ReleaseYear.ToString();
                txtRunLength.Text = Movie.RunLength.ToString();
                chkIsClassic.Checked = Movie.IsClassic;

                if (Movie.Genre != null)
                    ddlGenres.SelectedText = Movie.Genre.Description;

                ValidateChildren();
            };
        }

        private void OnCancel ( object sender, EventArgs e )
        {
            //TODO: Validation and error reporting

            DialogResult = DialogResult.Cancel;
            Close(); // -> dismisses the form
        }

        private void OnOk ( object sender, EventArgs e )
        {
            if (!ValidateChildren()) // if something return false during validation, it shows error.
                return;

            // Validation and error reporting
            var movie = GetMovie();

            var errors = new ObjectValidator().Validate(movie);
            if(errors.Any())
            //if (!movie.Validate(out var error))
            {
                DisplayError("error");
                return;
            }

            Movie = movie;
            DialogResult = DialogResult.OK;
            Close(); // -> dismisses the form
        }

        private void DisplayError ( string message )
        {
            //var that = this;
            //var Text = "";
            //var newTitle = this.Text;
            //var newTitle = Text;

            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private Movie GetMovie ()
        {
            var movie = new Movie();

            //Null conditional
            movie.Title = txtTitle.Text?.Trim();
            movie.RunLength = GetAsInt32(txtRunLength);
            movie.ReleaseYear = GetAsInt32(txtReleaseYear, 1900);
            movie.Description = txtDescription.Text.Trim();
            movie.IsClassic = chkIsClassic.Checked;

            //movie.Genre = (Genre)ddlGenres.SelectedItem; //  c style cast - program will crash if wrong

            //movie.Genre = ddlGenres.SelectedItem as Genre; // Preferred - will return back null but not crash

            /* as operator
            if (ddlGenres.SelectedItem is Genre)
                genre = (Genre)ddlGenres.SelectedItem;*/

            //Pattern match
            if (ddlGenres.SelectedItem is Genre genre)
                movie.Genre = genre;

            return movie;
        }

        private int GetAsInt32 (Control control)
        {
            return GetAsInt32(control, 0);
        }
        private int GetAsInt32 (Control control, int emptyValue)
        {
            // check for empty string
            if (String.IsNullOrEmpty(control.Text))
                return emptyValue;

            //convert string into int
            if (Int32.TryParse(control.Text, out var result))
                return result;
            //return errror
            return -1;
        }

        private void OnValidateTitle ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;
            if (String.IsNullOrEmpty(control.Text))
            {
                //DisplayError("Title is required");
                _errors.SetError(control, "Title is required");
                e.Cancel = true;
            } else // will get rid of the error circle next to the box after inserting data
            {
                _errors.SetError(control, "");
            }
        }

        private void OnValidateRunLength ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            var value = GetAsInt32(control, 0);
            if (value < 0)
            {
                //DisplayError("Run length must be >= 0.");
                _errors.SetError(control, "Run length must be >= 0.");
                e.Cancel = true;
            } else // will get rid of the error circle next to the box after inserting data
            {
                _errors.SetError(control, "");
            }
        }

        private void OnValidateReleaseYear ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            var value = GetAsInt32(control, 1900);
            if (value < 1900)
            {
                //DisplayError("Release year must be >= 1900.");
                _errors.SetError(control, "Release year must be >= 1900.");
                e.Cancel = true;
            } else // will get rid of the error circle next to the box after inserting data
            {
                _errors.SetError(control, "");
            }
        }
    }
}
