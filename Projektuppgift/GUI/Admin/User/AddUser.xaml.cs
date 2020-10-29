using GUI.Admin.Employer;
using GUI.Admin.Home;
using GUI.Login;
using GUI.Tools;
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

namespace GUI.Admin.User
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Page
    {
        
        public AddUser()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Om mail, 2 matchande lösenord, id nummer korrekt
            //Spara i lista
            LoginService checkIfValid = new LoginService();

            if (checkIfValid.CheckIfLoginIsValid(NewUser.Text, CreatPassword.Password, MatchPassword.Password,userId.Text))
            {
                checkIfValid.CreatNewUser(NewUser.Text, CreatPassword.Password);
                MessageBox.Show("Användarekonto är nu tillagt!", "", MessageBoxButton.OK);
                NewUser.Text = "Användarnamn";
                userId.Text = "Användar-ID";
                CreatPassword.Password = "Password";
                MatchPassword.Password = "Password";

            }
            else
            {
                MessageBox.Show(StringTools._inputError, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                NewUser.Text = "Användarnamn";
                userId.Text = "Användar-ID";
                CreatPassword.Password = "Password";
                MatchPassword.Password ="Password";
            }


        }

        private void NewUser_GotFocus(object sender, RoutedEventArgs e)
        {
            if (NewUser.Text == "Användarnamn") {NewUser.Text = StringTools._emtyString;}
        }

        private void userId_GotFocus(object sender, RoutedEventArgs e)
        {
            if (userId.Text == "Användar-ID") { userId.Text = StringTools._emtyString;}
        }

        private void CreatPassword_GotFocus(object sender, RoutedEventArgs e)
        {
           
                if (CreatPassword.Password == "Password") { CreatPassword.Password = StringTools._emtyString; }
              
        }

        private void MatchPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (MatchPassword.Password == "Password"){MatchPassword.Password = StringTools._emtyString;}
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LogginPage logginPage = new LogginPage();
            this.NavigationService.Navigate(logginPage);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //--------------------------------------------------------------Nyheter För framtid
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //-----------------------------------------------------------------Navigition till verkstad!
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            EmployerOptions employerOptions = new EmployerOptions();
            this.NavigationService.Navigate(employerOptions);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            UserOptions userOptions = new UserOptions();
            this.NavigationService.Navigate(userOptions);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            HomePageAdmin homePageAdmin = new HomePageAdmin();
            this.NavigationService.Navigate(homePageAdmin);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            ChangeUserAccount changeUserAccount = new ChangeUserAccount();
            this.NavigationService.Navigate(changeUserAccount);
        }
    }
}
