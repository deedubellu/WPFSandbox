using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using FlightCentre.TudFaregateProvider.Common;

namespace BindingCombobox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PassengerBaggageInfo passengerBaggageInfo { get; set; }
        public ObservableCollection<BaggageOption> MyBaggageOptions = createBaggageOptions();
        public MainWindow()
        {
            InitializeComponent();

            passengerBaggageInfo = new PassengerBaggageInfo
            {
                SelectedBaggageCode = "3a",
                BaggageOptions = createBaggageOptions()
            };
        }

        private static List<PassengerInfo> createPassengers()
        {
            List<PassengerInfo> travelers = new List<PassengerInfo>();
            travelers.Add(new PassengerInfo(DateTime.Now.AddDays(30))
            {
                
                TravellerFirstName = "firstn",
                TravellerSurname = "lastn",
                TravellerTitle = "Miss",
                Key = Guid.NewGuid().ToString()
            });
            travelers.Add(new PassengerInfo(DateTime.Now.AddDays(30))
            {
                TravellerFirstName = "childn",
                TravellerSurname = "lastn",
                TravellerTitle = "Dr",
                Key = Guid.NewGuid().ToString()
            });
            return travelers;
        }

        private static ObservableCollection<BaggageOption> createBaggageOptions()
        {
            ObservableCollection<BaggageOption> baggageOptions = new ObservableCollection<BaggageOption>
            {
                new BaggageOption
                {
                    AllowedPieces = 1,
                    Code = "1a",
                    Description = "First Item",
                    ID = 1,
                    Key = "1",
                    MaxWeight = 10,
                    Name = "Item 1",
                    Price = 10,
                    Tax = 1
                },
                new BaggageOption
                {
                    AllowedPieces = 1,
                    Code = "2a",
                    Description = "Second Item",
                    ID = 2,
                    Key = "2",
                    MaxWeight = 20,
                    Name = "Item 2",
                    Price = 20,
                    Tax = 1
                },
                new BaggageOption
                {
                    AllowedPieces = 1,
                    Code = "3a",
                    Description = "Third Item",
                    ID = 3,
                    Key = "3",
                    MaxWeight = 30,
                    Name = "Item 3",
                    Price = 30,
                    Tax = 1
                }
            };
            return baggageOptions;
        }

        private void Bind1_Click(object sender, RoutedEventArgs e)
        {
            Combo1.DataContext = passengerBaggageInfo;
            TestDataGrid.ItemsSource = new List<PassengerBaggageInfo> {passengerBaggageInfo};
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Combo1.SelectedItem != null)
                //MessageBox.Show(((BaggageOption) Combo1.SelectedItem).Code);
                MessageBox.Show(passengerBaggageInfo.SelectedBaggageCode);
        }

        private void DataGridComboSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combo = (ComboBox)sender;

            BaggageOption option = combo.SelectedItem as BaggageOption;
            PassengerBaggageInfo currentPassengerInfo = ((PassengerBaggageInfo)TestDataGrid.SelectedItem);

            string code = option.Code;
            decimal price = option.Price;
            decimal tax = option.Tax;
            decimal weight = option.MaxWeight;

            currentPassengerInfo.SelectedBaggageCode = code;
            currentPassengerInfo.Price = price;
            currentPassengerInfo.Tax = tax;
            currentPassengerInfo.MaxWeight = weight;
        }
    }
}
