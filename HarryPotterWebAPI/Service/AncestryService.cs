using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HarryPotterWebAPI.Entity;
using HarryPotterWebAPI.Models;
using HarryPotterWebAPI.Repository;

namespace HarryPotterWebAPI.Service
{
    public class AncestryService
    {
        public List<AncestryModel> Get()
        {
            GenericRepository<Ancestry> ancestryRepository = new GenericRepository<Ancestry>();
            //AncestryRepository ancestryRepository = new AncestryRepository();
            try
            {
                List<Ancestry> ancestrys = ancestryRepository.Get();
                List<AncestryModel> ancestryModels = new List<AncestryModel>();
                foreach (Ancestry ancestry in ancestrys)
                {
                    AncestryModel ancestryModel = new AncestryModel();
                    ancestryModel.Id = ancestry.Id;
                    ancestryModel.Identifier = ancestry.Identifier;

                    ancestryModels.Add(ancestryModel);
                }
                return ancestryModels;
            }
            catch
            {
                return null;
            }
        }

        public AncestryModel GetById(int id)
        {
            AncestryRepository ancestryRepository = new AncestryRepository();
            try
            {
                Ancestry ancestry = ancestryRepository.GetById(id);
                AncestryModel ancestryModel = new AncestryModel();
                ancestryModel.Id = ancestry.Id;
                ancestryModel.Identifier = ancestry.Identifier;

                return ancestryModel;
            }
            catch
            {
                return null;
            }
        }

        public bool Post(AncestryModel ancestryModel)
        {
            AncestryRepository ancestryRepository = new AncestryRepository();
            try
            {
                Ancestry ancestry = new Ancestry();
                ancestry.Identifier = ancestryModel.Identifier;
                ancestryRepository.Insert(ancestry);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            AncestryRepository ancestryRepository = new AncestryRepository();
            try
            {
                ancestryRepository.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(AncestryModel ancestryModel)
        {
            AncestryRepository ancestryRepository = new AncestryRepository();
            Ancestry ancestry = new Ancestry();
            try
            {
                ancestry.Id = ancestryModel.Id;
                ancestry.Identifier = ancestryModel.Identifier;
                ancestryRepository.Update(ancestry);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}