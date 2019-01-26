using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HarryPotterWebAPI.Repository;
using HarryPotterWebAPI.Entity;
using HarryPotterWebAPI.Models;

namespace HarryPotterWebAPI.Controllers
{
    public class WizzardController : ApiController
    {
        WizzardRepository wizzardRepository = new WizzardRepository();
        
        public IHttpActionResult Get()
        {
            List<Wizzard> wizzards = wizzardRepository.Get();
            //List<WizzardModel> wizzardModels = new List<WizzardModel>();
            //for (int i = 0; i < wizzards.Count(); i++)
            //{
            //    WizzardModel wizzardModel = new WizzardModel();
            //    wizzardModel.Id = wizzards[i].Id;
            //    wizzardModel.Name = wizzards[i].Name;
            //    wizzardModel.Species = wizzards[i].Species;
            //    wizzardModel.Gender = wizzards[i].Gender;
            //    wizzardModel.House = wizzards[i].House;
            //    wizzardModel.DateOfBirth = wizzards[i].DateOfBirth;
            //    wizzardModel.YearOfBirth = wizzards[i].YearOfBirth;
            //    wizzardModel.Ancestry = wizzards[i].Ancestry;
            //    wizzardModel.EyeColour = wizzards[i].EyeColour;
            //    wizzardModel.HairColour = wizzards[i].HairColour;
            //    wizzardModel.WandModel.Id = wizzards[i].Wand.Id;
            //    wizzardModel.WandModel.WoodMaterial = wizzards[i].Wand.WoodMaterial;
            //    wizzardModel.WandModel.CoreMaterial = wizzards[i].Wand.CoreMaterial;
            //    wizzardModel.WandModel.Length = wizzards[i].Wand.Length;
            //    wizzardModel.Patronus = wizzards[i].Patronus;
            //    wizzardModel.HogwartsStudent = wizzards[i].HogwartsStudent;
            //    wizzardModel.HogwartsStaff = wizzards[i].HogwartsStaff;
            //    wizzardModel.Actor = wizzards[i].Actor;
            //    wizzardModel.Alive = wizzards[i].Alive;
            //    wizzardModel.Image = wizzards[i].Image;
            //
            //    wizzardModels.Add(wizzardModel);
            //}
            return Json(wizzards);
        }
    }
}
