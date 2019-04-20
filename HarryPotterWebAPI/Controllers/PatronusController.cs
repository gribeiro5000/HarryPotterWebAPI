using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HarryPotterWebAPI.Models;
using HarryPotterWebAPI.Service;
using HarryPotterWebAPI.Helpers;
using HarryPotterWebAPI.Entity;
using HarryPotterWebAPI.Interface;
using HarryPotterWebAPI.Repository;

namespace HarryPotterWebAPI.Controllers
{
    public class PatronusController : ApiController
    {
        IGenericService _service;
        public PatronusController()
        {
            GenericRepository<Patronus> repository = new GenericRepository<Patronus>();
            _service = new GenericService<Patronus>(repository);
        }

        public IHttpActionResult Get()
        {
            List<PatronusModel> patronusModels = _service.Get<PatronusModel>();

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
            PatronusModel patronusModel = _service.GetById<PatronusModel>(id);

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
            if (patronusModel.Identifier != null)
            {
                if (_service.Post(patronusModel))
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
        public IHttpActionResult Update([FromBody] PatronusModel patronusModel)
        {
            if (patronusModel != null || patronusModel.Identifier != null)
            {
                bool result = _service.Update(patronusModel);
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
