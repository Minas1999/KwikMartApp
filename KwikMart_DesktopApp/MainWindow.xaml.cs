//using DataAccess.Models;
using DataAccess;
using DataAccess.Models;
using DataAccess.Repositoryes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        private List<Products> productsList;
        public MainWindow()
        {

            InitializeComponent();
            productRepository = new();

            productsList = productRepository.GetAllProducts();

            ListViewProducts.ItemsSource = productsList;

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
                var id = (product as Products).food_id;

                load_frame.Content = new OneProduct(id);
                load_frame.Visibility = Visibility.Visible;
            

            
        }

        private void OpenLoginBar(object sender, RoutedEventArgs e)
        {
            if (!Login.isLogin)
            {
                load_frame3.Content = new Login();
                load_frame3.Visibility = Visibility.Visible;
            }
            else
            {
                load_frame3.Content = new OrdersHistory();
                load_frame3.Visibility = Visibility.Visible;

            }

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
            if (Login.isLogin)
            {
                CardPage shoppingBasketPage;
                listViewDepartments.Visibility = Visibility.Collapsed;
                productScreen.Visibility = Visibility.Collapsed;

                shoppingBasketPage = new CardPage();
                shoppingBasketPage.main = this;
                fullScreen.Children.Add(shoppingBasketPage);
            }
            else
            {
                MessageBox.Show("Մուտք գործեք ձեր էջ");
            }
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

        public void FilterFoods(FilterProductsEnum filter)
        {
            switch (filter)
            {
                case FilterProductsEnum.ASC:
                    ListViewProducts.ItemsSource = null;
                    ListViewProducts.ItemsSource = productsList.OrderBy(x => x.price);
                    break;
                case FilterProductsEnum.DESC:
                    ListViewProducts.ItemsSource = null;
                    ListViewProducts.ItemsSource = productsList.OrderByDescending(x => x.price);
                    break;
                default:
                    break;
            }
        }

        private void SearchProduct(object sender, RoutedEventArgs e)
        {
            SearchProducts();
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            if (Login.isLogin)
            {
                if (MessageBox.Show("Դուք ցանկանում եք դու՞րս գալ ձեր կայքից։",
                    "Զգուշացում", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Login.isLogin = false;
                }
            }
        }


        private void SearchProducts()
        {
            var productsList1 = (from c in productsList
                                 where c.name.ToUpper().Contains(searchBox.Text.ToUpper())
                                 select c).ToList();
            ListViewProducts.ItemsSource = productsList1;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchProducts();
            }
        }

        private void PPP(object sender, MouseButtonEventArgs e)
        {
        }

        private void DepartmentsListView(object sender, SelectionChangedEventArgs e)
        {
            int index = ListView.SelectedIndex;
            MoveCursorMenu(index);

            if (index == 0)
            {
                ListViewProducts.ItemsSource = productsList;
            }
            else
            {
                ListViewProducts.ItemsSource = null;
                ListViewProducts.ItemsSource = productRepository.GetProductsByCategoryes(index);
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
