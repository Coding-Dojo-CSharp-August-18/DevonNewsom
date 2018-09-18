using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using DojoLeague.Models;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace DojoLeague.Factories
{
    public class DojoFactory
    {
        private string connectionString;
        public DojoFactory(IOptions<MySqlOptions> config)
        {
            connectionString = config.Value.ConnectionString;
        }
        public IDbConnection Connection { get { return new MySqlConnection(connectionString); } } 

        public List<Dojo> AllDojos()
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Dojo>("SELECT * FROM dojos").ToList();
            }
        }
        public void AddDojo(Dojo dojo)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string query = "INSERT INTO dojos (name, location, description) VALUES (@name, @location, @description)";
                dbConnection.Execute(query, dojo);
            }
        }
        public Dojo GetDojoById(int id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string multiQuery = 
                @"
                    SELECT * FROM dojos WHERE dojo_id = @ID;
                    SELECT * FROM ninjas WHERE dojo_id = @ID
                ";
                using(SqlMapper.GridReader multi = dbConnection.QueryMultiple(multiQuery, new {ID = id}))
                {
                    Dojo dojo = multi.Read<Dojo>().SingleOrDefault();
                    dojo.Members = multi.Read<Ninja>().ToList();
                    return dojo;
                }
            }
        }
    }
}