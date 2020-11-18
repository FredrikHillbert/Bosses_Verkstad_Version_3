using GUI.Admin.Home;
using GUI.Admin.User;
using GUI.Admin.Employer;
using GUI.Login;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Logic.Interface;
using Logic.Services;
using Logic.Entities;
using GUI.Tools;

namespace GUI.Admin.Workshop
{
    /// <summary>
    /// Interaction logic for AddCase.xaml
    /// </summary>
    public partial class AddCase : Page
    {
        readonly Orders orders = new Orders();
        string valueOfVehicle;
        string valueOfMechanic;
        List<string> listOfMechanics = new List<string>();
        ILogic adminService = new AdminService();
        IValid valid = new ValidService();

        public AddCase()
        {
            InitializeComponent();
        }
        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            LogginPage logginPage = new LogginPage();
            this.NavigationService.Navigate(logginPage);
        }
        private void Button_Start(object sender, RoutedEventArgs e)
        {
            HomePageAdmin homePageAdmin = new HomePageAdmin();
            this.NavigationService.Navigate(homePageAdmin);
        }

        private void Button_Dela(object sender, RoutedEventArgs e) //Till ChangeCase
        {
            ChangeCase changeCase = new ChangeCase();
            this.NavigationService.Navigate(changeCase);
        }

        private void Button_Workshop(object sender, RoutedEventArgs e) //Till CaseOptions (om man vill rensa)
        {
            CaseOptions caseOptions = new CaseOptions();
            this.NavigationService.Navigate(caseOptions);
        }

        private void Button_List(object sender, RoutedEventArgs e)
        {
            EmployerOptions employerOptions = new EmployerOptions();
            this.NavigationService.Navigate(employerOptions);
        }

        private void Button_Users(object sender, RoutedEventArgs e) //Dras til UserOptions. Kallas CaseOption..
        {
            CaseOption userOptions = new CaseOption();
            this.NavigationService.Navigate(userOptions);
        }

        private void Bromsar_Checked(object sender, RoutedEventArgs e)
        {
            orders.Brakes = true;
            if (Bromsar.IsChecked == true)
            {
                string value = "Brakes";
                RefreshMethod(value);
            }
            cbxMechanic.Items.Refresh();
        }

        private void Tire_Checked(object sender, RoutedEventArgs e)
        {
            orders.Tire = true;
            if (Tire.IsChecked == true)
            {
                string value = "Tires";
                RefreshMethod(value);
            }
            cbxMechanic.Items.Refresh();
        }

        private void Vindrutor_Checked(object sender, RoutedEventArgs e)
        {
            orders.BrokeWindow = true;
            if (vindrutor.IsChecked == true)
            {
                string value = "Window";
                RefreshMethod(value);
            }
            cbxMechanic.Items.Refresh();
        }



        private void Motor_Checked(object sender, RoutedEventArgs e)
        {
            orders.Engine = true;
            if (Motor.IsChecked == true)
            {
                string value = "Engine";
                RefreshMethod(value);
            }
            cbxMechanic.Items.Refresh();
        }

        private void Kaross_Checked(object sender, RoutedEventArgs e)
        {
            orders.Kaross = true;
            if (Kaross.IsChecked == true)
            {
                string value = "Kaross";
                RefreshMethod(value);
            }
            cbxMechanic.Items.Refresh();
        }

        private void ComboBoxVehicle_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> listOfVehicles = new List<string>();
            
