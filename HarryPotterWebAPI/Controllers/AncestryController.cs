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
        
        public IHttpActionResult Get()
        {
            AncestryRepository ancestryRepository = new AncestryRepository();
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
            AncestryRepository ancestryRepository = new AncestryRepository();
            Ancestry ancestry = ancestryRepository.GetById(id);
            AncestryModel ancestryModel = new AncestryModel();
            ancestryModel.Id = ancestry.Id;
            ancestryModel.Identifier = ancestry.Identifier;

            return Json(ancestryModel);
        }

        public void Post([FromBody]AncestryModel ancestryModel)
        {
            AncestryRepository ancestryRepository = new AncestryRepository();
            Ancestry ancestry = new Ancestry();
            ancestry.Identifier = ancestryModel.Identifier;
            ancestryRepository.Insert(ancestry);
        }

        public void Delete(int id)
        {
            AncestryRepository ancestryRepository = new AncestryRepository();
            ancestryRepository.Delete(id);
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] AncestryModel ancestryModel)
        {
            AncestryRepository ancestryRepository = new AncestryRepository();
            Ancestry ancestry = new Ancestry();
            ancestry.Id = ancestryModel.Id;
            ancestry.Identifier = ancestryModel.Identifier;
            bool result = ancestryRepository.Update(ancestry);
            if (result == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
