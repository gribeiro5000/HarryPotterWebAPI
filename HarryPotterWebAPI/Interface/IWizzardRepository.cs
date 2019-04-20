using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarryPotterWebAPI.Entity;

namespace HarryPotterWebAPI.Interface
{
    public interface IWizzardRepository 
    {
        List<Wizzard> Get();
        Wizzard GetById(int id);
        void Insert(Wizzard wizzard);
        void Delete(int id);
        bool Update(Wizzard wizzard);
    }
}
