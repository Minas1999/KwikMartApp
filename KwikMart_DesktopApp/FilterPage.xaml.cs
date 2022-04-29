using DataAccess;
using DataAccess.Models;
using DataAccess.Repositoryes;
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
    /// Interaction logic for FilterPage.xaml
    /// </summary>
    public partial class FilterPage : Page
    {
        ProductRepository productRepository;
        MainWindow main { get; set; }
        public FilterPage()
        {
            InitializeComponent();
        }

        private void CloseUserProfile(object sender, RoutedEventArgs e)
        {
            _ = NavigationService.Navigate(null);
        }

        public event EventHandler SomethingHappened;
        private void MakeSomethingHappen(EventArgs e)
        {
            if (SomethingHappened != null)
            {
                SomethingHappened(this, e);
            }
        }

        private void FilterProducts(object sender, RoutedEventArgs e)
        {
            productRepository = new();

            if (Convert.ToBoolean(InASC.IsChecked))
            {
                ((MainWindow)Application.Current.MainWindow).FilterFoods(FilterProductsEnum.ASC);
                _ = NavigationService.Navigate(null);
            }

            if (Convert.ToBoolean(InDESC.IsChecked))
            {
                ((MainWindow)Application.Current.MainWindow).FilterFoods(FilterProductsEnum.DESC);
                _ = NavigationService.Navigate(null);
            }

            if (Convert.ToBoolean(Rating.IsChecked))
            {
                ((MainWindow)Application.Current.MainWindow).FilterFoods(FilterProductsEnum.Rating);
                _ = NavigationService.Navigate(null);
            }

            if (Convert.ToBoolean(Orders.IsChecked))
            {
                ((MainWindow)Application.Current.MainWindow).FilterFoods(FilterProductsEnum.Orders);
                _ = NavigationService.Navigate(null);
            }
        }
    }
}
