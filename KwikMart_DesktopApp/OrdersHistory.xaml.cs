using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for OrdersHistory.xaml
    /// </summary>
    public partial class OrdersHistory : Page
    {
        UserRepository userRepository;
        public OrdersHistory()
        {
            userRepository = new();
            InitializeComponent();

            DataTable table = new();
            var productsList = userRepository.GetUserOrders(Login.currentUser.Id);



            //table.Columns.Add(new DataColumn()
            //{
            //    DataType = typeof(string),
            //    ColumnName = "ID",
            //    Caption = "Order Id",
            //    ReadOnly = true,
            //    Unique = true
            //});

            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Summa", typeof(string));

            foreach (var item in productsList)
            {
                table.Rows.Add(item.orderID.ToString(), item.orderDate, item.totalAmount);
            }

            DataGrid.ItemsSource = table.DefaultView;


            User user = Login.currentUser;

            name.Text = user.Name.ToString();
            address.Text = user.Address.ToString();
            address1.Text = user.Address.ToString();
            Phone_number.Text = user.Phone_number.ToString();
            Gmail.Text = user.Gmail.ToString();
        }

        private void CloseUserOrdersHistory(object sender, RoutedEventArgs e)
        {
            _ = NavigationService.Navigate(null);
        }
    }
}
