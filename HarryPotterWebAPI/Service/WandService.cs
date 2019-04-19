using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HarryPotterWebAPI.Entity;
using HarryPotterWebAPI.Models;
using HarryPotterWebAPI.Repository;

namespace HarryPotterWebAPI.Service
{
    public class WandService
    {
        public List<WandModel> Get()
        {
            WandRepository wandRepository = new WandRepository();
            try
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
                return wandModels;
            }
            catch
            {
                return null;
            }
        }

        public WandModel GetById(int id)
        {
            WandRepository wandRepository = new WandRepository();
            try
            {
                Wand wand = wandRepository.GetById(id);
                WandModel wandModel = new WandModel();

                wandModel.Id = wand.Id;
                wandModel.CoreMaterial = wand.CoreMaterial?.Identifier;
                wandModel.WoodMaterial = wand.WoodMaterial?.Identifier;
                wandModel.Length = wand.Length;
                wandModel.Wizzard = wand.Wizzard.Name;

                return wandModel;
            }
            catch
            {
                return null;
            }
        }

        public bool Post(WandModel wandModel)
        {
            WandRepository wandRepository = new WandRepository();
            try
            {
                Wand wand = new Wand();
                wand.WoodMaterial = new Material();
                wand.CoreMaterial = new Material();

                wand.CoreMaterial.Identifier = wandModel.CoreMaterial;
                wand.WoodMaterial.Identifier = wandModel.WoodMaterial;
                wand.Length = wandModel.Length;

                wandRepository.Insert(wand);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            WandRepository wandRepository = new WandRepository();
            try
            {
                wandRepository.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}