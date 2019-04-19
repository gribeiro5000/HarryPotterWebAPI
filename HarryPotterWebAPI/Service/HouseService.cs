using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HarryPotterWebAPI.Entity;
using HarryPotterWebAPI.Models;
using HarryPotterWebAPI.Repository;

namespace HarryPotterWebAPI.Service
{
    public class HouseService
    {
        public List<HouseModel> Get()
        {
            HouseRepository houseRepository = new HouseRepository();
            try
            {
                List<House> houses = houseRepository.Get();
                List<HouseModel> houseModels = new List<HouseModel>();
                foreach (House house in houses)
                {
                    HouseModel houseModel = new HouseModel();
                    houseModel.Id = house.Id;
                    houseModel.Identifier = house.Identifier;

                    houseModels.Add(houseModel);
                }
                return houseModels;
            }
            catch
            {
                return null;
            }
        }

        public HouseModel GetById(int id)
        {
            HouseRepository houseRepository = new HouseRepository();
            try
            {
                House house = houseRepository.GetById(id);
                HouseModel houseModel = new HouseModel();
                houseModel.Id = house.Id;
                houseModel.Identifier = house.Identifier;

                return houseModel;
            }
            catch
            {
                return null;
            }
        }

        public bool Post(HouseModel houseModel)
        {
            try
            {
                HouseRepository houseRepository = new HouseRepository();
                House house = new House();
                house.Identifier = houseModel.Identifier;
                houseRepository.Insert(house);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            HouseRepository houseRepository = new HouseRepository();
            try
            {
                houseRepository.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(HouseModel houseModel)
        {
            HouseRepository houseRepository = new HouseRepository();
            House house = new House();
            try
            {
                house.Id = houseModel.Id;
                house.Identifier = houseModel.Identifier;
                houseRepository.Update(house);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}