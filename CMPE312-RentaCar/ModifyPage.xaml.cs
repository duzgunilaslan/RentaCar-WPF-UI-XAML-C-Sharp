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
    /// Interaction logic for ModifyPage.xaml
    /// </summary>
    public partial class ModifyPage : Window
    {
        string connectionString =
            ConfigurationManager.ConnectionStrings["CMPE312_RentaCar.Properties.Settings.RentaCarDBConnectionString"].ConnectionString;
        SqlConnection sqlConnection;
        DataTable dt;
        SqlDataAdapter da;
        public ModifyPage()
        {
            

            InitializeComponent();


            sqlConnection = new SqlConnection(connectionString);
            SqlDataAdapter da;
            sqlConnection.Open();
            SqlCommand command;
            string query = "select * from Vehicle_Details";
            command = new SqlCommand(query, sqlConnection);
            command.ExecuteNonQuery();
            da = new SqlDataAdapter(query, sqlConnection);
            dt = new DataTable("Vehicle_Type");
            da.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
            da.Update(dt);

           
        }
        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                sqlConnection = new SqlConnection(connectionString);
                string query1 = "Update Vehicle_Details set vehicle_id=@vehicle_id,vehicle_status=@vehicle_status,meter_reading=@meter_reading where vehicle_id=@vehicle_id";
                SqlCommand command2 = new SqlCommand(query1, sqlConnection);
                sqlConnection.Open();

              //command2.Parameters.AddWithValue("@vehicle_reg_no", textboxReg.Text);
                command2.Parameters.AddWithValue("@vehicle_id", textboxId.Text);
                command2.Parameters.AddWithValue("@vehicle_status", textboxStatus.Text);
                command2.Parameters.AddWithValue("@meter_reading", TextboxMeter.Text);
                command2.ExecuteScalar();
             
                messageLabel.Content = "Your car information changed, You can turn Page!";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }

        }

        private void datagrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;

            string query2 = "select * from Vehicle_Details";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, sqlConnection);
            DataTable dt2 = new DataTable("Vehicle_Details");
            da2.Fill(dt2);
            textboxReg.Text = row_selected["vehicle_reg_no"].ToString();
            textboxId.Text = row_selected["vehicle_id"].ToString();
            textboxStatus.Text = row_selected["vehicle_status"].ToString();
            TextboxMeter.Text = row_selected["meter_reading"].ToString();



        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Gallery gallery = new Gallery();
            gallery.Show();
            this.Close();

        }
    }
}
