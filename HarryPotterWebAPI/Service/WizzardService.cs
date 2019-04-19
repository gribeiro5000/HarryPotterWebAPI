using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HarryPotterWebAPI.Entity;
using HarryPotterWebAPI.Models;
using HarryPotterWebAPI.Repository;

namespace HarryPotterWebAPI.Service
{
    public class WizzardService
    {
        public List<WizzardModel> Get()
        {
            WizzardRepository wizzardRepository = new WizzardRepository();
            try
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
                    wizzardModel.Wand.Id = wizzard.Wand?.Id;
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
                return wizzardModels;
            }
            catch
            {
                return null;
            }
        }

        public WizzardModel GetById(int id)
        {
            WizzardRepository wizzardRepository = new WizzardRepository();
            try
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
                wizzardModel.Wand.Id = wizzard.Wand?.Id;
                wizzardModel.Wand.WoodMaterial = wizzard.Wand?.WoodMaterial?.Identifier;
                wizzardModel.Wand.CoreMaterial = wizzard.Wand?.CoreMaterial?.Identifier;
                wizzardModel.Wand.Length = wizzard.Wand?.Length;
                wizzardModel.Patronus = wizzard.Patronus?.Identifier;
                wizzardModel.HogwartsStudent = wizzard.HogwartsStudent;
                wizzardModel.HogwartsStaff = wizzard.HogwartsStaff;
                wizzardModel.Actor = wizzard.Actor;
                wizzardModel.Alive = wizzard.Alive;
                wizzardModel.Image = wizzard.Image;

                return wizzardModel;
            }
            catch
            {
                return null;
            }
        }

        public bool Post(WizzardModel wizzardModel)
        {
            WizzardRepository wizzardRepository = new WizzardRepository();
            try
            {
                Wizzard wizzard = new Wizzard();
                wizzard.Species = new Species();
                wizzard.Gender = new Gender();
                wizzard.House = new House();
                wizzard.Ancestry = new Ancestry();
                wizzard.EyeColour = new Colour();
                wizzard.HairColour = new Colour();
                wizzard.Patronus = new Patronus();
                wizzard.Wand = new Wand();

                wizzard.Name = wizzardModel.Name;
                wizzard.Species.Identifier = wizzardModel.Species;
                wizzard.Gender.Identifier = wizzardModel.Gender;
                wizzard.House.Identifier = wizzardModel.House;
                wizzard.DateOfBirth = wizzardModel.DateOfBirth;
                wizzard.YearOfBirth = wizzardModel.YearOfBirth;
                wizzard.Ancestry.Identifier = wizzardModel.Ancestry;
                wizzard.EyeColour.Identifier = wizzardModel.EyeColour;
                wizzard.HairColour.Identifier = wizzardModel.HairColour;
                wizzard.Wand.Id = wizzardModel.Wand.Id;
                wizzard.Patronus.Identifier = wizzardModel.Patronus;
                wizzard.HogwartsStudent = wizzardModel.HogwartsStudent;
                wizzard.HogwartsStaff = wizzardModel.HogwartsStaff;
                wizzard.Actor = wizzardModel.Actor;
                wizzard.Alive = wizzardModel.Alive;
                wizzard.Image = wizzardModel.Image;

                wizzardRepository.Insert(wizzard);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            WizzardRepository wizzardRepository = new WizzardRepository();
            try
            {
                wizzardRepository.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(WizzardModel wizzardModel)
        {
            WizzardRepository wizzardRepository = new WizzardRepository();
            try
            {
                Wizzard wizzard = new Wizzard();
                wizzard.Species = new Species();
                wizzard.Gender = new Gender();
                wizzard.House = new House();
                wizzard.Ancestry = new Ancestry();
                wizzard.EyeColour = new Colour();
                wizzard.HairColour = new Colour();
                wizzard.Patronus = new Patronus();
                wizzard.Wand = new Wand();

                wizzard.Id = wizzardModel.Id;
                wizzard.Name = wizzardModel.Name;
                wizzard.Species.Identifier = wizzardModel.Species;
                wizzard.Gender.Identifier = wizzardModel.Gender;
                wizzard.House.Identifier = wizzardModel.House;
                wizzard.DateOfBirth = wizzardModel.DateOfBirth;
                wizzard.YearOfBirth = wizzardModel.YearOfBirth;
                wizzard.Ancestry.Identifier = wizzardModel.Ancestry;
                wizzard.EyeColour.Identifier = wizzardModel.EyeColour;
                wizzard.HairColour.Identifier = wizzardModel.HairColour;
                wizzard.Wand.Id = wizzardModel.Wand.Id;
                wizzard.Patronus.Identifier = wizzardModel.Patronus;
                wizzard.HogwartsStudent = wizzardModel.HogwartsStudent;
                wizzard.HogwartsStaff = wizzardModel.HogwartsStaff;
                wizzard.Actor = wizzardModel.Actor;
                wizzard.Alive = wizzardModel.Alive;
                wizzard.Image = wizzardModel.Image;

                wizzardRepository.Update(wizzard);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}