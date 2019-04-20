using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HarryPotterWebAPI.Entity;
using HarryPotterWebAPI.Repository;
using HarryPotterWebAPI.Models;
using AutoMapper;

namespace HarryPotterWebAPI.Service
{
    public class GenericService<T> where T : Generic
    {
        public List<T2> Get<T2>() where T2 : GenericModel
        {
            GenericRepository<T> genericRepository = new GenericRepository<T>();
            try
            {
                List<T> entitys = genericRepository.Get();
                List<T2> models = new List<T2>();
                foreach (T entity in entitys)
                {
                    dynamic model = new
                    {
                        entity.Id,
                        entity.Identifier
                    };

                    var x = Mapper.Map<T2>(model);

                    models.Add(x);
                }
                return models;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public T2 GetById<T2>(int id) where T2 : GenericModel
        {
            GenericRepository<T> genericRepository = new GenericRepository<T>();
            try
            {
                T entity = genericRepository.GetById(id);
                dynamic model = new
                {
                    Id = entity.Id,
                    Identifier = entity.Identifier
                };

                var x = Mapper.Map<T2>(model);

                return x;
            }
            catch (Exception exception)
            {
                return null;
            }
        }
    }
}