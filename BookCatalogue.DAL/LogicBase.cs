using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BookCatalogue.DAL
{
    public class LogicBase
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DBCS"].ToString();
        }
    }
}
