using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HarryPotterWebAPI.Repository;
using HarryPotterWebAPI.Models;
using HarryPotterWebAPI.Entity;

namespace HarryPotterWebAPI.Controllers
{
    public class PatronusController : ApiController
    {
        PatronusRepository patronusRepository = new PatronusRepository();

        public IHttpActionResult Get()
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

            return Json(patronusModels);
        }

        public IHttpActionResult GetById(int id)
        {
            Patronus patronus = patronusRepository.GetById(id);
            PatronusModel patronusModel = new PatronusModel();

            patronusModel.Id = patronus.Id;
            patronusModel.Identifier = patronus.Identifier;

            return Json(patronusModel);
        }

        public void Post([FromBody]PatronusModel patronusModel)
        {
            Patronus patronus = new Patronus();
            patronus.Identifier = patronusModel.Identifier;
            patronusRepository.Insert(patronus);
        }

        public void Delete(int id)
        {
            patronusRepository.Delete(id);
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] PatronusModel patronusModel)
        {
            PatronusRepository patronusRepository = new PatronusRepository();
            Patronus patronus = new Patronus();
            patronus.Id = patronusModel.Id;
            patronus.Identifier = patronusModel.Identifier;
            bool result = patronusRepository.Update(patronus);
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
