using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using Common;
using Server;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Entry> showDB;
        public ObservableCollection<Entry> ShowDB { get { return showDB; } set { showDB = value; OnPropertyChanged("ShowDB"); } }
        private DataProxy dp;
        private DateTime dtFrom;
        private DateTime dtTo;
        private List<Entry> dataDB;

        public DateTime DtFrom { get { return dtFrom; } set { dtFrom = value; OnPropertyChanged("DtFrom"); } }
        public DateTime DtTo { get { return dtTo; } set { dtTo = value; OnPropertyChanged("DtTo"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public MainWindow()
        {
            dp = new DataProxy();
            showDB = new ObservableCollection<Entry>();
            dataDB = new List<Entry>();
            DtTo = DateTime.Today;
            DtFrom = DateTime.Today;
            DataContext = this;
            //ShowDB.Add(new Entry("1", 3200, "SRB"));
            InitializeComponent();
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (datePickerFrom.SelectedDate != null && datePickerTo != null)
                {
                    if (datePickerFrom.SelectedDate > datePickerTo.SelectedDate)
                    {
                        datePickerFrom.BorderThickness = new Thickness(3);
                        datePickerFrom.BorderBrush = Brushes.Red;
                        datePickerTo.BorderThickness = new Thickness(3);
                        datePickerTo.BorderBrush = Brushes.Red;
                        lblGreska.Content = "DateFrom must not be greater than DateTo or DateTo must not be greater than DateFrom!";
                        btnShow.IsEnabled = false;
                    }
                    else
                    {
                        datePickerTo.BorderThickness = new Thickness(1);
                        datePickerTo.BorderBrush = Brushes.Gray;
                        datePickerFrom.BorderThickness = new Thickness(1);
                        datePickerFrom.BorderBrush = Brushes.Gray;
                        lblGreska.Content = "";
                        btnShow.IsEnabled = true;
                    }
                }
            }
            catch { }
        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(0);
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown(0);
        }

        private void Button_Click_Show(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine(DtFrom.ToString("dd.MM.yyy"));
            //var data = dp.requestData(DtFrom.ToString("dd.MM.yyy"), DtTo.ToString("dd.MM.yyy"));
            //dataDB = dp.requestData(DateTime.Parse("05.06.2018"), DateTime.Parse("06.06.2018"));
            dataDB = dp.requestData(DateTime.Parse(DtFrom.ToString("dd.MM.yyy")), DateTime.Parse(DtTo.ToString("dd.MM.yyy")));
            //Console.WriteLine("DEBUG");
            //Console.WriteLine(data);
            //ShowDB = data;
            foreach (var item in dataDB)
            {
                ShowDB.Add(item);
                Console.WriteLine(item);
            }
            Console.WriteLine(showDB.Count);
        }
    }
}
