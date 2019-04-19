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
    public class WandController : ApiController
    {
        public IHttpActionResult Get()
        {
            WandService service = new WandService();
            List<WandModel> wandModels = service.Get();

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
            WandService service = new WandService();
            WandModel wandModel = service.GetById(id);

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
            WandService service = new WandService();
            if (wandModel.WoodMaterial != null && wandModel.CoreMaterial != null)
            {
                if (service.Post(wandModel) == true)
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
            WandService service = new WandService();
            if (service.Delete(id) == true)
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
