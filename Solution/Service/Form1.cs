using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Messaging;
using System.ServiceModel;

namespace Service
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        internal static ServiceHost myServiceHost = null;

        private void button1_Click(object sender, EventArgs e)
        {
            myServiceHost = new ServiceHost(typeof(CreditLimitRequestService));
            myServiceHost.Open();
            MessageBox.Show("Service Started!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (myServiceHost.State != CommunicationState.Closed)
            {
                myServiceHost.Close();
                MessageBox.Show("Service Stopped!");
            }
        }
    }
}
