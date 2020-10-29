using GUI.Admin.Home;
using GUI.Tools;
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

     //-------------------------------------------------------------------------------Lägg till knapp för att avsluta
        public LogginPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// If Textbox got focus = Emty string
        /// </summary>
        private void LoginUserName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (LoginUserName.Text == "Användarnamn") {LoginUserName.Text = StringTools._emtyString;}
        }

        /// <summary>
        /// If Passwordbox got focus = Emty string
        /// </summary>   
        private void LoginPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (LoginPassword.Password == "Password"){LoginPassword.Password = StringTools._emtyString;}
        }

        /// <summary>
        /// If Username and password is correct, iuserLogin.Login(loggin, password)==True.
        /// Else Username and password is incorrect, messagebox shows
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            var loggin = LoginUserName.Text;
            var password = LoginPassword.Password;


            IuserLogin iuserLogin = new LoginService();
          
            if (iuserLogin.Login(loggin, password))
            {
                HomePageAdmin homePageAdmin = new HomePageAdmin();
                this.NavigationService.Navigate(homePageAdmin);
            }
            else
            {
                MessageBox.Show(StringTools._inputError, "Error", MessageBoxButton.OK, MessageBoxImage.Warning); 
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
