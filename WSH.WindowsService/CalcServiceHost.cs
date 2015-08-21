using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WSH.WindowsService
{
    public partial class CalcServiceHost : ServiceBase
    {
        public CalcServiceHost()
        {
            InitializeComponent();
        }

        private ServiceHost sh;

        protected override void OnStart(string[] args)
        {
            if(sh != null) sh.Close();

            string HttpAddr = "http://localhost:56002/CalService";
            sh = new ServiceHost(typeof(WSH.WCFService.CalcService),new Uri(HttpAddr));
            
            
            
            sh.AddServiceEndpoint(typeof(WSH.WCFService.ICalcService),new BasicHttpBinding(), HttpAddr );


            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            
            sh.Description.Behaviors.Add(smb);
            //sh.Description.Behaviors.Add(new ServiceDebugBehavior{IncludeExceptionDetailInFaults = true});
            sh.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            sh.Open();
            Console.Read();
        }

        protected override void OnStop()
        {
            sh.Close();
        }
    }
}
