using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using HarryPotterWebAPI.Entity;
using System.Data.SQLite;

namespace HarryPotterWebAPI.Repository
{
    public class AncestryRepository : BaseRepository
    {
        public List<Ancestry> Get()
        {
            string sqlite = @"select * from ancestry;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            List<Ancestry> ancestrys = connection.Query<Ancestry>(sqlite).ToList();

            return ancestrys;
        }

        public Ancestry GetById(int id)
        {
            string sqlite = @"select * from ancestry where ancestry.Id = " + id + ";";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            Ancestry ancestry = connection.Query<Ancestry>(sqlite).FirstOrDefault();

            return ancestry;
        }

        public void Insert(Ancestry ancestry)
        {
            string sqlite = @"insert into Ancestry (Identifier) values (@ancestryIdentifier);";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Execute(sqlite, new { ancestryIdentifier = ancestry.Identifier });
        }

        public void Delete(int id)
        {
            string sqlite = @"delete from Ancestry where Ancestry.Id = @ancestryId";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Execute(sqlite, new { ancestryId = id });
        }
    }
}