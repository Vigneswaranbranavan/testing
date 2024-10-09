using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class MovieManager
    {
        public readonly string connectionString = "Server=(localdb)\\MSSQLLocalDB;database=Movies_Management;Integrated Security= true";


        public void createTable()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"

                  IF NOT EXISTS(SELECT * From sys.tables where name = 'Movies')
                    BEGIN
                        CREATE TABLE Movies(
                            Id INT IDENTITY(1,1) PRIMARY KEY,
                            Title NVARCHAR(20),
                            Director NVARCHAR(20),
                            RentalPrice DECIMAL
                        );
                        END

                    ";
                command.ExecuteNonQuery();
            }
            
        }
        public string AddMovie(Movie movies)
        {
            using(var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = @"INSERT INTO Movies(Title,Director,RentalPrice) VALUES(@Title,@Director,@RentalPrice);";
                command.Parameters.AddWithValue("@Title", movies.Title);
                command.Parameters.AddWithValue("@Director", movies.Director);
                command.Parameters.AddWithValue("@RentalPrice", movies.RentalPrice);

                command.ExecuteNonQuery();
            }
            return "Movie Added Successfully";
        }
    }
}
