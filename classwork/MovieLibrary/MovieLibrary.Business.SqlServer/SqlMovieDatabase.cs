using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Business.SqlServer
{
    public class SqlMovieDatabase : MovieDatabase
    {
        public SqlMovieDatabase ( string connectionString )
        {
            _connectionString = connectionString;
        }
        protected override Movie AddCore ( Movie movie )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("AddMovie", conn);
                /*var cmd2 = conn.CreateCommand();
                cmd.CommandText = "AddMovie";*/
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Add parameters 
                //1. Long way 
                var pName = new SqlParameter("@name", movie.Title);
                cmd.Parameters.Add(pName);

                //2. Shorter way
                var pGenre = cmd.Parameters.Add("@rating", System.Data.SqlDbType.NVarChar);
                if (movie.Genre != null)
                    pGenre.Value = movie.Genre.Description;

                //3. Short short version
                cmd.Parameters.AddWithValue("@description", movie.Description);
                cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@runLength", movie.RunLength);
                cmd.Parameters.AddWithValue("@hasSeen", movie.IsClassic);

                //Executes the command and returns the first value of the first row, if any
                var result = cmd.ExecuteScalar();

                var id = Convert.ToInt32(result);
                movie.Id = id;

                //TODO: Temp
                _movies.Add(movie);

                return movie;
            };
        }
        protected override void DeleteCore ( int id ) => throw new NotImplementedException();
        protected override Movie GetCore ( int id )
        {
            return _movies.FirstOrDefault(m => m.Id == id);
        }

        protected override IEnumerable<Movie> GetAllCore ()
        {
            using (var conn = OpenConnection())
            {
                //TODO: Logic
            };

            return _movies;
        }

        private SqlConnection OpenConnection ()
        {
            //DbConnection
            var conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn;
        }

        protected override void UpdateCore ( int id, Movie movie ) => throw new NotImplementedException();
        protected override Movie FindByTitle ( string title ) => _movies.FirstOrDefault(m => String.Compare(m.Title, title, true) == 0);
        protected override Movie FindById ( int id ) => _movies.FirstOrDefault(m => m.Id == id);

        private List<Movie> _movies = new List<Movie>() {
            new Movie() { Id = 1, Title = "Jaws", RunLength = 200, ReleaseYear = 1977 },
            new Movie() { Id = 2, Title = "Jaws 2", RunLength = 210, ReleaseYear = 1979 },
        };
        private readonly string _connectionString;
    }
}
