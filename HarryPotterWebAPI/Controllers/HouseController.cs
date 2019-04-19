using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using HarryPotterWebAPI.Models;
using HarryPotterWebAPI.Service;
using HarryPotterWebAPI.Helpers;

namespace HarryPotterWebAPI.Controllers
{
    public class HouseController : ApiController
    {
        public IHttpActionResult Get()
        {
            HouseService service = new HouseService();
            List<HouseModel> houseModels = service.Get();

            if (houseModels.HasRows())
            {
                return Json(houseModels);
            }
            else
            {
                return BadRequest();
            }
        }

        public IHttpActionResult GetById(int id)
        {
            HouseService service = new HouseService();
            HouseModel houseModel = service.GetById(id);

            if (houseModel != null)
            {
                return Json(houseModel);
            }
            else
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post([FromBody]HouseModel houseModel)
        {
            HouseService service = new HouseService();
            if (houseModel.Identifier != null)
            {
                if (service.Post(houseModel) == true)
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
            HouseService service = new HouseService();
            if(service.Delete(id) == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        
        [HttpPut]
        public IHttpActionResult Update([FromBody] HouseModel houseModel)
        {
            HouseService service = new HouseService();
            if (houseModel != null || houseModel.Identifier != null)
            {
                bool result = service.Update(houseModel);
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