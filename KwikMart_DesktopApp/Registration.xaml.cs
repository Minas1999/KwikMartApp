using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KwikMart_DesktopApp
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        private readonly UserRepository userRepository;
        public Registration()
        {
            this.userRepository = new();
            InitializeComponent();
        }

        private void CloseUserProfile(object sender, EventArgs e)
        {
            _ = NavigationService.Navigate(null);
        }

        private void GetCurrentLocation(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("ok");
        }



        private void Registration1(object sender, RoutedEventArgs e)
        {
            if (userRepository.Registration(name.Text, phone.Text, userGmail.Text, address.Text, password.Password.ToString()))
            {
                if(userRepository.LoginUser(userGmail.Text, password.Password.ToString()) != null)
                {
                    Login.isLogin = true;
                    MessageBox.Show("Շնորհակալություն գրանցվելու համար");
                }
            }
            _ = NavigationService.Navigate(null);
        }
    }
}
