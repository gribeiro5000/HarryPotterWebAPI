using System;
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
            string sqlite = @"select Wand.Id, Wand.WoodMaterialId, Wand.CoreMaterialId,
                            Wand.Length,m1.Id, m1.Identifier, mt1.Id, mt1.Identifier,
                            m2.Id, m2.Identifier, mt2.Id, mt2.Identifier, Wizzard.Name 
                            from wand
                            left join Material m1 on wand.WoodMaterialId = m1.Id
                            left join MaterialType mt1 on m1.MaterialTypeId = mt1.Id
                            left join Material m2 on wand.CoreMaterialId = m2.Id
                            left join MaterialType mt2 on m2.MaterialTypeId = mt2.Id
                            left join Wizzard on wand.Id = Wizzard.WandId;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            List<Wand> wands = connection.Query<Wand, Material, MaterialType, Material, MaterialType, Wand>
                (sqlite,
                (wand, woodMaterial, woodMaterialType, coreMaterial, coreMaterialTyp) =>
                {
                    wand.WoodMaterial = woodMaterial;
                    wand.WoodMaterial.MaterialType = woodMaterialType;
                    wand.CoreMaterial = coreMaterial;
                    wand.CoreMaterial.MaterialType = coreMaterialTyp;

                    return wand;
                },
                splitOn: "Id,Id,Id,Id,Id").Distinct().ToList();

            return wands;
        }

        public Wand GetById(int id)
        {
            string sqlite = @"select Wand.Id, Wand.WoodMaterialId, Wand.CoreMaterialId,
                            Wand.Length, m1.Identifier, mt1.Identifier,
                            m2.Identifier, mt2.Identifier, Wizzard.Name from wand
                            left join Material m1 on wand.WoodMaterialId = m1.Id
                            left join MaterialType mt1 on m1.MaterialTypeId = mt1.Id
                            left join Material m2 on wand.CoreMaterialId = m2.Id
                            left join MaterialType mt2 on m2.MaterialTypeId = mt2.Id
                            left join Wizzard on wand.Id = Wizzard.WandId
                            where id = " + id + ";";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            Wand wand = connection.Query<Wand>(sqlite).FirstOrDefault();

            return wand;
        }
    }
}