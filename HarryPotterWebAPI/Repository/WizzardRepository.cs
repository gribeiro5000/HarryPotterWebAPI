﻿using System;
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
            string sqLite = "SELECT * FROM Wizzard " +
                              LEFT JOIN patronus on wizzard.PatronusId = patronus.Id;";
                "JOIN Gender on wizzard.GenderId = Gender.Id " +
                "JOIN Colour c on wizzard.EyeColourId = c.Id " +
                "JOIN Colour c2 on wizzard.HairColourId = c2.Id " +
                "JOIN Material m1 on Wand.WoodMaterialId = M1.Id " +
                "JOIN MaterialType mt1 on m1.MaterialTypeId = mt1.Id " +
                "JOIN Material m2 on Wand.CoreMaterialId = M2.Id " +
                "JOIN MaterialType mt2 on m2.MaterialTypeId = mt2.Id " +
            var connection = new SQLiteConnection(connectionString);
            List<Wizzard> wizzards = connection.Query<Wizzard>
                (sqLite,
                new[]
                {
                    typeof(Wizzard),
                    typeof(Species),
                    typeof(Gender),
                    typeof(House),
                    typeof(Ancestry),
                    typeof(Colour),
                    typeof(Colour),
                    typeof(Wand),
                    typeof(Material),
                    typeof(MaterialType),
                    typeof(Material),
                    typeof(MaterialType),
                    typeof(Patronus)
                }
                , objects =>
                {
                    Wizzard wizzard = objects[0] as Wizzard;
                    Species species = objects[1] as Species;
                    Gender gender = objects[2] as Gender;
                    House house = objects[3] as House;
                    Ancestry ancestry = objects[4] as Ancestry;
                    Colour eyeColour = objects[5] as Colour;
                    Colour hairColour = objects[6] as Colour;
                    Wand wand = objects[7] as Wand;
                    Material woodMaterial = objects[8] as Material;
                    MaterialType mt1 = objects[9] as MaterialType;
                    Material coreMaterial = objects[10] as Material;
                    MaterialType mt2 = objects[11] as MaterialType;
                    Patronus patronus = objects[12] as Patronus;

                    wizzard.Species = species;
                    wizzard.Gender = gender;
                    wizzard.House = house;
                    wizzard.Ancestry = ancestry;
                    wizzard.EyeColour = eyeColour;
                    wizzard.HairColour = hairColour;
                    wizzard.Wand = wand;
                    wand.WoodMaterial = woodMaterial;
                    woodMaterial.MaterialType = mt1;
                    wand.CoreMaterial = coreMaterial;
                    coreMaterial.MaterialType = mt2;
                    wizzard.Patronus = patronus;

                    return wizzard;
                },
                splitOn: "Id,Id,Id,Id,Id,Id,Id,Id,Id,Id,Id,Id").ToList();

            return wizzards;
        }
    }
}