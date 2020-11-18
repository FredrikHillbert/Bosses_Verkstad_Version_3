using System;
using GUI.Admin.Home;
using GUI.Admin.User;
using GUI.Login;
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
using GUI.Admin.Employer;
using Logic.Interface;
using Logic.Services;
using Logic.Entities;
using GUI.Tools;
using Logic.DAL;

namespace GUI.Admin.Workshop
{
    /// <summary>
    /// Interaction logic for ChangeCase.xaml
    /// </summary>
    public partial class ChangeCase : Page
    {
        Orders order = new Orders();
        List<string> listOfVehicles = new List<string>();
        List<string> listOfMechanics = new List<string>();
        string valueOfVehicle;
        string valueOfMechanic;
        ILogic adminService = new AdminService();
        IValid valid = new ValidService();
        string notCorrectid;
        public ChangeCase()
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

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            AddCase addCase = new AddCase();
            this.NavigationService.Navigate(addCase);
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

        private void Button_ClickSearchOrder(object sender, RoutedEventArgs e)
        {
            

            if ((valid.ActivOrder(OrderIdSearch.Text))) 
            {
                List<Orders> listOfSpecificOrder = adminService.GetOrder(OrderIdSearch.Text);
                foreach (var item in listOfSpecificOrder)
                {
                    orderID.Text = OrderIdSearch.Text;
                    orderDesc.Text = item.OrderDescription;
                    ModelName.Text = item.ModelName;
                    RegNum.Text = item.RegNumber;
                    dateOfReg.Text = item.RegDate;
                    matare.Text = item.Matare;
                    specificQ.Text = item.SpecificQuestionAboutVehicle1;
                    specificQ2.Text = item.SpecificQuestionAboutVehicle2;
                    Motor.IsChecked = item.Engine;
                    Däck.IsChecked = item.Tire;
                    Vindrutor.IsChecked = item.BrokeWindow;
                    Bromsar.IsChecked = item.Brakes;
                    Kaross.IsChecked = item.Kaross;
                    cboType.SelectedItem = item.TypeOfVehicle;
                    currentMehanic.Content = item.Mechanic;
                    cbxMechanic.SelectedItem = item.Mechanic;
                   
                  

                    if (item.Fuel == "El")
                    {
                        el.IsChecked = true;
                    }
                    else if (item.Fuel == "Bensin")
                    {
                        gasoline.IsChecked = true;
                    }
                    else if (item.Fuel == "Etanol")
                    {
                        etanol.IsChecked = true;
                    }
                    else if (item.Fuel == "Diesel")
                    {
                        diesel.IsChecked = true;
                    }

                    

                }
            }
            else
            {
                MessageBox.Show(StringTools._inputError, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);

            }


            cboType.Items.Refresh();
            
        }

