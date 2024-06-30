using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Net.NetworkInformation;
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

namespace IsThereInternet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool Ping()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void test(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                SystemSounds.Beep.Play();
                System.Threading.Thread.Sleep(1000);
            }
        }

        private void beeping(object sender, RoutedEventArgs e)
        {
            while (enabler.IsChecked==true)
            {
                if (Ping())
                {
                    SystemSounds.Beep.Play();
                    System.Threading.Thread.Sleep(1000);
                }
                
            }
        }
    }
}
