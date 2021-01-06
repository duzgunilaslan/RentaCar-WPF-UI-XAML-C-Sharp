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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CMPE312_RentaCar
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            

        }

        private void Grid_ToolTipOpening(object sender, ToolTipEventArgs e)
        {
            

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            if (password.Password.Equals("1234") && user.Text == "dask")
            {
                Window1 page2 = new Window1();
                page2.Show();
                this.Close();
            }
            else
                MessageBox.Show("sifre yanlıis");
        }
    }
}
