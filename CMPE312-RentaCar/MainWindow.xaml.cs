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

namespace CMPE312_RentaCar
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

        private void Grid_ToolTipOpening(object sender, ToolTipEventArgs e)
        {
            

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          /*  if (user.Text=="ali")
            {
                MessageBox.Show("sifre Dogru");
            }
            else
                MessageBox.Show("sifre yanlıis"); */
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
