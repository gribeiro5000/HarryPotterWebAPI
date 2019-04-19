using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace HarryPotterWebAPI.Repository
{
    public class GenericRepository<T> : BaseRepository
    {
        public List<T> Get()
        {
            string className = typeof(T).Name;
            string sqlite = $"select * from {className};";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            List<T> objects = connection.Query<T>(sqlite).ToList();

            return objects;
        }
    }
}