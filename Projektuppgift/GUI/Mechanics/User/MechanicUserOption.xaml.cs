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

namespace GUI.Mechanics.User
{
    /// <summary>
    /// Interaction logic for MechanicUserOptions.xaml
    /// </summary>
    public partial class MechanicUserOptions : Page
    {
        public MechanicUserOptions()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LogginPage logginPage = new LogginPage();
            this.NavigationService.Navigate(logginPage);
        }
    }
}
