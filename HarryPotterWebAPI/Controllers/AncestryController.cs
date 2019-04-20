using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HarryPotterWebAPI.Repository;
using HarryPotterWebAPI.Entity;
using HarryPotterWebAPI.Models;
using HarryPotterWebAPI.Service;
using HarryPotterWebAPI.Helpers;
using HarryPotterWebAPI.Interface;

namespace HarryPotterWebAPI.Controllers
{
    public class AncestryController : ApiController
    {
        IGenericService _service;
        public AncestryController()
        {
            GenericRepository<Ancestry> repository  = new GenericRepository<Ancestry>();
            _service = new GenericService<Ancestry>(repository);
        }

        public IHttpActionResult Get()
        {
            List<AncestryModel> ancestryModels = _service.Get<AncestryModel>();

            if (ancestryModels.HasRows())
            {
                return Json(ancestryModels);
            }
            else
            {
                return BadRequest();
            }
        }

        public IHttpActionResult GetById(int id)
        {
            AncestryModel ancestryModel = _service.GetById<AncestryModel>(id);

            if (ancestryModel != null)
            {
                return Json(ancestryModel);
            }
            else
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post([FromBody]AncestryModel ancestryModel)
        {
            if(ancestryModel.Identifier != null)
            {
                if (_service.Post<AncestryModel>(ancestryModel))
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
        public IHttpActionResult Update([FromBody] AncestryModel ancestryModel)
        {
            if (ancestryModel != null || ancestryModel.Identifier != null)
            {
                bool result = _service.Update<AncestryModel>(ancestryModel);
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
