using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;
using Dapper;
using HarryPotterWebAPI.Entity;

namespace HarryPotterWebAPI.Repository
{
    public class PatronusRepository :BaseRepository
    {
        public List<Patronus> Get()
        {
            string sqlite = "select * from Patronus;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            List<Patronus> patronuss = connection.Query<Patronus>(sqlite).ToList();

            return patronuss;
        }

        public Patronus GetById(int id)
        {
            string sqlite = "select * from Patronus where Id = " + id + ";";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            Patronus patronus = connection.Query<Patronus>(sqlite).FirstOrDefault();

            return patronus;
        }

        public void Insert(Patronus patronus)
        {
            string sqlite = @"insert into Patronus (Identifier) values (@patronusIdentifier);";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Execute(sqlite, new { patronusIdentifier = patronus.Identifier });
        }

        public void Delete(int id)
        {
            string sqlite = @"delete from Patronus where Patronus.Id = @patronusId";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Execute(sqlite, new { patronusId = id });
        }
    }
}