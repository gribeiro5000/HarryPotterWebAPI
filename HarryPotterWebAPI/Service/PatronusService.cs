using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HarryPotterWebAPI.Entity;
using HarryPotterWebAPI.Models;
using HarryPotterWebAPI.Repository;

namespace HarryPotterWebAPI.Service
{
    public class PatronusService
    {
        public List<PatronusModel> Get()
        {
            PatronusRepository patronusRepository = new PatronusRepository();
            try
            {
                List<Patronus> patronuss = patronusRepository.Get();
                List<PatronusModel> patronusModels = new List<PatronusModel>();
                foreach (Patronus patronus in patronuss)
                {
                    PatronusModel patronusModel = new PatronusModel();
                    patronusModel.Id = patronus.Id;
                    patronusModel.Identifier = patronus.Identifier;

                    patronusModels.Add(patronusModel);
                }
                return patronusModels;
            }
            catch
            {
                return null;
            }
        }

        public PatronusModel GetById(int id)
        {
            PatronusRepository patronusRepository = new PatronusRepository();
            try
            {
                Patronus patronus = patronusRepository.GetById(id);
                PatronusModel patronusModel = new PatronusModel();
                patronusModel.Id = patronus.Id;
                patronusModel.Identifier = patronus.Identifier;

                return patronusModel;
            }
            catch
            {
                return null;
            }
        }

        public bool Post(PatronusModel patronusModel)
        {
            try
            {
                PatronusRepository patronusRepository = new PatronusRepository();
                Patronus patronus = new Patronus();
                patronus.Identifier = patronusModel.Identifier;
                patronusRepository.Insert(patronus);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            PatronusRepository patronusRepository = new PatronusRepository();
            try
            {
                patronusRepository.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(PatronusModel patronusModel)
        {
            PatronusRepository patronusRepository = new PatronusRepository();
            Patronus patronus = new Patronus();
            try
            {
                patronus.Id = patronusModel.Id;
                patronus.Identifier = patronusModel.Identifier;
                patronusRepository.Update(patronus);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}