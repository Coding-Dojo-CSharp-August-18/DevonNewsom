using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using DapperLecture.Models;
using MySql.Data.MySqlClient;

namespace DapperLecture.Factories
{
    public class FriendFactory
    {
        static string server = "localhost";
        static string db = "mydb";
        static string port = "3306";
        static string user = "root";
        static string pass = "root";
        private IDbConnection connection
        {
            get 
            {
                return new MySqlConnection($"Server={server};Port={port};Database={db};UserID={user};Password={pass};SslMode=None");
            }
        }

        public IEnumerable<Friend> GetAll()
        {
            using(IDbConnection dbConnection = connection)
            {
                return dbConnection.Query<Friend>("SELECT * FROM friends");
            }
        }

        public bool NameExists(string name)
        {
            using(IDbConnection dbConnection = connection)
            {
                // define SQL string, using @ for parameters
                string sql = "SELECT * FROM friends WHERE Name = @NAME";
                
                // create parameter object for Dapper
                object param = new { NAME = name };

                // call .Query<Friend>, mapping the result to a collection (IEnumerable)
                    // of Friend objects, passing the SQL string as well as the parameter
                IEnumerable<Friend> result = dbConnection.Query<Friend>(sql, param);

                // use the .Count() method on IEnumerable to provide condition for our
                    // method's return
                return result.Count() > 0;
            }
        }

        // Get One
        public Friend GetFriendById(int id)
        {
            using(IDbConnection dbConnection = connection)
            {
                string sql = "SELECT * FROM friends WHERE FriendId = @ID";
                object param = new { ID = id };
                IEnumerable<Friend> result = dbConnection.Query<Friend>(sql, param);
                return result.First();
            }
        }

        // Create
        public void Create(Friend friend)
        {
            using(IDbConnection dbConnection = connection)
            {
               string insert =
               $@"
                    INSERT INTO friends (Name, Location, DOB, CreatedAt)
                    VALUES (@Name, @Location, @DOB, NOW())
               ";
               dbConnection.Execute(insert, friend);
            }
        }

        
    }
}