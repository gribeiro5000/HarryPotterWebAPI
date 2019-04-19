using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HarryPotterWebAPI.Repository;
using HarryPotterWebAPI.Entity;
using HarryPotterWebAPI.Models;
using HarryPotterWebAPI.Helpers;
using HarryPotterWebAPI.Service;

namespace HarryPotterWebAPI.Controllers
{
    public class WizzardController : ApiController
    {
        
        public IHttpActionResult Get()
        {
            WizzardService service = new WizzardService();
            List<WizzardModel> wizzardModels = service.Get();

            if (wizzardModels.HasRows())
            {
                return Json(wizzardModels);
            }
            else
            {
                return BadRequest();
            }
        }

        public IHttpActionResult GetById (int id)
        {
            WizzardService service = new WizzardService();
            WizzardModel wizzardModel = service.GetById(id);

            if (wizzardModel != null)
            {
                return Json(wizzardModel);
            }
            else
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post([FromBody] WizzardModel wizzardModel)
        {
            WizzardService service = new WizzardService();
            if (wizzardModel != null)
            {
                if (service.Post(wizzardModel) == true)
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
            WizzardService service = new WizzardService();
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
        public IHttpActionResult Update([FromBody] WizzardModel wizzardModel)
        {
            WizzardService service = new WizzardService();
            if(wizzardModel != null || wizzardModel.Id != 0)
            {
                bool result = service.Update(wizzardModel);
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
