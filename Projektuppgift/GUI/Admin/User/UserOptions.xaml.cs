using GUI.Admin.Employer;
using GUI.Admin.Home;
using GUI.Login;
using GUI.Tools;
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

namespace GUI.Admin.User
{
    /// <summary>
    /// Interaction logic for UserOptions.xaml
    /// </summary>
    public partial class UserOptions : Page
    {
        public UserOptions()
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
            LogginPage logginPage = new LogginPage();
            this.NavigationService.Navigate(logginPage);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddUser addUser = new AddUser();
            this.NavigationService.Navigate(addUser);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            EmployerOptions employerOptions = new EmployerOptions();
            this.NavigationService.Navigate(employerOptions);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //-----------------------------------------------------------------Navigition till verkstad!
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //--------------------------------------------------------------Nyheter För framtid
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            ChangeUserAccount changeUserAccount = new ChangeUserAccount();
            this.NavigationService.Navigate(changeUserAccount);
        }
    }
}
