using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HarryPotterWebAPI.Models;
using HarryPotterWebAPI.Helpers;
using HarryPotterWebAPI.Service;
using HarryPotterWebAPI.Entity;
using HarryPotterWebAPI.Interface;
using HarryPotterWebAPI.Repository;
using System.Web.Http.Cors;

namespace HarryPotterWebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class SpeciesController : ApiController
    {
        IGenericService _service;
        public SpeciesController()
        {
            GenericRepository<Species> repository = new GenericRepository<Species>();
            _service = new GenericService<Species>(repository);
        }

        public IHttpActionResult Get()
        {
            List<SpeciesModel> speciesModels = _service.Get<SpeciesModel>();

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
            SpeciesModel speciesModel = _service.GetById<SpeciesModel>(id);

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
            if (speciesModel.Identifier != null)
            {
                if (_service.Post(speciesModel))
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
            if (_service.Delete(id))
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
            if (speciesModel != null || speciesModel.Identifier != null)
            {
                bool result = _service.Update(speciesModel);
                if (result)
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
