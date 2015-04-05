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

namespace Client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        ServiceHost sh;
        private void button1_Click(object sender, EventArgs e)
        {
            sh = new ServiceHost(typeof(CreditLimitResponse));
            if(sh.State == CommunicationState.Closed)
            sh.Open();
            MessageBox.Show("Client Service Started");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ServiceReference.CreditLimitRequestClient c = new ServiceReference.CreditLimitRequestClient();
            //c.SendCreditLimitRequest("1");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sh.Close();
            MessageBox.Show("Client Service Stopped");

        }
    }

    [ServiceContract]
    public interface ICreditLimitResponse 
    {
        [OperationContract(IsOneWay=true)]
        void SendCreditLimitResponse(double limit);
    
    }

    public class CreditLimitResponse :ICreditLimitResponse
    {
        public void SendCreditLimitResponse(double limit)
        {
            System.Windows.Forms.MessageBox.Show(limit.ToString());
        }
    }
}
