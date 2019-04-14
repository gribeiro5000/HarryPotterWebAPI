using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HarryPotterWebAPI.Repository;
using HarryPotterWebAPI.Models;
using HarryPotterWebAPI.Entity;

namespace HarryPotterWebAPI.Controllers
{
    public class WandController : ApiController
    {
        WandRepository wandRepository = new WandRepository();

        public IHttpActionResult Get()
        {
            List<Wand> wands = wandRepository.Get();
            List<WandModel> wandModels = new List<WandModel>();

            foreach (Wand wand in wands)
            {
                WandModel wandModel = new WandModel();
                wandModel.Id = wand.Id;
                wandModel.CoreMaterial = wand.CoreMaterial?.Identifier;
                wandModel.WoodMaterial = wand.WoodMaterial?.Identifier;
                wandModel.Wizzard = wand.Wizzard;

                wandModels.Add(wandModel);
            }

            return Json(wandModels);
        }

        public IHttpActionResult GetById(int id)
        {
            Wand wand = wandRepository.GetById(id);
            WandModel wandModel = new WandModel();

            wandModel.Id = wand.Id;
            wandModel.CoreMaterial = wand.CoreMaterial?.Identifier;
            wandModel.WoodMaterial = wand.WoodMaterial?.Identifier;
            wandModel.Wizzard = wand.Wizzard;

            return Json(wandModel);
        }
    }
}
