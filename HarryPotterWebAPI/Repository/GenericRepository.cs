using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using HarryPotterWebAPI.Entity;
using HarryPotterWebAPI.Interface;

namespace HarryPotterWebAPI.Repository
{
    public class GenericRepository<T> : BaseRepository, IGenericRepository<T> where T : Generic
    {
        public List<T> Get()
        {
            string className = typeof(T).Name;
            string sqlite = $"select * from {className};";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            List<T> objects = connection.Query<T>(sqlite).ToList();

            return objects;
        }

        public T GetById(int id)
        {
            string className = typeof(T).Name;
            string sqlite = $"select * from {className} where {className}.Id = " + id + ";";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            T objects = connection.Query<T>(sqlite).FirstOrDefault();

            return objects;
        }

        public bool Insert(T entity)
        {
            string className = typeof(T).Name;
            string sqlite = $"insert into {className} (Identifier) values (@typeIdentifier);";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            try
            {
                connection.Execute(sqlite, new { typeIdentifier = entity.Identifier });
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            string className = typeof(T).Name;
            string sqlite = $"delete from {className} where {className}.Id = @typeId";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            try
            {
                connection.Execute(sqlite, new { typeId = id });
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(T entity)
        {
            string className = typeof(T).Name;
            string sqlite = $"update {className} set Identifier = @typeIdentifier where {className}.Id = @typeId";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            try
            {
                connection.ExecuteScalar(sqlite, new { typeIdentifier = entity.Identifier, typeId = entity.Id });
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}