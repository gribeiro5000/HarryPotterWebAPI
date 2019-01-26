using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HarryPotterWebAPI.Models
{
    public class WizzardModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Gender { get; set; }
        public string House { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int YearOfBirth { get; set; }
        public string Ancestry { get; set; }
        public string EyeColour { get; set; }
        public string HairColour { get; set; }
        public WandModel WandModel { get; set; }
        public string Patronus { get; set; }
        public bool HogwartsStudent { get; set; }
        public bool HogwartsStaff { get; set; }
        public string Actor { get; set; }
        public bool Alive { get; set; }
        public string Image { get; set; }
    }
}