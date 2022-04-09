
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
    /// Interaction logic for OneProduct.xaml
    /// </summary>
    public partial class OneProduct : Page
    {
        private readonly int foodID;
        ProductRepository productRepository;
        public static List<Products> basketProducts = new();
        public OneProduct(int foodID)
        {
            InitializeComponent();
            productRepository = new();
            this.foodID = foodID;

            Products pr = new Products();
            pr = productRepository.GetProductByID(foodID);
            MovieTitle.Text = pr.name;
            //image = pr.img_url;

        }

        private void ButtonPlus(object sender, RoutedEventArgs e)
        {
            int productCount = int.Parse(ButtonCounter.Content.ToString());
            if (productCount < 10)
            {
                ButtonCounter.Content = productCount + 1;
            }
            else
            {
                _ = MessageBox.Show("Տվյալ ապրանքից կարելի է ընտրել առավելագույը 10 հատ");
            }
        }

        private void ButtonMinus(object sender, RoutedEventArgs e)
        {
            int productCount = int.Parse(ButtonCounter.Content.ToString());

            if (productCount > 0)
            {
                ButtonCounter.Content = productCount - 1;
            }
        }

        private void OpenMap(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("40");
            
        }

        private void ButtonAdd(object sender, RoutedEventArgs e)
        {
            Products pr = new Products();
            pr = productRepository.GetProductByID(foodID);
            //basketProducts.Add(pr);
            productRepository.AddProductsToBasket(pr);
        }
    }
}
