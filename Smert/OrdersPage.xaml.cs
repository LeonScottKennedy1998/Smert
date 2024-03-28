using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Smert
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        private ZooAnimalHomeEntities zoo = new ZooAnimalHomeEntities();
        public OrdersPage()
        {
            InitializeComponent();
            OrderGrid.ItemsSource = zoo.Orders.ToList();
            CustidCB.ItemsSource = zoo.Customers.ToList();
            EmplidCB.ItemsSource = zoo.Employees.ToList();
        }

        private void OrderGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrderGrid.SelectedItem != null)
            {
                var selectedOrder = OrderGrid.SelectedItem as Orders;
                OrderdateTB.Text = selectedOrder.order_date.ToShortDateString();
                var position1 = zoo.Customers.FirstOrDefault(r => r.customer_id == selectedOrder.id_customer);
                if (position1 != null)
                {
                    CustidCB.SelectedItem = position1;
                }

                var position2 = zoo.Employees.FirstOrDefault(r => r.employee_id == selectedOrder.id_employee);
                if (position2 != null)
                {
                    EmplidCB.SelectedItem = position2;
                }
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(OrderdateTB.Text) || CustidCB.SelectedItem == null || EmplidCB.SelectedItem == null)
            {
                MessageBox.Show("Ошибка, все поля должны быть заполнены.");
                return;
            }

            string orderDate = OrderdateTB.Text;
            if (!Regex.IsMatch(orderDate, @"^\d{2}\.\d{2}\.\d{4}$"))
            {
                MessageBox.Show("Ошибка, неверный формат даты. Используйте формат dd.MM.yyyy.");
                return;
            }
            Orders order = new Orders();
            order.order_date = DateTime.Parse(OrderdateTB.Text);
            order.id_customer = (CustidCB.SelectedItem as Customers)?.customer_id ?? 0;
            order.id_employee = (EmplidCB.SelectedItem as Employees)?.employee_id ?? 0;

            zoo.Orders.Add(order);

            zoo.SaveChanges();
            OrderGrid.ItemsSource = zoo.Orders.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (OrderGrid.SelectedItem != null)
            {
                var selectedOrder = OrderGrid.SelectedItem as Orders;
                if (string.IsNullOrWhiteSpace(OrderdateTB.Text) || CustidCB.SelectedItem == null || EmplidCB.SelectedItem == null)
                {
                    MessageBox.Show("Ошибка, все поля должны быть заполнены.");
                    return;
                }

                string orderDate = OrderdateTB.Text;
                if (!Regex.IsMatch(orderDate, @"^\d{2}\.\d{2}\.\d{4}$"))
                {
                    MessageBox.Show("Ошибка, неверный формат даты. Используйте формат dd.MM.yyyy.");
                    return;
                }
                selectedOrder.order_date = DateTime.Parse(OrderdateTB.Text);
                selectedOrder.id_customer = (CustidCB.SelectedItem as Customers)?.customer_id ?? 0;
                selectedOrder.id_employee = (EmplidCB.SelectedItem as Employees)?.employee_id ?? 0;
                zoo.SaveChanges();
                OrderGrid.ItemsSource = zoo.Orders.ToList();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (OrderGrid.SelectedItem != null)
            {
                zoo.Orders.Remove(OrderGrid.SelectedItem as Orders);
                zoo.SaveChanges();
                OrderGrid.ItemsSource = zoo.Orders.ToList();
            }
        }

        private void CustidCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CustidCB.SelectedItem != null)
            {
                var selectedPosition = CustidCB.SelectedItem as Customers;
                CustidCB.Text = selectedPosition.last_name;
            }
        }

        private void EmplidCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmplidCB.SelectedItem != null)
            {
                var selectedPosition = EmplidCB.SelectedItem as Employees;
                EmplidCB.Text = selectedPosition.last_name;
            }
        }

    }
}
