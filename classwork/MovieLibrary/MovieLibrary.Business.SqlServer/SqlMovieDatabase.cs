using System;
using System.Collections.Generic;
using System.Data;
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
                //Creating a command
                var cmd = new SqlCommand("AddMovie", conn);
                //var cmd2 = conn.CreateCommand();
                //cmd.CommandText = "AddMovie";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Add parameters
                //1. Long way
                var pName = new SqlParameter("@name", movie.Title);
                cmd.Parameters.Add(pName);

                //2. Shorter way
                var pGenre = cmd.Parameters.Add("@genre", System.Data.SqlDbType.NVarChar);
                if (movie.Genre != null)
                    pGenre.Value = movie.Genre.Description;

                //3. Short short version
                cmd.Parameters.AddWithValue("@description", movie.Description);
                cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@runLength", movie.RunLength);
                cmd.Parameters.AddWithValue("@isClassic", movie.IsClassic);

                //Executes the command and returns back the first value of the first row, if any
                var result = cmd.ExecuteScalar();

                var id = Convert.ToInt32(result);
                movie.Id = id;

                return movie;
            };
        }
        protected override void DeleteCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DeleteMovie";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                //Ignore return value
                cmd.ExecuteNonQuery();
            };
        }
        protected override Movie GetCore ( int id ) => FindById(id);

        protected override IEnumerable<Movie> GetAllCore ()
        {
            var items = new List<Movie>();

            var ds = new DataSet();

            using (var conn = OpenConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "GetMovies";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Buffered approach - Dataset                

                //Intermediary
                var da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                //Populate data
                da.Fill(ds);
            };

            //Read data - enumerate the tables, enumerate rows
            //foreach (DataTable table in ds.Tables) 
            //{ 
            //    foreach (DataRow row in table.Rows) { };
            //};
            var table = ds.Tables.OfType<DataTable>().FirstOrDefault(); //IEnumerable -> IEnumerable<T>
            if (table != null)
            {
                //Reading data using Dataset
                foreach (var row in table.Rows.OfType<DataRow>())
                {
                    var movie = new Movie() {
                        Id = Convert.ToInt32(row[0]),        //Row object with ordinal
                        Title = row["Name"]?.ToString(),     //Row object with column name
                        Description = row.Field<string>(2),  //Field method with type and ordinal
                        //Genre = row.Field<string>("Genre"), 
                        ReleaseYear = row.Field<int>("ReleaseYear"),  //Field method with type and column name
                        RunLength = row.Field<int>("RunLength"),
                        IsClassic = row.Field<bool>("IsClassic")
                    };

                    //Handle DBNull.Value
                    var genre = !row.IsNull("Genre") ? row.Field<string>("Genre") : null;
                    if (!String.IsNullOrEmpty(genre))
                        movie.Genre = new Genre(genre);

                    items.Add(movie);
                };
            };

            return items;
        }

        private SqlConnection OpenConnection ()
        {
            //DbConnection
            var conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn;
        }

        protected override void UpdateCore ( int id, Movie movie )
        {
            using (var conn = OpenConnection())
            {
                //Creating a command
                var cmd = new SqlCommand("UpdateMovie", conn);
                //var cmd2 = conn.CreateCommand();
                //cmd.CommandText = "AddMovie";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                //Add parameters
                //1. Long way
                var pName = new SqlParameter("@name", movie.Title);
                cmd.Parameters.Add(pName);

                //2. Shorter way
                var pGenre = cmd.Parameters.Add("@genre", System.Data.SqlDbType.NVarChar);
                if (movie.Genre != null)
                    pGenre.Value = movie.Genre.Description;

                //3. Short short version
                cmd.Parameters.AddWithValue("@description", movie.Description);
                cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@runLength", movie.RunLength);
                cmd.Parameters.AddWithValue("@isClassic", movie.IsClassic);

                //Executes the command
                cmd.ExecuteNonQuery();
            };
        }
        protected override Movie FindByTitle ( string title )
        {
            var items = GetAllCore();

            return items.FirstOrDefault(m => String.Compare(m.Title, title, true) == 0);
        }

        protected override Movie FindById ( int id )
        {
            //TODO: Inefficient
            var items = GetAllCore();

            return items.FirstOrDefault(i => i.Id == id);
        }

        private readonly string _connectionString;
    }
}
