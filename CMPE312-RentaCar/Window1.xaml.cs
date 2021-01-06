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

namespace CMPE312_RentaCar
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        static Random random;
        public Window1()
        {
            InitializeComponent();
            random = new Random();

        }

        public SeriesCollection SeriesCollection { get; set; }
        private void ButtonChangePieChart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SeriesCollection = new SeriesCollection
                {
                    new PieSeries
                    {
                        Title = "Rented Vehicle", Values= new ChartValues<ObservableValue> { new ObservableValue(random.Next(0, 50))},
                        DataLabels=true
                    },
                    new PieSeries
                    {
                        Title = "Non-Rented Vehicle", Values= new ChartValues<ObservableValue> { new ObservableValue(random.Next(0, 50))},
                        DataLabels=true
                    },
                    new PieSeries
                    {
                        Title = "Remanning Cars", Values= new ChartValues<ObservableValue> { new ObservableValue(random.Next(0, 50))},
                        DataLabels=true
                    },
                };
                DataContext = this;

            }
            catch(Exception exp)
            {
                MessageBox.Show("The PieChart Couldn't Upload !!! \n" + exp.Message);
            }
        }
    }
}
