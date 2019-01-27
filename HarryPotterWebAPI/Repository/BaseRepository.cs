using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HarryPotterWebAPI.Repository
{
    public class BaseRepository
    {
        protected string connectionString
        {
            get
            {
                //return Helpers.Utils.GetConnectionString("ConnectionString");
                return Helpers.Utils.GetRelativeConnectionString("LocalConnectionString");
            }
        }
    }
}