using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HarryPotterWebAPI.Repository
{
    public class BaseRepository
    {
        protected string connectionString { get { return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; } }
    }
}