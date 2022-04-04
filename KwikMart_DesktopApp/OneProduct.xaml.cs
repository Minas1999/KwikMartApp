
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
        public OneProduct()
        {
            InitializeComponent();
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
                MessageBox.Show("Տվյալ ապրանքից կարելի է ընտրել առավելագույը 10 հատ");
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
    }
}
