using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarryPotterWebAPI.Models;

namespace HarryPotterWebAPI.Interface
{
    interface IGenericService
    {
        List<T2> Get<T2>() where T2 : GenericModel;
        T2 GetById<T2>(int id) where T2 : GenericModel;
        bool Post<T2>(T2 model) where T2 : GenericModel;
        bool Delete(int id);
        bool Update<T2>(T2 model) where T2 : GenericModel;
    }
}
