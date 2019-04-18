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
                wandModel.Length = wand.Length;
                wandModel.Wizzard = wand.Wizzard?.Name;

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
            wandModel.Length = wand.Length;
            wandModel.Wizzard = wand.Wizzard.Name;

            return Json(wandModel);
        }

        public void Post([FromBody]WandModel wandModel)
        {
            Wand wand = new Wand();
            wand.WoodMaterial = new Material();
            wand.CoreMaterial = new Material();

            wand.CoreMaterial.Identifier = wandModel.CoreMaterial;
            wand.WoodMaterial.Identifier = wandModel.WoodMaterial;
            wand.Length = wandModel.Length;

            wandRepository.Insert(wand);
        }

        public void Delete(int id)
        {
            wandRepository.Delete(id);
        }
    }
}
