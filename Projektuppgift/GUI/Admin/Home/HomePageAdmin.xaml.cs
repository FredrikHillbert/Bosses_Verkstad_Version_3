﻿using GUI.Admin.User;
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

namespace GUI.Admin.Home
{
    /// <summary>
    /// Interaction logic for HomePageAdmin.xaml
    /// </summary>
    public partial class HomePageAdmin : Page
    {
        public HomePageAdmin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserOptions userOptions = new UserOptions();
            this.NavigationService.Navigate(userOptions);      
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LogginPage logginPage = new LogginPage();
            this.NavigationService.Navigate(logginPage);
        }
    }
}