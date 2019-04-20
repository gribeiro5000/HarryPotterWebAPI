using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using HarryPotterWebAPI.Models;
using HarryPotterWebAPI.Service;
using HarryPotterWebAPI.Helpers;
using HarryPotterWebAPI.Entity;
using HarryPotterWebAPI.Interface;
using HarryPotterWebAPI.Repository;

namespace HarryPotterWebAPI.Controllers
{
    public class HouseController : ApiController
    {
        IGenericService _service;
        public HouseController()
        {
            GenericRepository<House> repository = new GenericRepository<House>();
            _service = new GenericService<House>(repository);
        }

        public IHttpActionResult Get()
        {
            List<HouseModel> houseModels = _service.Get<HouseModel>();

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
            HouseModel houseModel = _service.GetById<HouseModel>(id);

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
            if (houseModel.Identifier != null)
            {
                if (_service.Post(houseModel))
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
        public IHttpActionResult Update([FromBody] HouseModel houseModel)
        {
            if (houseModel != null || houseModel.Identifier != null)
            {
                bool result = _service.Update(houseModel);
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