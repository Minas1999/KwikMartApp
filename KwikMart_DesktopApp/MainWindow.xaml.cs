//using DataAccess.Models;
using DataAccess.Models;
using DataAccess.Repositoryes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace KwikMart_DesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ProductRepository productRepository;
        public MainWindow()
        {

            InitializeComponent();
            productRepository = new();

            List<Products> list = new();
            //for (int i = 0; i < 15; i++)
            //{
            //    list.Add(new Products()
            //    {
            //        name = "aaa",
            //        count = 5,
            //        description = "desc",
            //        food_id = i,
            //        id = i,
            //        img_url = "url",
            //        price = i
            //    });
            //}

            //list.Add()

            ListViewProducts.ItemsSource = productRepository.GetAllProducts();

        }

        public static void getProductsFromBasketList()
        {
            //return MainWindow.Baskets;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void pp(object sender, MouseButtonEventArgs e)
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
            Profile win2 = new Profile();
            win2.Show();
        }


        public void AddToCart(object sender, RoutedEventArgs e)
        {

            object product = (sender as Button).Tag;
            var a = product as Products;
            var id = (product as Products).food_id;
            //_ = MessageBox.Show(id.ToString());

            load_frame.Content = new OneProduct(id);
            load_frame.Visibility = Visibility.Visible;
            //ListViewProducts.Visibility = Visibility.Hidden;
        }

        private void OpenLoginBar(object sender, RoutedEventArgs e)
        {
            load_frame3.Content = new Login();
            load_frame3.Visibility = Visibility.Visible;
        }

        private void oooo(object sender, MouseEventArgs e)
        {
            MessageBox.Show("aaa");
        }

        public void UpdateProductCount()
        {

        }


        private void Button_Basket(object sender, RoutedEventArgs e)
        {
            CardPage shoppingBasketPage;
            listViewDepartments.Visibility = Visibility.Collapsed;
            productScreen.Visibility = Visibility.Collapsed;

            shoppingBasketPage = new CardPage();
            shoppingBasketPage.main = this;
            fullScreen.Children.Add(shoppingBasketPage);
        }

        public void MoveCursorMenu(int index)
        {
            GridCoursor.Margin = new Thickness(0, 170 + (60 * index), 0, 0);
        }

        public void Change()
        {
            listViewDepartments.Visibility = Visibility.Visible;
            productScreen.Visibility = Visibility.Visible;
        }

        public void SetUserName()
        {
            
        }

        private void SearchProduct(object sender, RoutedEventArgs e)
        {
            SearchProducts();
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {

        }


        private void SearchProducts()
        {
            
        }

        private void Window_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //MessageBox.Show("111");
            if (e.Key == Key.Enter)
            {
                SearchProducts();
            }
        }

        private void PPP(object sender, MouseButtonEventArgs e)
        {
            //_ = NavigationService.Navigate(null);
            //Login l = new Login();
           
        }

        private void DepartmentsListView(object sender, SelectionChangedEventArgs e)
        {
            //load_frame
            //.Visibility = Visibility.Hidden;
            //ListViewProducts.Visibility = Visibility.Visible;
            int index = ListView.SelectedIndex;
            MoveCursorMenu(index);

            List<Products> list = new();
            if (index == 0)
            {
                ListViewProducts.ItemsSource = null;
                list = productRepository.GetAllProducts();
                ListViewProducts.ItemsSource = list;
            }
            else
            {
                ListViewProducts.ItemsSource = null;
                list = productRepository.GetProductsByCategoryes(index);
                ListViewProducts.ItemsSource = list;
            }
        }

        private void DepartmentsListViewForHiddenPages(object sender, MouseButtonEventArgs e)
        {
            load_frame.Visibility = Visibility.Hidden;
            ListViewProducts.Visibility = Visibility.Visible;
        }

        private void full_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void OpenFilterBar(object sender, RoutedEventArgs e)
        {
            load_frame3.Content = new FilterPage();
            load_frame3.Visibility = Visibility.Visible;
        }
    }
}
