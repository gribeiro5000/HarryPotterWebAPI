using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using HarryPotterWebAPI.Entity;
using System.Data.SQLite;

namespace HarryPotterWebAPI.Repository
{
    public class SpeciesRepository : BaseRepository
    {
        public List<Species> Get()
        {
            string sqlite = "select * from Species;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            List<Species> speciess = connection.Query<Species>(sqlite).ToList();

            return speciess;
        }

        public Species GetById(int id)
        {
            string sqlite = "select * from Species where Id = " + id + ";";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            Species species = connection.Query<Species>(sqlite).FirstOrDefault();

            return species;
        }

        public void Insert(Species specie)
        {
            string sqlite = @"insert into Species (Identifier) values (@speciesIdentifier);";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Execute(sqlite, new { speciesIdentifier = specie.Identifier });
        }

        public void Delete(int id)
        {
            string sqlite = @"delete from Species where Species.Id = @speciesId";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Execute(sqlite, new { speciesId = id });
        }
    }
}