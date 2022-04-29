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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private readonly UserRepository userRepository;
        public static bool isLogin = false;
        public static User currentUser;
        public MainWindow main { get; set; }
        public Login()
        {
            userRepository = new();
            InitializeComponent();
        }

        private void OpenProfile(object sender, EventArgs e)
        {
            var window = (MainWindow)Application.Current.MainWindow;
            window.load_frame3.Content = new Pr();
            window.load_frame3.Visibility = Visibility.Visible;
        }

        private void uuu(object sender, MouseButtonEventArgs e)
        {

            var window = (MainWindow)Application.Current.MainWindow;
            window.load_frame3.Content = new Registration();
            window.load_frame3.Visibility = Visibility.Visible;

        }

        private void CloseUserProfile(object sender, EventArgs e)
        {
            _ = NavigationService.Navigate(null);
        }

        private void OpenProfile(object sender, RoutedEventArgs e)
        {
            currentUser = userRepository.LoginUser(gmail.Text, password.Password.ToString());
            if (currentUser != null)
            {
                isLogin = true;
                _ = NavigationService.Navigate(null);
            }
            else
            {
                MessageBox.Show("Տվյալ Մուտքանունով և գաղտնաբառով տվյալներ չկան");
            }
        }

        private void facebook(object sender, RoutedEventArgs e)
        {
            gmail.Text = "mss.sandadze@gmail.com";
            password.Password = "12345678";
        }
    }
}
