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

            if (Movie != null)
            {
                txtTitle.Text = Movie.Title;
                txtDescription.Text = Movie.Description;
                txtReleaseYear.Text = Movie.ReleaseYear.ToString();
                txtRunLength.Text = Movie.RunLength.ToString();
                chkIsClassic.Checked = Movie.IsClassic;
            }
        }

        private void OnCancel ( object sender, EventArgs e )
        {
            //TODO: Validation and error reporting

            DialogResult = DialogResult.Cancel;
            Close(); // -> dismisses the form
        }

        private void OnOk ( object sender, EventArgs e )
        {
            // Validation and error reporting
            var movie = GetMovie();
            if (!movie.Validate(out var error))
            {
                DisplayError(error);
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

    }
}
