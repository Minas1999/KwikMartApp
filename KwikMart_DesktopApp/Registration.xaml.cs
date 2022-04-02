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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
            //GetLocationEvent();
        }
        //GeoCoordinateWatcher watcher;

        //void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        //{
        //    PrintPosition(e.Position.Location.Latitude, e.Position.Location.Longitude);
        //}
        //void PrintPosition(double Latitude, double Longitude)
        //{
        //    MessageBox.Show("latitude" + Latitude + "longitude" + Longitude);
        //    txtLatitude.Text = Latitude.ToString();
        //    txtLongitude.Text = Longitude.ToString();
        //}

        private void CloseUserProfile(object sender, EventArgs e)
        {
            _ = NavigationService.Navigate(null);
        }

        private void GetCurrentLocation(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("ok");
        }
    }
}
