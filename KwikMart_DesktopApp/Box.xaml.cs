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
using System.Windows.Shapes;

namespace KwikMart_DesktopApp
{
    /// <summary>
    /// Interaction logic for Box.xaml
    /// </summary>
    public partial class Box : Window
    {
        public Box()
        {
            InitializeComponent();
        }

        private void ShutDown(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
