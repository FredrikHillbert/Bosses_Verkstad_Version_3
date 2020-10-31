﻿using GUI.Admin.Employer;
using GUI.Admin.Home;
using GUI.Admin.Workshop;
using GUI.Login;
using GUI.Tools;
using Logic.Interface;
using Logic.Services;
using Logic.Services.MechanicServices___ADMIN;
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
         
            IuserLogin checkIfValid = new LoginService();
            ImechanicLogin mechanic = new MechanicService();

            if (checkIfValid.CheckIfLoginIsValid(NewUser.Text, CreatPassword.Password, MatchPassword.Password, userId.Text)&& (mechanic.ActivUser(userId.Text)))
            {
                //Kolla om användare finns Lägg till i samma dic som  användare
                checkIfValid.CreateNewUser(NewUser.Text, CreatPassword.Password, userId.Text);
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
            if (userId.Text == "Anställnings-ID") { userId.Text = StringTools._emtyString;}
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
            CaseOptions caseOptions = new CaseOptions();
            this.NavigationService.Navigate(caseOptions);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            EmployerOptions employerOptions = new EmployerOptions();
            this.NavigationService.Navigate(employerOptions);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            CaseOption userOptions = new CaseOption();
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
