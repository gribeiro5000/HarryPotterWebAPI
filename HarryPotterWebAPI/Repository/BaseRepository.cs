using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HarryPotterWebAPI.Repository
{
    public class BaseRepository
    {
        protected string connectionString { get { return @"data source=C:\Users\gribe\Documents\coisas Gabriel\databases\HarryPotter.db"; } }
    }
}