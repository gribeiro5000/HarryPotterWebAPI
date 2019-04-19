using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HarryPotterWebAPI.Entity;
using HarryPotterWebAPI.Models;
using HarryPotterWebAPI.Repository;

namespace HarryPotterWebAPI.Service
{
    public class SpeciesService
    {
        public List<SpeciesModel> Get()
        {
            SpeciesRepository speciesRepository = new SpeciesRepository();
            try
            {
                List<Species> speciess = speciesRepository.Get();
                List<SpeciesModel> speciesModels = new List<SpeciesModel>();
                foreach (Species species in speciess)
                {
                    SpeciesModel speciesModel = new SpeciesModel();
                    speciesModel.Id = species.Id;
                    speciesModel.Identifier = species.Identifier;

                    speciesModels.Add(speciesModel);
                }
                return speciesModels;
            }
            catch
            {
                return null;
            }
        }

        public SpeciesModel GetById(int id)
        {
            SpeciesRepository speciesRepository = new SpeciesRepository();
            try
            {
                Species species = speciesRepository.GetById(id);
                SpeciesModel speciesModel = new SpeciesModel();
                speciesModel.Id = species.Id;
                speciesModel.Identifier = species.Identifier;

                return speciesModel;
            }
            catch
            {
                return null;
            }
        }

        public bool Post(SpeciesModel speciesModel)
        {
            try
            {
                SpeciesRepository speciesRepository = new SpeciesRepository();
                Species species = new Species();
                species.Identifier = speciesModel.Identifier;
                speciesRepository.Insert(species);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            SpeciesRepository speciesRepository = new SpeciesRepository();
            try
            {
                speciesRepository.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(SpeciesModel speciesModel)
        {
            SpeciesRepository speciesRepository = new SpeciesRepository();
            Species species = new Species();
            try
            {
                species.Id = speciesModel.Id;
                species.Identifier = speciesModel.Identifier;
                speciesRepository.Update(species);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}