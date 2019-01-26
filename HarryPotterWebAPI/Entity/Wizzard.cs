using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HarryPotterWebAPI.Entity
{
    public class Wizzard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Species Species { get; set; }
        public Gender Gender { get; set; }
        public House House { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int YearOfBirth { get; set; }
        public Ancestry Ancestry { get; set; }
        public Colour EyeColour { get; set; }
        public Colour HairColour { get; set; }
        public Wand Wand { get; set; }
        public Patronus Patronus { get; set; }
        public bool HogwartsStudent { get; set; }
        public bool HogwartsStaff { get; set; }
        public string Actor { get; set; }
        public bool Alive { get; set; }
        public string Image { get; set; }
    }
}