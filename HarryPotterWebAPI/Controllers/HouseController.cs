using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using HarryPotterWebAPI.Entity;
using HarryPotterWebAPI.Models;
using HarryPotterWebAPI.Repository;

namespace HarryPotterWebAPI.Controllers
{
    public class HouseController : ApiController
    {
        HouseRepository houseRepository = new HouseRepository();
        
        public IHttpActionResult Get()
        {
            List<House> houses = houseRepository.Get();
            List<HouseModel> houseModels = new List<HouseModel>();

            foreach(House house in houses)
            {
                HouseModel houseModel = new HouseModel();
                houseModel.Id = house.Id;
                houseModel.Identifier = house.Identifier;

                houseModels.Add(houseModel);
            }

            return Json(houseModels);
        }

        public IHttpActionResult GetById(int id)
        {
            House house = houseRepository.GetById(id);
            HouseModel houseModel = new HouseModel();

            houseModel.Id = house.Id;
            houseModel.Identifier = house.Identifier;

            return Json(houseModel);
        }

        public void Post([FromBody]HouseModel houseModel)
        {
            House house = new House();
            house.Identifier = houseModel.Identifier;
            houseRepository.Insert(house);
        }

        public void Delete(int id)
        {
            houseRepository.Delete(id);
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] HouseModel houseModel)
        {
            HouseRepository houseRepository = new HouseRepository();
            House house = new House();
            house.Id = houseModel.Id;
            house.Identifier = houseModel.Identifier;
            bool result = houseRepository.Update(house);
            if (result == true)
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