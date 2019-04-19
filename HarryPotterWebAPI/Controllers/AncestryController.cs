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

namespace HarryPotterWebAPI.Controllers
{
    public class AncestryController : ApiController
    {
        
        public IHttpActionResult Get()
        {
            AncestryService service = new AncestryService();
            List<AncestryModel> ancestryModels = service.Get();

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
            AncestryService service = new AncestryService();
            AncestryModel ancestryModel = service.GetById(id);

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
            AncestryService service = new AncestryService();
            if(ancestryModel.Identifier != null)
            {
                if (service.Post(ancestryModel) == true)
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
            AncestryService service = new AncestryService();
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
        public IHttpActionResult Update([FromBody] AncestryModel ancestryModel)
        {
            AncestryService service = new AncestryService();
            if (ancestryModel != null || ancestryModel.Identifier != null)
            {
                bool result = service.Update(ancestryModel);
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
