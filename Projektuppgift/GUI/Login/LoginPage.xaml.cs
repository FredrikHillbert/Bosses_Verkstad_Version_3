using GUI.Admin.Home;
using Logic.Interface;
using Logic.Services;
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


namespace GUI.Login
{
    /// <summary>
    /// Interaction logic for LogginPage.xaml
    /// </summary>
    public partial class LogginPage : Page
    {
        public LogginPage()
        {
            InitializeComponent();
        }

        private void LoginUserName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (LoginUserName.Text == "Användarnamn")
            {
                LoginUserName.Text = "";
            }
        }

        private void LoginPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (LoginPassword.Password == "Password")
            {
                LoginPassword.Password = "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string inputError = "Felaktigt användarnamn/lösenord!";
            string loggin = LoginUserName.Text;
            string password = LoginPassword.Password;
            IuserLogin iuserLogin = new LoginService();
          
            if (iuserLogin.Login(loggin, password))
            {
                HomePageAdmin homePageAdmin = new HomePageAdmin();
                this.NavigationService.Navigate(homePageAdmin);
            }
            else
            {
                MessageBox.Show(inputError, "Error", MessageBoxButton.OK, MessageBoxImage.Warning); 
            }
        }
    }
}
