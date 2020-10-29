using GUI.Admin.Home;
using GUI.Admin.User;
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

namespace GUI.Admin.Employer
{
    /// <summary>
    /// Interaction logic for EmployerOptions.xaml
    /// </summary>
    public partial class EmployerOptions : Page
    {
        public EmployerOptions()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HomePageAdmin homePageAdmin = new HomePageAdmin();
            this.NavigationService.Navigate(homePageAdmin);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //--------------------------------------------------------------Nyheter För framtid
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //-----------------------------------------------------------------Navigition till verkstad!
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            UserOptions userOptions = new UserOptions();
            this.NavigationService.Navigate(userOptions);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            AddEmployer addEmployer = new AddEmployer();
            this.NavigationService.Navigate(addEmployer);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            ChangeEmployer changeEmployer = new ChangeEmployer();
            this.NavigationService.Navigate(changeEmployer);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            //---------------------------------------------------------------------Övrigt?
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            LogginPage logginPage = new LogginPage();
            this.NavigationService.Navigate(logginPage);
        }
    }
}
