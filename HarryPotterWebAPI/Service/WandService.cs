using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HarryPotterWebAPI.Entity;
using HarryPotterWebAPI.Models;
using HarryPotterWebAPI.Repository;
using HarryPotterWebAPI.Interface;

namespace HarryPotterWebAPI.Service
{
    public class WandService : IWandService
    {
        private readonly IWandRepository _wandRepository;
        public WandService(WandRepository wandRepository)
        {
            _wandRepository = wandRepository;
        }

        public List<WandModel> Get()
        {
            try
            {
                List<Wand> wands = _wandRepository.Get();
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
            try
            {
                Wand wand = _wandRepository.GetById(id);
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
            try
            {
                Wand wand = new Wand();
                wand.WoodMaterial = new Material();
                wand.CoreMaterial = new Material();

                wand.CoreMaterial.Identifier = wandModel.CoreMaterial;
                wand.WoodMaterial.Identifier = wandModel.WoodMaterial;
                wand.Length = wandModel.Length;

                _wandRepository.Insert(wand);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                _wandRepository.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}