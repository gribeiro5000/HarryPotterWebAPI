using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HarryPotterWebAPI.Models
{
    public class WandModel
    {
        public string WoodMaterial { get; set; }
        public string CoreMaterial { get; set; }
        public double? Length { get; set; }
    }
}