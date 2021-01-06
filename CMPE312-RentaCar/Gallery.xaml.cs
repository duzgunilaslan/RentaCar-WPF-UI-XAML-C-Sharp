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
    /// Interaction logic for Gallery.xaml
    /// </summary>
    public partial class Gallery : Window
    {
        string connectionString =
            ConfigurationManager.ConnectionStrings["CMPE312_RentaCar.Properties.Settings.RentaCarDBConnectionString"].ConnectionString;
        SqlConnection sqlConnection;
        DataTable dt;


        public Gallery()
        {
            InitializeComponent();
            ListCars();
        }

        void ListCars()
        {
            
            sqlConnection = new SqlConnection(connectionString);
            SqlDataAdapter da; 
            sqlConnection.Open();
            SqlCommand command;
            string query = "select * from Vehicle_Type";
            command = new SqlCommand(query, sqlConnection);
            command.ExecuteNonQuery();
            da = new SqlDataAdapter(query, sqlConnection);
            dt = new DataTable("Vehicle_Type");
            da.Fill(dt);
            datagrid1.ItemsSource = dt.DefaultView;
            da.Update(dt);

        }

        private void gallery_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void adding_Click(object sender, RoutedEventArgs e)
        {

            Add add = new Add();
            add.Show();
            this.Close();
          



        }

        private void history_Click(object sender, RoutedEventArgs e)
        {

        }

        private void poweroff_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void datagrid1_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {

        }

        private void dataGrid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        public void datagrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                var selected = row_selected["vehicle_id"].ToString();
                

                string query2 = "select * from Vehicle_Details where vehicle_id="+selected;
                SqlDataAdapter da2 = new SqlDataAdapter(query2, sqlConnection);
                DataTable dt2 = new DataTable("Vehicle_Details");
                da2.Fill(dt2);
                dataGrid2.ItemsSource = dt2.DefaultView;

                

            }
        }

        private void Cars(object sender, TextCompositionEventArgs e)
        {

        }

        private void textbox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void filter_Click(object sender, RoutedEventArgs e)
        {
           
                DataView dataview = dt.DefaultView;
                dataview.RowFilter = "vehicle_id =" + Convert.ToInt32(textbox1.Text);
                datagrid1.ItemsSource = dataview;
            
        }

        private void Modify_Button_Click(object sender, RoutedEventArgs e)
        {

            ModifyPage modify = new ModifyPage();
            modify.Show();
            this.Close();
           
        }

        private void hom_Click(object sender, RoutedEventArgs e)
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
