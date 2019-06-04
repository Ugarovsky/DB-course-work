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
using System.Windows.Shapes;

namespace Shop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            AdminPassword admPass = new AdminPassword();
            admPass.Show();
            mw.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Client cl = new Client();
            cl.Show();
            mw.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            AuthEmpl a = new AuthEmpl();
            a.Show();
            mw.Close();
        }
    }
}
