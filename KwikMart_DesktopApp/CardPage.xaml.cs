using DataAccess.Models;
using DataAccess.Repositoryes;
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
        OneProduct oneProduct { get; set; }

        ProductRepository productRepository = new();
        OrderRepository orderRepository = new();
        List<Products> productsList = new();
        public CardPage()
        {
            InitializeComponent();
            List<Products> list = new();

            productsList = productRepository.GetProductsToBasket();

            int sum = 0;
            foreach (var item in productsList)
            {
                sum += item.price;
            }

            fullPrice.Text = sum.ToString();
            ListViewProducts.ItemsSource = productsList;
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
            object product = (sender as Button).Tag;
            var a = product as Products;
            var id = (product as Products).food_id;
            MessageBox.Show(id.ToString());
            List<Products> temp = new();
            foreach (var item in productsList)
            {
                if (item.food_id == id)
                {
                    //productsList.Remove(item);

                    temp.Add(item);
                }
            }

            foreach (var item in temp)
            {
                productsList.Remove(item);
            }
            ListViewProducts.ItemsSource = null;
            ListViewProducts.ItemsSource = productsList;
        }

        private void OrderButton(object sender, RoutedEventArgs e)
        {
            var orderID = orderRepository.CreaetOrder(Login.currentUser.Id);
            var list = productRepository.GetProductsToBasket();

            foreach (var item in list)
            {
                orderRepository.CreateUserOrderFoodsTable(orderID, item.food_id, item.count);
            }

            Box b = new Box();
            b.Show();

            productRepository.ClearProductsFromBasket();
            ListViewProducts.ItemsSource = null;
        }
    }
}
