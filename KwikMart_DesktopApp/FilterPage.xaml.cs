﻿using System;
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
        public FilterPage()
        {
            InitializeComponent();
        }

        private void CloseUserProfile(object sender, RoutedEventArgs e)
        {
            _ = NavigationService.Navigate(null);
        }

        private void FilterProducts(object sender, RoutedEventArgs e)
        {
            _ = NavigationService.Navigate(null);
        }
    }
}