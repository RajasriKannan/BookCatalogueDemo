using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace BookCatalogueDemoWindowsService
{
    public partial class BookCatalogueDemoWindowsService : ServiceBase
    {
        ServiceHost ServiceHost;
        public BookCatalogueDemoWindowsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ServiceHost = new ServiceHost(typeof(BookCatalogueDemo.BooksCatalogueService));
            ServiceHost.Open();
        }

        protected override void OnStop()
        {
            ServiceHost.Close();
        }
    }
}
