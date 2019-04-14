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
            List<WizzardModel> wizzardModels = new List<WizzardModel>();

            foreach (Wizzard wizzard in wizzards)
            {
                WizzardModel wizzardModel = new WizzardModel();
                wizzardModel.Wand = new WandModel();
                wizzardModel.Id = wizzard.Id;
                wizzardModel.Name = wizzard.Name;
                wizzardModel.Species = wizzard.Species?.Identifier;
                wizzardModel.Gender = wizzard.Gender?.Identifier;
                wizzardModel.House = wizzard.House?.Identifier;
                wizzardModel.DateOfBirth = wizzard.DateOfBirth;
                wizzardModel.YearOfBirth = wizzard.YearOfBirth;
                wizzardModel.Ancestry = wizzard.Ancestry?.Identifier;
                wizzardModel.EyeColour = wizzard.EyeColour?.Identifier;
                wizzardModel.HairColour = wizzard.HairColour?.Identifier;
                wizzardModel.Wand.WoodMaterial = wizzard.Wand?.WoodMaterial?.Identifier;
                wizzardModel.Wand.CoreMaterial = wizzard.Wand?.CoreMaterial?.Identifier;
                wizzardModel.Wand.Length = wizzard.Wand?.Length;
                wizzardModel.Patronus = wizzard.Patronus?.Identifier;
                wizzardModel.HogwartsStudent = wizzard.HogwartsStudent;
                wizzardModel.HogwartsStaff = wizzard.HogwartsStaff;
                wizzardModel.Actor = wizzard.Actor;
                wizzardModel.Alive = wizzard.Alive;
                wizzardModel.Image = wizzard.Image;
                
                wizzardModels.Add(wizzardModel);
            }
            return Json(wizzardModels);
        }

        public IHttpActionResult GetById (int id)
        {
            Wizzard wizzard = wizzardRepository.GetById(id);
            WizzardModel wizzardModel = new WizzardModel();
            wizzardModel.Wand = new WandModel();

            wizzardModel.Id = wizzard.Id;
            wizzardModel.Name = wizzard.Name;
            wizzardModel.Species = wizzard.Species?.Identifier;
            wizzardModel.Gender = wizzard.Gender?.Identifier;
            wizzardModel.House = wizzard.House?.Identifier;
            wizzardModel.DateOfBirth = wizzard.DateOfBirth;
            wizzardModel.YearOfBirth = wizzard.YearOfBirth;
            wizzardModel.Ancestry = wizzard.Ancestry?.Identifier;
            wizzardModel.EyeColour = wizzard.EyeColour?.Identifier;
            wizzardModel.HairColour = wizzard.HairColour?.Identifier;
            wizzardModel.Wand.WoodMaterial = wizzard.Wand?.WoodMaterial?.Identifier;
            wizzardModel.Wand.CoreMaterial = wizzard.Wand?.CoreMaterial?.Identifier;
            wizzardModel.Wand.Length = wizzard.Wand?.Length;
            wizzardModel.Patronus = wizzard.Patronus?.Identifier;
            wizzardModel.HogwartsStudent = wizzard.HogwartsStudent;
            wizzardModel.HogwartsStaff = wizzard.HogwartsStaff;
            wizzardModel.Actor = wizzard.Actor;
            wizzardModel.Alive = wizzard.Alive;
            wizzardModel.Image = wizzard.Image;

            return Json(wizzardModel);
        }
    }
}
