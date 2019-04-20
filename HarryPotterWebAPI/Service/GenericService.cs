using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HarryPotterWebAPI.Entity;
using HarryPotterWebAPI.Repository;
using HarryPotterWebAPI.Models;
using AutoMapper;
using HarryPotterWebAPI.Interface;

namespace HarryPotterWebAPI.Service
{
    public class GenericService<T> : IGenericService where T : Generic
    {
        private readonly IGenericRepository<T> _genericRepository;
        public GenericService(GenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public List<T2> Get<T2>() where T2 : GenericModel
        {
            try
            {
                List<T> entitys = _genericRepository.Get();
                List<T2> models = new List<T2>();
                foreach (T entity in entitys)
                {
                    dynamic model = new
                    {
                        Id = entity.Id,
                        Identifier = entity.Identifier
                    };

                    T2 obj = Mapper.Map<T2>(model);
                    models.Add(obj);
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
            try
            {
                T entity = _genericRepository.GetById(id);
                dynamic model = new
                {
                    Id = entity.Id,
                    Identifier = entity.Identifier
                };

                T2 obj = Mapper.Map<T2>(model);
                return obj;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public bool Post<T2>(T2 model) where T2 : GenericModel
        {
            try
            {
                dynamic entity = new
                {
                    Id = model.Id,
                    Identifier = model.Identifier
                };

                T obj = Mapper.Map<T>(entity);
                _genericRepository.Insert(obj);

                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                _genericRepository.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update<T2>(T2 model) where T2 : GenericModel
        {
            Ancestry ancestry = new Ancestry();
            try
            {
                dynamic entity = new
                {
                    Id = model.Id,
                    Identifier = model.Identifier
                };

                T obj = Mapper.Map<T>(entity);

                _genericRepository.Update(obj);

                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
    }
}