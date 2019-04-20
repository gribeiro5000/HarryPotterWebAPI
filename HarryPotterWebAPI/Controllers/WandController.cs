using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HarryPotterWebAPI.Models;
using HarryPotterWebAPI.Helpers;
using HarryPotterWebAPI.Service;
using HarryPotterWebAPI.Interface;
using HarryPotterWebAPI.Repository;

namespace HarryPotterWebAPI.Controllers
{
    public class WandController : ApiController
    {
        IWandService _service;
        public WandController()
        {
            WandRepository repository = new WandRepository();
            _service = new WandService(repository); 
        }
        public IHttpActionResult Get()
        {
            List<WandModel> wandModels = _service.Get();

            if (wandModels.HasRows())
            {
                return Json(wandModels);
            }
            else
            {
                return BadRequest();
            }
        }

        public IHttpActionResult GetById(int id)
        {
            WandModel wandModel = _service.GetById(id);

            if (wandModel != null)
            {
                return Json(wandModel);
            }
            else
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post([FromBody]WandModel wandModel)
        {
            if (wandModel.WoodMaterial != null && wandModel.CoreMaterial != null)
            {
                if (_service.Post(wandModel) == true)
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
    }
}