            listOfVehicles = adminService.GetVehicles();
            var combo = sender as ComboBox;
            combo.ItemsSource = listOfVehicles;
            combo.SelectedIndex = 0;
        }



        private void ButtonSAVE_Click(object sender, RoutedEventArgs e) 
        {

          
            List<Orders> newOrder = new List<Orders>();

            string mechanicID = adminService.MehanicID();

            if (valid.ValidOrder(orderDesc.Text, valueOfVehicle, valueOfMechanic,
                                        ModelName.Text, RegNum.Text, matare.Text, dateOfReg.Text, orders.Fuel, specificQ.Text, specificQ2.Text, orderID.Text))
            {
                newOrder.Add(new Orders( orderDesc.Text, orders.Brakes, orders.BrokeWindow, orders.Engine, orders.Kaross, orders.Tire, valueOfVehicle, valueOfMechanic,
                                        ModelName.Text, RegNum.Text, matare.Text, dateOfReg.Text, orders.Fuel, specificQ.Text, specificQ2.Text, orderID.Text, mechanicID));

               
                adminService.NewOrder(orderID.Text, newOrder);
                adminService.GiveMechanicOrder(mechanicID, newOrder);
                MessageBox.Show("Ett nytt ärende är nu tillagt!", "", MessageBoxButton.OK);
                CaseOptions caseOptions = new CaseOptions();
                this.NavigationService.Navigate(caseOptions);
            }
            else
            {
                MessageBox.Show(StringTools._inputError, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        private void cboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string valueOfVehicleSelected = cboType.SelectedItem.ToString();
            valueOfVehicle = valueOfVehicleSelected;

           if (valueOfVehicleSelected == "Bil")
            {
                specificQ.Visibility = Visibility.Hidden; //Hides Biltyp's textbox for this vehicle.
                specificQ2.Visibility = Visibility.Hidden; //Hides Dragkrok's textbox for all vehicles (It is not repeated)
                cartypelabel.Visibility = Visibility.Visible; //Reveals from cartypelabel to cartowbarcombo. 1/3
                cartypecombo.Visibility = Visibility.Visible; //It is repeated in other selected vehicles- 2/3
                cartowbarlabel.Visibility = Visibility.Visible; //in order to hide them when deselecting from Bil. 3/3
                cartowbarcombo.Visibility = Visibility.Visible;
                specificQ.Text = cartypecombo.SelectedValue.ToString();
                specificQ2.Text = cartowbarcombo.SelectedValue.ToString();

            }
            else if (valueOfVehicleSelected == "Motorcykel")
            {
                specificQ.Visibility = Visibility.Hidden;
                cartypelabel.Visibility = Visibility.Hidden;
                cartypecombo.Visibility = Visibility.Hidden;
                cartowbarlabel.Visibility = Visibility.Hidden;
                cartowbarcombo.Visibility = Visibility.Hidden;
                specificQ.Text = "--------------";
                specificQ2.Text = "-------------";

            }
            else if (valueOfVehicleSelected == "Lastbil")
            {

                specificQ.Visibility = Visibility.Visible;
                cartypelabel.Visibility = Visibility.Hidden;
                cartypecombo.Visibility = Visibility.Hidden;
                cartowbarlabel.Visibility = Visibility.Hidden;
                cartowbarcombo.Visibility = Visibility.Hidden;
                specificQ.Text = "Vad är maxlast på lastbilen?";
                specificQ2.Text = "-------------";

            }
            else if (valueOfVehicleSelected == "Buss")
            {

                specificQ.Visibility = Visibility.Visible;
                cartypelabel.Visibility = Visibility.Hidden;
                cartypecombo.Visibility = Visibility.Hidden;
                cartowbarlabel.Visibility = Visibility.Hidden;
                cartowbarcombo.Visibility = Visibility.Hidden;
                specificQ.Text = "Hur många passagerare tar bussen?";
                specificQ2.Text = "-------------";

            }

        }
        private void RefreshMethod(string value)
        {
            listOfMechanics = adminService.GetMechanicForTheJob(value);
            if(listOfMechanics.Count == 0)
            {
                listOfMechanics.Add("Finns inga mekaniker för jobbet.");

            }
            cbxMechanic.ItemsSource = listOfMechanics;
            cbxMechanic.SelectedItem = orders.Mechanic;
            cbxMechanic.Items.Refresh();
        }

        private void el_Checked(object sender, RoutedEventArgs e)
        {
            orders.Fuel = "El";
        }

        private void gasoline_Checked(object sender, RoutedEventArgs e)
        {
            orders.Fuel = "Bensin";
        }

        private void etanol_Checked(object sender, RoutedEventArgs e)
        {
            orders.Fuel = "Etanol";
        }

        private void diesel_Checked(object sender, RoutedEventArgs e)
        {
            orders.Fuel = "Diesel";
        }

        private void cbxMechanic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string valueOfMechanicSelected = cbxMechanic.SelectedItem.ToString();
            valueOfMechanic = valueOfMechanicSelected;

        }
        private void cartypecombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cartowbarcombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AllCase allCase = new AllCase();
            this.NavigationService.Navigate(allCase);
        }
    }
}

