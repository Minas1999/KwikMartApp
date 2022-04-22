
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
            ImageBrush imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(@$"{pr.img_url}", UriKind.Absolute));
            image.ImageSource = imgBrush.ImageSource;

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

            if (productCount > 1)
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
            if (Login.isLogin)
            {
                Products pr = new Products();
                pr = productRepository.GetProductByID(foodID);
                productRepository.AddProductsToBasket(Login.currentUser.Id, pr, int.Parse(ButtonCounter.Content.ToString()));

                MessageBox.Show("Ավելացավ զամբյուղում");

                NavigationService.Navigate(null);
            }
            else
            {
                MessageBox.Show("Ավելացնելու համար մուտք գործեք ձեր էջ");
            }

        }
    }
}
