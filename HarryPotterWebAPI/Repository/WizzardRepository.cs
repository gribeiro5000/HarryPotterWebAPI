using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HarryPotterWebAPI.Entity;
using Dapper;
using System.Data.SQLite;

namespace HarryPotterWebAPI.Repository
{
    public class WizzardRepository : BaseRepository
    {
        public List<Wizzard> Get()
        {
            string sqLite = "SELECT Wizzard.Id, Wizzard.Name, Species.Id, Species.Identifier, Wizzard.GenderId, ";
                sqLite += "House.Id, House.Identifier, Wizzard.DateOfBirth, Wizzard.YearOfBirth, Ancestry.Id, ";
                sqLite += "Ancestry.Identifier, Wizzard.EyeColourId, Wizzard.HairColourId, Wand.Id, Wand.WoodMaterialId, ";
                sqLite += "Wand.CoreMaterialId, Wand.Length, Patronus.Id, Patronus.Identifier, wizzard.HogwartsStudent, "; 
                sqLite += "Wizzard.HogwartsStaff, Wizzard.Actor, Wizzard.Alive, Wizzard.Image FROM Wizzard ";
                sqLite += "JOIN species on wizzard.SpeciesId = species.Id ";
                sqLite += "JOIN house on wizzard.HouseId = house.Id ";
                sqLite += "JOIN ancestry on wizzard.AncestryId = ancestry.Id ";
                sqLite += "JOIN wand on wizzard.WandId = wand.Id ";
                sqLite += "JOIN patronus on wizzard.PatronusId = patronus.Id;";
            var connection = new SQLiteConnection(connectionString);
            List<Wizzard> wizzards = connection.Query<Wizzard, Species, House, Ancestry, Wand, Patronus, Wizzard>
                (sqLite, (wizzard, species, house, ancestry, wand, patronus) =>
                {
                    wizzard.Species = species;
                    wizzard.House = house;
                    wizzard.Ancestry = ancestry;
                    wizzard.Wand = wand;
                    wizzard.Patronus = patronus;
                    return wizzard;
                }, splitOn: "SpeciesId,HouseId,AncestryId,WandId,PatronusId").ToList();

            return wizzards;
        }
    }
}