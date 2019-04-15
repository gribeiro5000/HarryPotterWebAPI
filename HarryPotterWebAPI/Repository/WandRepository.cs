﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using HarryPotterWebAPI.Entity;
using System.Data.SQLite;

namespace HarryPotterWebAPI.Repository
{
    public class WandRepository : BaseRepository
    {
        public List<Wand> Get()
        {
            string sqlite = @"select * from wand
                            left join Material m1 on wand.WoodMaterialId = m1.Id
                            left join MaterialType mt1 on m1.MaterialTypeId = mt1.Id
                            left join Material m2 on wand.CoreMaterialId = m2.Id
                            left join MaterialType mt2 on m2.MaterialTypeId = mt2.Id
                            left join Wizzard on wand.Id = Wizzard.WandId;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            List<Wand> wands = connection.Query<Wand, Material, MaterialType, Material, MaterialType, Wizzard, Wand>
                (sqlite,
                (wand, woodMaterial, woodMaterialType, coreMaterial, coreMaterialType, wizzard) =>
                {
                    wand.WoodMaterial = woodMaterial;
                    if (wand.WoodMaterial != null)
                    {
                        wand.WoodMaterial.MaterialType = woodMaterialType;
                    }
                    wand.CoreMaterial = coreMaterial;
                    if (wand.CoreMaterial != null)
                    {
                        wand.CoreMaterial.MaterialType = coreMaterialType;
                    }
                    wand.Wizzard = wizzard;

                    return wand;
                },
                splitOn: "Id,Id,Id,Id,Id").Distinct().ToList();

            return wands;
        }

        public Wand GetById(int id)
        {
            string sqlite = @"select * from wand
                            left join Material m1 on wand.WoodMaterialId = m1.Id
                            left join MaterialType mt1 on m1.MaterialTypeId = mt1.Id
                            left join Material m2 on wand.CoreMaterialId = m2.Id
                            left join MaterialType mt2 on m2.MaterialTypeId = mt2.Id
                            left join Wizzard on wand.Id = Wizzard.WandId
                            where wand.id = " + id + ";";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            Wand Wand = connection.Query<Wand, Material, MaterialType, Material, MaterialType, Wizzard, Wand>
                (sqlite,
                (wand, woodMaterial, woodMaterialType, coreMaterial, coreMaterialType, wizzard) =>
                {
                    wand.WoodMaterial = woodMaterial;
                    if (wand.WoodMaterial != null)
                    {
                        wand.WoodMaterial.MaterialType = woodMaterialType;
                    }
                    wand.CoreMaterial = coreMaterial;
                    if (wand.CoreMaterial != null)
                    {
                        wand.CoreMaterial.MaterialType = coreMaterialType;
                    }
                    wand.Wizzard = wizzard;

                    return wand;
                },
                splitOn: "Id,Id,Id,Id,Id").Distinct().FirstOrDefault();

            return Wand;
        }
    }
}