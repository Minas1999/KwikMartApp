using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for CardPage.xaml
    /// </summary>
    public partial class CardPage : UserControl
    {
        public MainWindow main { get; set; }
        public CardPage()
        {
            InitializeComponent();
            List<Products> list = new();
            for (int i = 0; i < 8; i++)
            {
                list.Add(new Products()
                {
                    name = "aaa",
                    count = 5,
                    description = "desc",
                    food_id = i,
                    id = i,
                    img_url = "url",
                    price = 20
                });
            }


            ListViewProducts.ItemsSource = list;
        }

        private void btn_Back(object sender, RoutedEventArgs e)
        {
            full.Visibility = Visibility.Collapsed;
            main.Change();
        }


        private void resetPrice()
        {

        }



        private void Open_Facebook(object sender, EventArgs e)
        {

            var psi = new ProcessStartInfo
            {
                FileName = "https://www.facebook.com",

                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void Open_Instagram(object sender, EventArgs e)
        {

            var psi = new ProcessStartInfo
            {
                FileName = "https://www.instagram.com/",

                UseShellExecute = true
            };
            Process.Start(psi);
        }


        private void Open_Twitter(object sender, RoutedEventArgs e)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "https://www.twitter.com/",

                UseShellExecute = true
            };
            Process.Start(psi);
        }



        private void History(object sender, RoutedEventArgs e)
        {

        }

        private void OrderButton(object sender, RoutedEventArgs e)
        {
            Box b = new Box();
            b.Show();
        }
    }
}
