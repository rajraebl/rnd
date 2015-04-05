using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.ServiceModel;
using System.Transactions;
using System.Threading;
using Client.CreditReference;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ServiceHost myServiceHost = null;
        AutoResetEvent waitForResponse = null;
        private void button1_Click(object sender, EventArgs e)
        {
            myServiceHost = new ServiceHost(typeof(CreditLimitResponseService));
            myServiceHost.Open();
            MessageBox.Show("Service Started");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            waitForResponse = new AutoResetEvent(false);

            CreditLimitRequestClient proxy = new CreditLimitRequestClient();
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                proxy.SendCreditLimitRequest("1");
                scope.Complete();
            }

            waitForResponse = new AutoResetEvent(true);
        }

       private void button2_Click(object sender, EventArgs e)
        {
            myServiceHost.Close();
            MessageBox.Show("Service Stoped");
        }
    }
}
