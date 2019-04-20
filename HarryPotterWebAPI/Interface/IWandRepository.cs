using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarryPotterWebAPI.Entity;

namespace HarryPotterWebAPI.Interface
{
    interface IWandRepository
    {
        List<Wand> Get();
        Wand GetById(int id);
        void Insert(Wand wand);
        void Delete(int id);
    }
}
