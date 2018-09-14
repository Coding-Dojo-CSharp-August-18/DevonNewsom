using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using DojoLeague.Models;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace DojoLeague.Factories
{
    public class NinjaFactory
    {
        private string connectionString;
        public NinjaFactory(IOptions<MySqlOptions> config)
        {
            connectionString = config.Value.ConnectionString;
        }
        public IDbConnection Connection { get { return new MySqlConnection(connectionString); } } 
        public List<Ninja> AllNinjas()
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string SQL = 
                @"
                    SELECT * FROM ninjas LEFT JOIN dojos ON ninjas.dojo_id = dojos.dojo_id;
                ";
                return dbConnection.Query<Ninja, Dojo, Ninja>(SQL, 
                (joinedNinja, joinedDojo) => 
                {
                    joinedNinja.Dojo = joinedDojo;
                    return joinedNinja;
                }, splitOn:"dojo_id").ToList();
            }
        }
        public Ninja GetNinjaById(int id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string SQL = 
                @"
                    SELECT * FROM ninjas LEFT JOIN dojos ON ninjas.dojo_id = dojos.dojo_id
                    WHERE ninja_id = @ID;
                ";
                object param = new{ID=id};
                var ninja = dbConnection.Query<Ninja, Dojo, Ninja>(SQL, 
                (joinedNinja, joinedDojo) => 
                {
                    joinedNinja.Dojo = joinedDojo;
                    return joinedNinja;
                }, param, splitOn:"dojo_id").FirstOrDefault();
                return ninja;
            }
        }
        public void AddNinja(Ninja ninja)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string query = "INSERT INTO ninjas (name, level, description, dojo_id) VALUES (@name, @level, @description, @dojo_id)";
                dbConnection.Execute(query, ninja);
            }
        }
        public List<Ninja> RogueNinjas()
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>("SELECT * FROM ninjas WHERE dojo_id IS NULL").ToList();
            }
        }
        public void BanishNinja(int id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute(
                    "UPDATE ninjas SET dojo_id = NULL WHERE ninja_id = @ID", 
                    new {ID=id});
            }
        }
        public void RecruitNinja(int ninja_id, int dojo_id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute(
                    "UPDATE ninjas SET dojo_id = @DojoID WHERE ninja_id = @ID", 
                    new {ID=ninja_id, DojoID = dojo_id});
            }
        }
    }
}