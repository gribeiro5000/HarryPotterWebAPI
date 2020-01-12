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
using HarryPotterWebAPI.Interface;
using System.Web.Http.Cors;

namespace HarryPotterWebAPI.Controllers
{
    [EnableCors("*","*","*")]
    public class WizzardController : ApiController
    {
        IWizzardService _service;
        public WizzardController()
        {
            WizzardRepository repository = new WizzardRepository();
            _service = new WizzardService(repository);
        }

        public IHttpActionResult Get()
        {
            List<WizzardModel> wizzardModels = _service.Get();

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
            WizzardModel wizzardModel = _service.GetById(id);

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
            if (wizzardModel != null)
            {
                if (_service.Post(wizzardModel) == true)
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
            if (_service.Delete(id) == true)
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
            if(wizzardModel != null || wizzardModel.Id != 0)
            {
                bool result = _service.Update(wizzardModel);
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
