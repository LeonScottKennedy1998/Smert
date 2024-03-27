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

namespace Smert
{
    /// <summary>
    /// Логика взаимодействия для SellerWindow.xaml
    /// </summary>
    public partial class SellerWindow : Window
    {
        public SellerWindow()
        {
            InitializeComponent();
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new OrdersPage());

        }

        private void OrderItemsButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new OrderItemsPage());

        }

        private void ReviewButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ReviewPage());

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new OrdersPage());
        }

        private void ReceiptButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ReceiptPage());
        }
    }
}
