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
    /// Interaction logic for Pr.xaml
    /// </summary>
    public partial class Pr : Page
    {
        public Pr()
        {
            InitializeComponent();
        }

        private void CloseUserProfile(object sender, EventArgs e)
        {
            _ = NavigationService.Navigate(null);
        }
    }
}
