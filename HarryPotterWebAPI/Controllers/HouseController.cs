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
    }
}