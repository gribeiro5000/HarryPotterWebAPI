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
            string sqLite = @"SELECT *
                              FROM Wizzard
                              LEFT JOIN species on wizzard.SpeciesId = species.Id
                              LEFT JOIN house on wizzard.HouseId = house.Id
                              LEFT JOIN ancestry on wizzard.AncestryId = ancestry.Id
                              LEFT JOIN wand on wizzard.WandId = wand.Id
                              LEFT JOIN patronus on wizzard.PatronusId = patronus.Id;";
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