using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator;

namespace MovieLibrary.Business.SqlServer
{
    public class SqlCharacterDatabase : CharacterDatabase
    {
        public SqlCharacterDatabase ( string connectionString )
        {
            _connectionString = connectionString;
        }
        protected override Character AddCore ( Character character )
        {
            using (var conn = OpenConnection())
            {
                //Creating a command
                var cmd = new SqlCommand("AddCharacter", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Add parameters
                //1. Long way
                var pName = new SqlParameter("@name", character.Name);
                cmd.Parameters.Add(pName);

                //2. Shorter way
                var pGenre = cmd.Parameters.Add("@genre", System.Data.SqlDbType.NVarChar);
                if (character.Genre != null)
                    pGenre.Value = character.Genre.Description;

                //3. Short short version
                cmd.Parameters.AddWithValue("@description", movie.Description);
                cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@runLength", movie.RunLength);
                cmd.Parameters.AddWithValue("@isClassic", movie.IsClassic);

                //Executes the command and returns back the first value of the first row, if any
                var result = cmd.ExecuteScalar();

                var id = Convert.ToInt32(result);
                character.Id = id;

                return character;
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
        protected override Character GetCore ( int id ) => FindById(id);

        protected override IEnumerable<Character> GetAllCore ()
        {
            var items = new List<Character>();

            var ds = new DataSet();

            using (var conn = OpenConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "GetCharacters";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;               

                //Intermediary
                var da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                //Populate data
                da.Fill(ds);
            };

            var table = ds.Tables.OfType<DataTable>().FirstOrDefault(); //IEnumerable -> IEnumerable<T>
            if (table != null)
            {
                //Reading data using Dataset
                foreach (var row in table.Rows.OfType<DataRow>())
                {
                    var movie = new Character() {
                        Id = Convert.ToInt32(row[0]),        //Row object with ordinal
                        Name = row["Name"]?.ToString(),     //Row object with column name
                        Description = row.Field<string>(2),  //Field method with type and ordinal
                        //Genre = row.Field<string>("Genre")
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

        protected override void UpdateCore ( int id, Character character )
        {
            using (var conn = OpenConnection())
            {
                //Creating a command
                var cmd = new SqlCommand("UpdateCharacter", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                //Add parameters
                //1. Long way
                var pName = new SqlParameter("@name", character.Name);
                cmd.Parameters.Add(pName);

                //2. Shorter way
                var pGenre = cmd.Parameters.Add("@genre", System.Data.SqlDbType.NVarChar);
                if (character.Genre != null)
                    pGenre.Value = character.Genre.Description;

                //3. Short short version
                cmd.Parameters.AddWithValue("@description", movie.Description);
                cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@runLength", movie.RunLength);
                cmd.Parameters.AddWithValue("@isClassic", movie.IsClassic);

                //Executes the command
                cmd.ExecuteNonQuery();
            };
        }
        protected override Character FindByName ( string name )
        {
            //Streamed approach
            using (var conn = OpenConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "FindByName";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", name);

                //Error - clean up reader
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var movie = new Character() {
                            Id = Convert.ToInt32(reader[0]),     //Dictionary with zero-based ordinal
                            Name = reader["Name"]?.ToString(),  //Dictionary with column name

                            Description = reader.GetString(2),   //GetType(ordinal)
                        };

                        //Handle DBNull.Value
                        var ordinal = reader.GetOrdinal("Genre");
                        var genre = !reader.IsDBNull(ordinal) ? reader.GetFieldValue<string>(ordinal) : null;
                        if (!String.IsNullOrEmpty(genre))
                            movie.Genre = new Genre(genre);

                        return movie;
                    };
                };
            };
            return null;
        }

        protected override Character FindById ( int id )
        {
            //Streamed approach
            using (var conn = OpenConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "GetCharacter";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                //Error - Clean up reader
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var character = new Character() {
                            Id = Convert.ToInt32(reader[0]),     //Dictionary with zero-based ordinal
                            Name = reader["Name"]?.ToString(),  //Dictionary column name

                            Description = reader.GetString(2),   //GetType(ordinal)
                        };

                        //Handle DBNull.Value
                        var ordinal = reader.GetOrdinal("Genre");
                        var genre = !reader.IsDBNull(ordinal) ? reader.GetFieldValue<string>(ordinal) : null;
                        if (!String.IsNullOrEmpty(genre))
                            character.Genre = new Genre(genre);

                        return character;
                    };
                };
            };
            return null;
        }

        private readonly string _connectionString;
    }
}
