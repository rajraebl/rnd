using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

namespace qClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ServiceHost sh;
        private void button1_Click(object sender, EventArgs e)
        {
            sh = new ServiceHost(typeof(qClientnmsp.CreditLimitResponse));
            if(sh.State != CommunicationState.Opened)
            sh.Open();
            MessageBox.Show("Client Service Started");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ServiceReference.CreditLimitRequestClient c = new ServiceReference.CreditLimitRequestClient();
            c.SendCreditLimitRequest("1");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sh.Close();
            MessageBox.Show("Client Service Stopped");

        }

    }   

       
    }

namespace qClientnmsp
{
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

