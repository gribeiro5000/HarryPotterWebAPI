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
            string sqLite = "SELECT Wizzard.Id, Wizzard.Name, Wizzard.GenderId, Wizzard.YearOfBirth, " +
                "Wizzard.EyeColourId, Wizzard.HairColourId, wizzard.HogwartsStudent, " +
                "Wizzard.HogwartsStaff, Wizzard.Actor, Wizzard.Alive, Wizzard.Image, " +
                "Species.Id, Species.Identifier, House.Id, House.Identifier, Ancestry.Id, Ancestry.Identifier, " +
                "Wand.Id, Wand.WoodMaterialId, Wand.CoreMaterialId, Wand.Length, Patronus.Id, Patronus.Identifier " +
                "FROM Wizzard " +
                "JOIN species on wizzard.SpeciesId = species.Id " +
                "JOIN house on wizzard.HouseId = house.Id " +
                "JOIN ancestry on wizzard.AncestryId = ancestry.Id " +
                "JOIN wand on wizzard.WandId = wand.Id " +
                "JOIN patronus on wizzard.PatronusId = patronus.Id;";
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
                }, splitOn: "Id,Id,Id,Id,Id").ToList();

            return wizzards;
        }
    }
}