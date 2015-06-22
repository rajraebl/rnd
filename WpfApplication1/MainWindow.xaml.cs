using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StackExchange.Redis;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string host = "";
            string accessKey = "";

            //ConnectionMultiplexer connection = ConnectionMultiplexer.Connect("127.0.0.1,ssl=false");
            ConnectionMultiplexer connection = ConnectionMultiplexer.Connect(string.Format("{0},ssl=true,password={1}", host, accessKey));

            IDatabase cache = connection.GetDatabase();
            var endpoints = connection.GetEndPoints();
            var server = connection.GetServer(endpoints.First());
            server.FlushAllDatabases();
            


        }
    }
}