        private void Button_Bort(object sender, RoutedEventArgs e)
        {
            

            if ((valid.ActivOrder(OrderIdSearch.Text)))
            {

                if (MessageBox.Show("Är du säker på att du vill ta bort ärendet?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                   
                    adminService.DeleteOrder(OrderIdSearch.Text);
                    
                    
                }


            }
            else
            {
                MessageBox.Show(StringTools._inputError, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            ChangeCase changeCase = new ChangeCase();
            this.NavigationService.Navigate(changeCase);
        }


        private void Button_Click_ChangeCase(object sender, RoutedEventArgs e)
        {


            List<Orders> newOrder = new List<Orders>();
            

            if (OrderIdSearch.Text == orderID.Text)
            {
                notCorrectid = orderID.Text;
                orderID.Text = "Error Meddelande.1111111.AzaAza.@@.Error";
            }



            if (valid.ValidOrder(orderDesc.Text, valueOfVehicle, valueOfMechanic, ModelName.Text, RegNum.Text, matare.Text, dateOfReg.Text, order.Fuel, specificQ.Text, specificQ2.Text, orderID.Text))
            {
                if (orderID.Text == "Error Meddelande.1111111.AzaAza.@@.Error")
                {
                    orderID.Text = notCorrectid;
                }
                if (valid.ActivOrder(orderID.Text))
                {
                    string mechanicID = adminService.MehanicID();

                    if (mechanicID == String.Empty)
                    {
                        
                        foreach ( var item in ActivClasses.orderDictionary[orderID.Text])
                        {
                            mechanicID = item.MechanicID;

                        }
                    }
                    adminService.DeleteOrder(orderID.Text);

                    

                    newOrder.Add(new Orders(orderDesc.Text, order.Brakes, order.BrokeWindow, order.Engine, order.Kaross, order.Tire, valueOfVehicle, valueOfMechanic,
                                            ModelName.Text, RegNum.Text, matare.Text, dateOfReg.Text, order.Fuel, specificQ.Text, specificQ2.Text, orderID.Text, mechanicID));


                    adminService.NewOrder(orderID.Text, newOrder);
                    adminService.GiveMechanicOrder(mechanicID, newOrder);
                    MessageBox.Show("Ärendet är ändrat!", "", MessageBoxButton.OK);
                    ChangeCase changeCase = new ChangeCase();
                    this.NavigationService.Navigate(changeCase);

                }
                else
                {
                    MessageBox.Show(StringTools._inputError, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show(StringTools._inputError, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


        }



        private void Bromsar_Checked(object sender, RoutedEventArgs e)
        {
            order.Brakes = true;
            string value = "Brakes";
            RefreshMethod(value);
        }

        private void Däck_Checked(object sender, RoutedEventArgs e)
        {
            order.Tire = true;
            string value = "Tires";
            RefreshMethod(value);
        }

        private void Vindruta_Checked(object sender, RoutedEventArgs e)
        {
            order.BrokeWindow = true;
            string value = "Window";
            RefreshMethod(value);
        }

        private void Motor_Checked(object sender, RoutedEventArgs e)
        {
            order.Engine = true;
            string value = "Engine";
            RefreshMethod(value);
        }

        private void Kaross_Checked(object sender, RoutedEventArgs e)
        {
            order.Kaross = true;
            string value = "Kaross";
            RefreshMethod(value);
        }


        private void ComboBoxVehicle_Loaded(object sender, RoutedEventArgs e)
        {

            ILogic adminService = new AdminService();
            listOfVehicles = adminService.GetVehicles();
            var combo = sender as ComboBox;
            combo.ItemsSource = listOfVehicles;
            if (order.TypeOfVehicle == "Bil")
                combo.SelectedIndex = 0;
            else if (order.TypeOfVehicle == "Buss")
                combo.SelectedIndex = 1;
            else if (order.TypeOfVehicle == "Lastbil")
                combo.SelectedIndex = 2;
            else if (order.TypeOfVehicle == "Motorcykel")
                combo.SelectedIndex = 3;
            cboType.ItemsSource = listOfVehicles;
            cbxMechanic.Items.Refresh();
        }



        private void cboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string valueOfVehicleSelected = cboType.SelectedItem.ToString();
            valueOfVehicle = valueOfVehicleSelected;
            //if (valueOfVehicleSelected == "Bil")
            //{
            //    specificQ.Visibility = Visibility.Hidden; //Hides Biltyp's textbox for this vehicle.
            //    specificQ2.Visibility = Visibility.Hidden; //Hides Dragkrok's textbox for all vehicles (It is not repeated)
            //    cartypelabel.Visibility = Visibility.Visible; //Reveals from cartypelabel to cartowbarcombo. 1/3
            //    cartypecombo.Visibility = Visibility.Visible; //It is repeated in other selected vehicles- 2/3
            //    cartowbarlabel.Visibility = Visibility.Visible; //in order to hide them when deselecting from Bil. 3/3
            //    cartowbarcombo.Visibility = Visibility.Visible;
            //    specificQ.Text = cartypecombo.SelectedValue.ToString();
            //    specificQ2.Text = cartowbarcombo.SelectedValue.ToString();

            //}
            //else if (valueOfVehicleSelected == "Motorcykel")
            //{
            //    specificQ.Visibility = Visibility.Hidden;
            //    cartypelabel.Visibility = Visibility.Hidden;
            //    cartypecombo.Visibility = Visibility.Hidden;
            //    cartowbarlabel.Visibility = Visibility.Hidden;
            //    cartowbarcombo.Visibility = Visibility.Hidden;
            //    specificQ.Text = "--------------";
            //    specificQ2.Text = "-------------";

            //}
            //else if (valueOfVehicleSelected == "Lastbil")
            //{

            //    specificQ.Visibility = Visibility.Visible;
            //    cartypelabel.Visibility = Visibility.Hidden;
            //    cartypecombo.Visibility = Visibility.Hidden;
            //    cartowbarlabel.Visibility = Visibility.Hidden;
            //    cartowbarcombo.Visibility = Visibility.Hidden;
            //    specificQ.Text = "Vad är maxlast på lastbilen?";
            //    specificQ2.Text = "-------------";

            //}
            //else if (valueOfVehicleSelected == "Buss")
            //{

            //    specificQ.Visibility = Visibility.Visible;
            //    cartypelabel.Visibility = Visibility.Hidden;
            //    cartypecombo.Visibility = Visibility.Hidden;
            //    cartowbarlabel.Visibility = Visibility.Hidden;
            //    cartowbarcombo.Visibility = Visibility.Hidden;
            //    specificQ.Text = "Hur många passagerare tar bussen?";
            //    specificQ2.Text = "-------------";

            //}

        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {

            List<string> orderLista = new List<string>();
            ILogic adminService = new AdminService();
            orderLista = adminService.GetKeyForOrder();
            var combo = sender as ComboBox;
            combo.ItemsSource = orderLista;
            combo.SelectedIndex = 0;




        }

        private void RefreshMethod(string value)
        {
            ILogic adminService = new AdminService();
            listOfMechanics = adminService.GetMechanicForTheJob(value);
            if (listOfMechanics.Count == 0)
            {
                listOfMechanics.Add("Finns inga mekaniker för jobbet.");

            }
            cbxMechanic.ItemsSource = listOfMechanics;
            cbxMechanic.Items.Refresh();
        }

        private void cbxMechanic_Loaded(object sender, RoutedEventArgs e)
        {
            cbxMechanic.ItemsSource = listOfMechanics;
            cbxMechanic.SelectedItem = order.Mechanic;

     
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AllCase allCase = new AllCase();
            this.NavigationService.Navigate(allCase);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (valid.ActivOrder(OrderIdSearch.Text))
            {

                List<Orders> finished = adminService.finishedOrder(OrderIdSearch.Text);

                adminService.MoveFinishedOrder(finished, OrderIdSearch.Text);

                MessageBox.Show("Färdigt", "", MessageBoxButton.OK);
            }
            else { MessageBox.Show(StringTools._inputError, "Error", MessageBoxButton.OK, MessageBoxImage.Warning); }
            ChangeCase changeCase = new ChangeCase();
            this.NavigationService.Navigate(changeCase);
        }





        private void cbxMechanic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string valueOfMechanicSelected = cbxMechanic.SelectedItem.ToString();
            valueOfMechanic = valueOfMechanicSelected;
            cbxMechanic.Items.Refresh();
        }
    }
}