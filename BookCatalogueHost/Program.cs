using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogueHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(BookCatalogueDemo.BooksCatalogueService)))
            {
                host.Open();
                Console.WriteLine("Service Started @ " + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}
