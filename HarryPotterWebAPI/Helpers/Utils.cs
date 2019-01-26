using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HarryPotterWebAPI.Helpers
{
    public static class Utils
    {
        public static string GetConnectionString(string conn) =>
            ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public static string GetRelativeConnectionString(string conn) =>
            ConfigurationManager.ConnectionStrings["LocalConnectionString"].ConnectionString
                .Replace("|DataDirectory|", System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName);

    }
}