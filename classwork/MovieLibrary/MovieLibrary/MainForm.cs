// Jose Gonzalez

using System;
using System.Linq; // Language Intergrated Natural Query

using System.Windows.Forms;
using MovieLibrary.Business;
using MovieLibrary.Business.Memory;
using MovieLibrary.WinForms;

namespace MovieLibrary
{
    public partial class MainForm : Form
    {

        //private Movie _movie;
        private readonly IMovieDatabase _movies;

        public MainForm ()
        {
            InitializeComponent();

            _movies = new MemoryMovieDatabase();
        }

        private bool DisplayConfirmation (string message, string title)
        {
            var result = MessageBox.Show(message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            return result == DialogResult.OK;
        }
        /// <summary> Displays an error message</summary>
        /// <param name="message">Error to display</param>
        private void DisplayError ( string message )
        {
            //var that = this;

            //var Text = "";
            //var newTitle = this.Text;
            //var newTitle = Text;

            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void DisplayMovie ( Movie movie )
        {
            if (movie == null)
                return;
            var title = movie.Title;
            movie.Description = "Test";

            movie = new Movie();
        }

        private void OnMovieAdd ( object sender, EventArgs e )
        {
            MovieForm child = new MovieForm();

            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                //TODO: Save the movie
                var movie = _movies.Add(child.Movie);
                if (movie != null)
                {
                    UpdateUI();
                    return;
                }
                DisplayError("Add failed");
            } while (true);
        }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            // SeedDatabase.SeedIfEmpty(_movies); // compile to this

            //Call extension method as though it is an instance
            //Discover it            
            _movies.SeedIfEmpty();

            UpdateUI();
        }

        // new
        private string SortByTitle ( Movie movie ) => movie.Title;
        private int SortByReleaseYear ( Movie movie ) => movie.ReleaseYear;
        private void UpdateUI ()
        {
            lstMovies.Items.Clear(); // remove all items from lstBox

            var movies = _movies.GetAll()
                                .OrderBy(SortByTitle) // IEnumerable<T> OrderBy<T> (this IEnumerable<T>, source, Func<T>, string> sorter)
                                .ThenByDescending(SortByReleaseYear);

            // T[] ToArray (this IEnumerable<T> source) = returns source as an array
            // List<T> ToList (this IEnumerable<T> source) = returns source as a List<T>
            lstMovies.Items.AddRange(movies.ToArray()); // Enumerable.ToArray(movies)
            //foreach (var movie in movies)
            //{
            //       lstMovies.Items.Add(movie);
            // };
        }

        private Movie GetSelectedMovie ()
        {
            // Preferred
            //return lstMovies.SelectedItem as Movie;

            //
            // IEnumerable<T> returning LINQ methods are deferred execution
            //

            // SelectedObjectCollection : IEnumerable
            // IEnumerable<T> Cast<T> (this IEnumerable soruce)
            // IEnumerbale<T> OfTytpe<T> (this IEnumerable soruce)
            var selectedItems = lstMovies.SelectedItems.OfType<Movie>();

            // T? FirstOrDefault (this IEnumerable<T>) :: return first item that meets criteria or default for type if none
            // T? LastOrDefault (this IEnumerable<T>) :: Returns last item that meets criteria or default for type if none; not always supported

            // T First ( this IEnumerable<T> ) :: Returns first item that meets criteria or default for type if none
            // T Last ( this IEnumerable<T> ) :: Returns first item that meets criteria or blows up

            // T? SingleOrDefault ( this IEnumerable<T> ) :: Returns the only item that meets criteria or default for type if none, blows up if more than one meets criteria
            // T Single ( this IEnumerable<T> ) :: Returns the only item that meets criteria or blows up
            return selectedItems.FirstOrDefault();
            
        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            // Verify movie
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            var child = new MovieForm();
            child.Movie = movie;

            do {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                //TODO: Save the movie
                var error = _movies.Update(movie.Id, child.Movie);
                if (String.IsNullOrEmpty(error))
                {
                    UpdateUI();
                    return;
                }
                DisplayError(error);
            } while (true);


            //child.Show();
        }

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();

            // Verify movie
            if (movie == null)
                return;

            if (!DisplayConfirmation($"Are you sure you want to delete {movie.Title}?", "Delete"))
                return;

            //TODO: Delete
            _movies.Delete(movie.Id);
            UpdateUI();
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutBox();

            about.ShowDialog(this);
        }
    }
}
