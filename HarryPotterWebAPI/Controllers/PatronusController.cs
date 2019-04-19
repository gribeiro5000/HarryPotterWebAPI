using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HarryPotterWebAPI.Models;
using HarryPotterWebAPI.Service;
using HarryPotterWebAPI.Helpers;

namespace HarryPotterWebAPI.Controllers
{
    public class PatronusController : ApiController
    {
        public IHttpActionResult Get()
        {
            PatronusService service = new PatronusService();
            List<PatronusModel> patronusModels = service.Get();

            if (patronusModels.HasRows())
            {
                return Json(patronusModels);
            }
            else
            {
                return BadRequest();
            }
        }

        public IHttpActionResult GetById(int id)
        {
            PatronusService service = new PatronusService();
            PatronusModel patronusModel = service.GetById(id);

            if (patronusModel != null)
            {
                return Json(patronusModel);
            }
            else
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post([FromBody]PatronusModel patronusModel)
        {
            PatronusService service = new PatronusService();
            if (patronusModel.Identifier != null)
            {
                if (service.Post(patronusModel) == true)
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
            PatronusService service = new PatronusService();
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
        public IHttpActionResult Update([FromBody] PatronusModel patronusModel)
        {
            PatronusService service = new PatronusService();
            if (patronusModel != null || patronusModel.Identifier != null)
            {
                bool result = service.Update(patronusModel);
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
