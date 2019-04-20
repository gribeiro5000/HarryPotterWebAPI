using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarryPotterWebAPI.Models;

namespace HarryPotterWebAPI.Interface
{
    interface IWandService
    {
        List<WandModel> Get();
        WandModel GetById(int id);
        bool Post(WandModel wandModel);
        bool Delete(int id);
    }
}
