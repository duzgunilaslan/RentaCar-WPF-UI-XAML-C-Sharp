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
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace CMPE312_RentaCar
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        SqlConnection sqlConnection;
        static Random random;
        public Window1()
        {
            InitializeComponent();
            random = new Random();
            string connectionString =
            ConfigurationManager.ConnectionStrings["CMPE312_RentaCar.Properties.Settings.RentaCarDBConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            
        }
       
        public SeriesCollection SeriesCollection { get; set; }
        private void ButtonChangePieChart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlCommand command;
                SqlDataReader dataReader;
                string query = "select vehicle_status from Vehicle_Details";
                string Output = "";
                command = new SqlCommand(query, sqlConnection);
                dataReader = command.ExecuteReader();
                int rented=0; int free=0;
                while (dataReader.Read())
                    {
                        Output = Convert.ToString(dataReader.GetValue(0));
                           if (Output == "rented    ")
                               {
                                   rented++;
                               }
                           if (Output == "free      ")
                               {
                                    free++;
                               }
                 
                     }
               dataReader.Close();
               sqlConnection.Close();
               



                SeriesCollection = new SeriesCollection
                {
                    new PieSeries
                    {
                        Title = "Rented Vehicle", Values= new ChartValues<ObservableValue> { new ObservableValue(rented)},
                        DataLabels=true
                    },
                    new PieSeries
                    {
                        Title = "Non-Rented Vehicle", Values= new ChartValues<ObservableValue> { new ObservableValue(free)},
                        DataLabels=true
                    },
                   /* new PieSeries
                    {
                        Title = "Remanning Cars", Values= new ChartValues<ObservableValue> { new ObservableValue(random.Next(0, 50))},
                        DataLabels=true
                    }, */
                };
                DataContext = this;

            }
            catch(Exception exp)
            {
                MessageBox.Show("The PieChart Couldn't Upload !!! \n" + exp.Message);
            }
        }

        private void adding_Click(object sender, RoutedEventArgs e)
        {
            Add adpage = new Add();
            adpage.Show();
            this.Close();
        }

        private void gallery_Click(object sender, RoutedEventArgs e)
        {
            Gallery Gallery_Page = new Gallery();
            Gallery_Page.Show();
            this.Close();

        }

        private void history_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("History");
        }

        private void poweroff_Click(object sender, RoutedEventArgs e)
        {
            this.Close();        }
    }
}
