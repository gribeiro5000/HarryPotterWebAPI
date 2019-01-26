using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HarryPotterWebAPI.Entity
{
    public class Material
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public MaterialType MaterialTypeId { get; set; }
    }
}