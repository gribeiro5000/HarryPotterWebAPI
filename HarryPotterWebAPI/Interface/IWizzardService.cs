using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarryPotterWebAPI.Models;

namespace HarryPotterWebAPI.Interface
{
    public interface IWizzardService
    {
        List<WizzardModel> Get();
        WizzardModel GetById(int id);
        bool Post(WizzardModel wizzardModel);
        bool Delete(int id);
        bool Update(WizzardModel wizzardModel);
    }
}
