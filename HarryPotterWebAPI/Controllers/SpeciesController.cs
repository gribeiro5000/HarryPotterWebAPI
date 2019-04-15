using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HarryPotterWebAPI.Entity;
using HarryPotterWebAPI.Models;
using HarryPotterWebAPI.Repository;

namespace HarryPotterWebAPI.Controllers
{
    public class SpeciesController : ApiController
    {
        SpeciesRepository speciesRepository = new SpeciesRepository();

        public IHttpActionResult Get()
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

            return Json(speciesModels);
        }

        public IHttpActionResult GetById(int id)
        {
            Species species = speciesRepository.GetById(id);
            SpeciesModel speciesModel = new SpeciesModel();
            speciesModel.Id = species.Id;
            speciesModel.Identifier = species.Identifier;

            return Json(speciesModel);
        }
    }
}
