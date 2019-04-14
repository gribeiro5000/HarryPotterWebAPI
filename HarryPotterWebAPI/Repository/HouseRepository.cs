﻿using System;
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
    }
}