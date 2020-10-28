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



        }

        private void NewUser_GotFocus(object sender, RoutedEventArgs e)
        {
            if (NewUser.Text == "Användarnamn")
            {
                NewUser.Text = "";
            }
        }

        private void employerId_GotFocus(object sender, RoutedEventArgs e)
        {
            if (employerId.Text == "Anställnings ID")
            {
                employerId.Text = "";
            }
        }

        private void CreatPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CreatPassword.Password== "Password")
            {
                CreatPassword.Password = "";
            }
        }

        private void MatchPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (MatchPassword.Password == "Password")
            {
                MatchPassword.Password = "";
            }
        }
    }
}
