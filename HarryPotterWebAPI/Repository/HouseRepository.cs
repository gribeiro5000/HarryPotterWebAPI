using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using HarryPotterWebAPI.Entity;
using Dapper;

namespace HarryPotterWebAPI.Repository
{
    public class HouseRepository : BaseRepository
    {
        public List<House> Get()
        {
            string sqlite = "select * from House;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            List<House> houses = connection.Query<House>(sqlite).ToList();

            return houses;
        }

        public House GetById(int id)
        {
            string sqlite = "select * from House where Id = " + id + ";";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            House house = connection.Query<House>(sqlite).FirstOrDefault();

            return house;
        }

        public void Insert(House house)
        {
            string sqlite = @"insert into House (Identifier) values (@houseIdentifier);";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Execute(sqlite, new { houseIdentifier = house.Identifier });
        }

        public void Delete(int id)
        {
            string sqlite = @"delete from House where House.Id = @houseId";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Execute(sqlite, new { houseId = id });
        }

        public bool Update(House house)
        {
            string sqlite = @"update House set Identifier = @houseIdentifier where House.Id = @houseId";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            try
            {
                connection.ExecuteScalar(sqlite, new { houseIdentifier = house.Identifier, houseId = house.Id });
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}