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
using Logic.Entities;

namespace GUI.Admin.Workshop
{
    /// <summary>
    /// Interaction logic for AddCase.xaml
    /// </summary>
    public partial class AddCase : Page
    {
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

        private void Add(object sender, RoutedEventArgs e) //Lägger till Ärendet i listan
        {

            List<Orders> ListOfOrder = new List<Orders>();

           // while(Allt är ifyllt (Desc.Text = value; && Id.Text = value))
            {
                ListOfOrder.Add(new Order(Desc.Text, Id.Text,
                                                    (bool)Broms.IsChecked, (bool)Motor.IsChecked, (bool)Tire.IsChecked,
                                                    (bool)vindrutor.IsChecked, (bool)Kaross.IsChecked));

              

                
                MessageBox.Show("Ärende är nu tillagt!", "", MessageBoxButton.OK);
            }

        }

      
    }
}
