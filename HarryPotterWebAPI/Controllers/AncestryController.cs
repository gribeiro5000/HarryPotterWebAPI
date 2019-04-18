using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HarryPotterWebAPI.Repository;
using HarryPotterWebAPI.Entity;
using HarryPotterWebAPI.Models;

namespace HarryPotterWebAPI.Controllers
{
    public class AncestryController : ApiController
    {
        AncestryRepository ancestryRepository = new AncestryRepository();
        
        public IHttpActionResult Get()
        {
            List<Ancestry> ancestrys = ancestryRepository.Get();
            List<AncestryModel> ancestryModels = new List<AncestryModel>();
            foreach(Ancestry ancestry in ancestrys)
            {
                AncestryModel ancestryModel = new AncestryModel();
                ancestryModel.Id = ancestry.Id;
                ancestryModel.Identifier = ancestry.Identifier;

                ancestryModels.Add(ancestryModel);
            }

            return Json(ancestryModels);
        }

        public IHttpActionResult GetById(int id)
        {
            Ancestry ancestry = ancestryRepository.GetById(id);
            AncestryModel ancestryModel = new AncestryModel();
            ancestryModel.Id = ancestry.Id;
            ancestryModel.Identifier = ancestry.Identifier;

            return Json(ancestryModel);
        }

        public void Post([FromBody]AncestryModel ancestryModel)
        {
            Ancestry ancestry = new Ancestry();
            ancestry.Identifier = ancestryModel.Identifier;
            ancestryRepository.Insert(ancestry);
        }

        public void Delete(int id)
        {
            ancestryRepository.Delete(id);
        }
    }
}
