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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CMPE312_RentaCar
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        string connectionString =
            ConfigurationManager.ConnectionStrings["CMPE312_RentaCar.Properties.Settings.RentaCarDBConnectionString"].ConnectionString;
        SqlConnection sqlConnection;
        SqlConnection sqlConnection2;

        public Add()
        {
            InitializeComponent();
        }
        private void AddVehicle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int check = 0;
                String status = "free";
                sqlConnection = new SqlConnection(connectionString);
                string query1 = "insert into Vehicle_Type values (@vehicle_id,@name,@model_year,@gear_type,@deposit) ";
                SqlCommand command = new SqlCommand(query1, sqlConnection);
                sqlConnection.Open();

                if (radioGearTypeAuto.IsChecked == true)
                {
                    check = 1;
                }
                command.Parameters.AddWithValue("@vehicle_id", textboxId.Text);
                command.Parameters.AddWithValue("@name", textboxName.Text);
                command.Parameters.AddWithValue("@model_year", textboxModel.Text);
                command.Parameters.AddWithValue("@gear_type", check);
                command.Parameters.AddWithValue("@deposit", 0);
                command.ExecuteScalar();
                sqlConnection.Close();

                sqlConnection2 = new SqlConnection(connectionString);
                string query2 = "insert into Vehicle_Details values (@vehicle_reg_no,@vehicle_id,@vehicle_status,@meter_reading) ";
                SqlCommand command2 = new SqlCommand(query2, sqlConnection2);
                sqlConnection2.Open();
                command2.Parameters.AddWithValue("@vehicle_reg_no", textboxRegNo.Text);
                command2.Parameters.AddWithValue("@vehicle_id", textboxId.Text);
                command2.Parameters.AddWithValue("@vehicle_status", status);
                command2.Parameters.AddWithValue("@meter_reading", textboxMeter.Text);
                command2.ExecuteScalar();
                sqlConnection2.Close();
                final.Content = "Your Car Added !";


            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            

        }

        private void gallery_Click(object sender, RoutedEventArgs e)
        {
            Gallery gallery = new Gallery();
            gallery.Show();
            this.Close();
        }

        private void history_Click(object sender, RoutedEventArgs e)
        {

        }

        private void poweroff_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void adding_Click(object sender, RoutedEventArgs e)
        {

        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            Window1 home = new Window1();
            home.Show();
            this.Close();
        }
    }
}
