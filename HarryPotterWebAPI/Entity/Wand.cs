using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HarryPotterWebAPI.Entity
{
    public class Wand
    {
        public int Id { get; set; }
        public Material WoodMaterial { get; set; }
        public Material CoreMaterial { get; set; }
        public double? Length { get; set; }
    }
}