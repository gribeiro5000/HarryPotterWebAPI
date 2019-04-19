using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HarryPotterWebAPI.Models;
using HarryPotterWebAPI.Helpers;
using HarryPotterWebAPI.Service;

namespace HarryPotterWebAPI.Controllers
{
    public class SpeciesController : ApiController
    {
        public IHttpActionResult Get()
        {
            SpeciesService service = new SpeciesService();
            List<SpeciesModel> speciesModels = service.Get();

            if (speciesModels.HasRows())
            {
                return Json(speciesModels);
            }
            else
            {
                return BadRequest();
            }
        }

        public IHttpActionResult GetById(int id)
        {
            SpeciesService service = new SpeciesService();
            SpeciesModel speciesModel = service.GetById(id);

            if (speciesModel != null)
            {
                return Json(speciesModel);
            }
            else
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post([FromBody]SpeciesModel speciesModel)
        {
            SpeciesService service = new SpeciesService();
            if (speciesModel.Identifier != null)
            {
                if (service.Post(speciesModel) == true)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }

        }

        public IHttpActionResult Delete(int id)
        {
            SpeciesService service = new SpeciesService();
            if (service.Delete(id) == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] SpeciesModel speciesModel)
        {
            SpeciesService service = new SpeciesService();
            if (speciesModel != null || speciesModel.Identifier != null)
            {
                bool result = service.Update(speciesModel);
                if (result == true)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
