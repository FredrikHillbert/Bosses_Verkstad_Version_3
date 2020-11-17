using GUI.Login;
using GUI.Mechanics.Home;
using GUI.Mechanics.User;
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

namespace GUI.Mechanics.Workshop
{
    /// <summary>
    /// Interaction logic for AllCaseMechanic.xaml
    /// </summary>
    public partial class AllCaseMechanic : Page
    {
        public AllCaseMechanic()
        {
            InitializeComponent();
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            //List<string> DeklareraLista = new List<string>();
            //ILogic adminService = new AdminService();
            //DeklareraLista = adminService.GetActivUser();
            //var combo = sender as ComboBox;
            //combo.ItemsSource = DeklareraLista;
            //combo.SelectedIndex = 0;


            //Funktion visa alla avslutade jobb
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HomePageMechanic homePageMechanic = new HomePageMechanic();
            this.NavigationService.Navigate(homePageMechanic);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile();
            this.NavigationService.Navigate(profile);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CaseOptionMechanics caseOptionMechanic = new CaseOptionMechanics();
            this.NavigationService.Navigate(caseOptionMechanic);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            LogginPage logginPage = new LogginPage();
            this.NavigationService.Navigate(logginPage);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ActivCaseMechanic activCaseMechanic = new ActivCaseMechanic();
            this.NavigationService.Navigate(activCaseMechanic);
        }
    }
}
