using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HarryPotterWebAPI.Models
{
    public class WandModel
    {
        public int? Id { get; set; }
        public string WoodMaterial { get; set; }
        public string CoreMaterial { get; set; }
        public double? Length { get; set; }
        public string Wizzard { get; set; }
    }
}