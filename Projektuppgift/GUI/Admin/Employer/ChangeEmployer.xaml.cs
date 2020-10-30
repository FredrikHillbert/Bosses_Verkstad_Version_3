using GUI.Admin.Home;
using GUI.Admin.User;
using GUI.Admin.Workshop;
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

namespace GUI.Admin.Employer
{
    /// <summary>
    /// Interaction logic for ChangeEmployer.xaml
    /// </summary>
    public partial class ChangeEmployer : Page
    {
        public ChangeEmployer()
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
            CaseOptions caseOptions = new CaseOptions();
            this.NavigationService.Navigate(caseOptions);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            EmployerOptions employerOptions = new EmployerOptions();
            this.NavigationService.Navigate(employerOptions);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            CaseOption userOptions = new CaseOption();
            this.NavigationService.Navigate(userOptions);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            AddEmployer addEmployer = new AddEmployer();
            this.NavigationService.Navigate(addEmployer);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            LogginPage logginPage = new LogginPage();
            this.NavigationService.Navigate(logginPage);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            //----------------------------------------------------------------Sök efter Anställd, koppla till konto eller ta bort, koppla till textbo samt koppla kompetens till radiobuttom.

        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            //--------------------------------------------------------------Vissa all anställda
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            //--------------------------------------------------------------Funktion koppla användar-id med anställnings-id
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            //-------------------------------------------------------------Funktion ta bort koppling mellan användar-id med anställnings-id
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            //------------------------------------------------------------Ändra Information om anställd, 
        }

        private void employerIdSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            if (employerIdSearch.Text == "Anställnings-ID") { employerIdSearch.Text = StringTools._emtyString; }
        }

      
        private void firstName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (firstName.Text == "Namn") { firstName.Text = StringTools._emtyString; }
        }

        private void lastname_GotFocus(object sender, RoutedEventArgs e)
        {
            if (lastname.Text == "Efternamn") { lastname.Text = StringTools._emtyString; }
        }

        private void dateOfBirth_GotFocus(object sender, RoutedEventArgs e)
        {
            if (dateOfBirth.Text == "Födelsedatum") { dateOfBirth.Text = StringTools._emtyString; }
        }

        private void dateOfEmployment_GotFocus(object sender, RoutedEventArgs e)
        {
            if (dateOfEmployment.Text == "Anställningdatum") { dateOfEmployment.Text = StringTools._emtyString; }
        }

        private void employerId_GotFocus(object sender, RoutedEventArgs e)
        {
            if (employerId.Text == "Anställnings-ID") { employerId.Text = StringTools._emtyString; }
        }
    }
}
