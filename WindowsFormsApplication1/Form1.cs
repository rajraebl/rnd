using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Messaging;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ServiceHost serviceHost;
        private void button1_Click(object sender, EventArgs e)
        {
            serviceHost = new ServiceHost(typeof(ola.CreditLimitRequest));
            if (serviceHost.State != CommunicationState.Opened)
                serviceHost.Open();
            MessageBox.Show("Client Service Started");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serviceHost.Close();
            MessageBox.Show("Client Service Stopped");

        }
    }

   

}


namespace ola
{
    [ServiceContract]
    public interface ICreditLimitRequest
    {
        [OperationContract(IsOneWay = true)]
        void SendCreditLimitRequest(string id);
    }

    public class CreditLimitRequest : ICreditLimitRequest
    {
        public void SendCreditLimitRequest(string id)
        {
            double value;

            if (id == "1")
                value = 10;
            else if (id == "2")
                value = 20;
            else
                value = 0;

            WindowsFormsApplication1.ServiceReference.CreditLimitResponseClient c = new WindowsFormsApplication1.ServiceReference.CreditLimitResponseClient();
            c.SendCreditLimitResponse(value);
        }
    }
}
