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
            string sqLite = @"SELECT * FROM Wizzard
                           LEFT JOIN Species on wizzard.SpeciesId = Species.Id
                           LEFT JOIN Gender on wizzard.GenderId = Gender.Id
                           LEFT JOIN House on wizzard.HouseId = House.Id
                           LEFT JOIN Ancestry on wizzard.AncestryId = Ancestry.Id
                           LEFT JOIN Colour c on wizzard.EyeColourId = c.Id
                           LEFT JOIN Colour c2 on wizzard.HairColourId = c2.Id
                           LEFT JOIN Wand on wizzard.WandId = Wand.Id
                           LEFT JOIN Material m1 on Wand.WoodMaterialId = M1.Id
                           LEFT JOIN MaterialType mt1 on m1.MaterialTypeId = mt1.Id
                           LEFT JOIN Material m2 on Wand.CoreMaterialId = M2.Id
                           LEFT JOIN MaterialType mt2 on m2.MaterialTypeId = mt2.Id
                           LEFT JOIN patronus on wizzard.PatronusId = Patronus.Id";

            SQLiteConnection connection = new SQLiteConnection(connectionString);
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
                    if (wand != null)
                    {
                        wand.WoodMaterial = woodMaterial;
                        if (woodMaterial != null)
                            wand.WoodMaterial.MaterialType = mt1;

                        wand.CoreMaterial = coreMaterial;
                        if (coreMaterial != null)
                            wand.CoreMaterial.MaterialType = mt2;
                    }
                    wizzard.Patronus = patronus;

                    return wizzard;
                },
                splitOn: "Id,Id,Id,Id,Id,Id,Id,Id,Id,Id,Id,Id").ToList();

            return wizzards;
        }

        public Wizzard GetById(int id)
        {
            string sqLite = @"select * from Wizzard 
                            left join Species on Wizzard.SpeciesId = Species.Id
                            left join Gender on Wizzard.GenderId = Gender.Id
                            left join House on Wizzard.HouseId = House.Id
                            left join Ancestry on Wizzard.AncestryId = Ancestry.Id
                            left join Colour eye on Wizzard.EyeColourId = eye.Id
                            left join Colour hair on Wizzard.HairColourId = hair.Id
                            left join Wand on Wizzard.WandId = Wand.Id
                            left join Material mWood on Wand.WoodMaterialId = mWood.Id
                            left join MaterialType mtWood on mWood.MaterialTypeId = mtWood.Id
                            left join Material mCore on Wand.CoreMaterialId = mCore.Id
                            left join MaterialType mtCore on mCore.MaterialTypeId = mtCore.Id
                            left join Patronus on Wizzard.PatronusId = Patronus.Id
                            where Wizzard.Id = " + id + ";";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            Wizzard wizzard = connection.Query<Wizzard>
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
                    Wizzard _wizzard = objects[0] as Wizzard;
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

                    _wizzard.Species = species;
                    _wizzard.Gender = gender;
                    _wizzard.House = house;
                    _wizzard.Ancestry = ancestry;
                    _wizzard.EyeColour = eyeColour;
                    _wizzard.HairColour = hairColour;
                    _wizzard.Wand = wand;
                    if (wand != null)
                    {
                        wand.WoodMaterial = woodMaterial;
                        if (woodMaterial != null)
                            wand.WoodMaterial.MaterialType = mt1;

                        wand.CoreMaterial = coreMaterial;
                        if (coreMaterial != null)
                            wand.CoreMaterial.MaterialType = mt2;
                    }
                    _wizzard.Patronus = patronus;

                    return _wizzard;
                },
                splitOn: "Id,Id,Id,Id,Id,Id,Id,Id,Id,Id,Id,Id").FirstOrDefault();

            return wizzard;
        }

        public void Insert(Wizzard wizzard)
        {
            string sqlite = "select * from Species where Species.Identifier = '" + wizzard.Species.Identifier + "'";
                   sqlite += " UNION ";
                   sqlite += "select * from Gender where gender.Identifier = '" + wizzard.Gender.Identifier + "' ";
                   sqlite += " UNION ";
                   sqlite += "select * from House where House.Identifier = '" + wizzard.House.Identifier + "' ";
                   sqlite += " UNION ";
                   sqlite += "select * from Ancestry where Ancestry.Identifier = '" + wizzard.Ancestry.Identifier + "' ";
                   sqlite += " UNION ";
                   sqlite += "select * from colour where colour.Identifier = '" + wizzard.HairColour.Identifier + "' ";
                   sqlite += " UNION ";
                   sqlite += "select * from colour where colour.Identifier = '" + wizzard.EyeColour.Identifier + "' ";
                   sqlite += " UNION ";
                   sqlite += "select * from Patronus where Patronus.Identifier = '" + wizzard.Patronus.Identifier + "';";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            var wizzardData = connection.Query(sqlite);

            wizzard.Species.Id = Convert.ToInt32(wizzardData.Where(x => x.Identifier == wizzard.Species.Identifier).FirstOrDefault()?.Id);
            wizzard.Gender.Id = Convert.ToInt32(wizzardData.Where(x => x.Identifier == wizzard.Gender.Identifier).FirstOrDefault()?.Id);
            wizzard.House.Id = Convert.ToInt32(wizzardData.Where(x => x.Identifier == wizzard.House.Identifier).FirstOrDefault()?.Id);
            wizzard.Ancestry.Id = Convert.ToInt32(wizzardData.Where(x => x.Identifier == wizzard.Ancestry.Identifier).FirstOrDefault()?.Id);
            wizzard.HairColour.Id = Convert.ToInt32(wizzardData.Where(x => x.Identifier == wizzard.HairColour.Identifier).FirstOrDefault()?.Id);
            wizzard.EyeColour.Id = Convert.ToInt32(wizzardData.Where(x => x.Identifier == wizzard.EyeColour.Identifier).FirstOrDefault()?.Id);
            wizzard.Patronus.Id = Convert.ToInt32(wizzardData.Where(x => x.Identifier == wizzard.Patronus.Identifier).FirstOrDefault()?.Id);
            
            sqlite = @"insert into Wizzard (Name, SpeciesId, GenderId, HouseId, 
                       DateOfBirth, YearOfBirth, AncestryId, EyeColourId, 
                       HairColourId, WandId, PatronusId, HogwartsStudent, 
                       HogwartsStaff, Actor, Alive, Image)
                       values(@Name, @speciesId, @GenderId, @HouseId, @DateOfBirth, @YearOfBirth, 
                        @ancestryId, @eyeColourId, @hairColourId, @wandId, @patronusId, @hogwartsStudent, 
                        @hogwartsStaff, @actor, @alive, @image);";

            connection.Execute(sqlite,
                new
                {
                    Id = wizzard.Id,
                    Name = wizzard.Name,
                    speciesId = wizzard.Species.Id,
                    GenderId = wizzard.Gender.Id,
                    HouseId = wizzard.House.Id,
                    DateOfBirth = wizzard.DateOfBirth,
                    YearOfBirth = wizzard.YearOfBirth,
                    ancestryId = wizzard.Ancestry.Id,
                    eyeColourId = wizzard.EyeColour.Id,
                    hairColourId = wizzard.HairColour.Id,
                    wandId = wizzard.Wand.Id,
                    patronusId = wizzard.Patronus.Id,
                    hogwartsStudent = wizzard.HogwartsStudent,
                    hogwartsStaff = wizzard.HogwartsStaff,
                    actor = wizzard.Actor,
                    alive = wizzard.Alive,
                    image = wizzard.Image
                });
        }

        public void Delete(int id)
        {
            string sqlite = @"delete from Wizzard where Wizzard.Id = @wizzardId";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Execute(sqlite, new { wizzardId = id });
        }
    }
}
