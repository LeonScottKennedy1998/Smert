using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.IO;

namespace Smert
{
    /// <summary>
    /// Логика взаимодействия для OrderItemsPage.xaml
    /// </summary>
    public partial class OrderItemsPage : Page
    {
        private ZooAnimalHomeEntities zoo = new ZooAnimalHomeEntities();
        string programName = "Smert";
        int receiptNumber = 1; 
        public OrderItemsPage()
        {
            InitializeComponent();
            OrderItemGrid.ItemsSource = zoo.OrderItems.ToList();
            OrderCB.ItemsSource = zoo.Orders.ToList();
            ProdCB.ItemsSource = zoo.Products.ToList();
            AnimalCB.ItemsSource = zoo.Animals.ToList();
            PriceTB.IsEnabled = false;

        }

        private void OrderItemGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrderItemGrid.SelectedItem != null)
            {
                var selectedOrderItem = OrderItemGrid.SelectedItem as OrderItems;

                QuantTB.Text = selectedOrderItem.quantity.ToString();
                PriceTB.Text = selectedOrderItem.item_price.ToString();

                var order = zoo.Orders.FirstOrDefault(o => o.order_id == selectedOrderItem.id_order);
                if (order != null)
                {
                    OrderCB.SelectedItem = order;
                }
                else
                {
                    OrderCB.SelectedItem = null; 
                }

                var product = zoo.Products.FirstOrDefault(p => p.product_id == selectedOrderItem.id_product);
                if (product != null)
                {
                    ProdCB.SelectedItem = product;
                }
                else
                {
                    ProdCB.SelectedItem = null; 
                }

                var animal = zoo.Animals.FirstOrDefault(a => a.animal_id == selectedOrderItem.id_animal);
                if (animal != null)
                {
                    AnimalCB.SelectedItem = animal;
                }
                else
                {
                    AnimalCB.SelectedItem = null; 
                }

            }
        }

        private void OrderCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrderCB.SelectedItem != null)
            {
                var selectedOrder = OrderCB.SelectedItem as Orders;

                var allAnimals = zoo.Animals.ToList();

                var animalsInOtherOrders = zoo.OrderItems.Where(item => item.id_order != selectedOrder.order_id && item.id_animal != null).Select(item => item.Animals).ToList();

                var availableAnimals = allAnimals.Except(animalsInOtherOrders).ToList();

                AnimalCB.ItemsSource = availableAnimals;
            }

        }

        private void ProdCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProdCB.SelectedItem != null)
            {
                AnimalCB.IsEnabled = false;

                var selectedProduct = ProdCB.SelectedItem as Products;
                if (selectedProduct != null)
                {
                    ProdCB.Text = selectedProduct.nameP;
                    PriceTB.Text = selectedProduct.price.ToString();
                }
            }
            else
            {
                AnimalCB.IsEnabled = true;
            }
        }

        private void AnimalCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AnimalCB.SelectedItem != null)
            {
                ProdCB.IsEnabled = false;

                QuantTB.Text = "1";
                QuantTB.IsEnabled = false;

                var selectedAnimal = AnimalCB.SelectedItem as Animals;
                if (selectedAnimal != null)
                {
                    AnimalCB.Text = selectedAnimal.nameA;
                    PriceTB.Text = selectedAnimal.price.ToString();
                }
            }
            else
            {
                ProdCB.IsEnabled = true;

                QuantTB.IsEnabled = true;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            OrderItems newItem = new OrderItems();

            if (int.TryParse(QuantTB.Text, out int quantity) && quantity >= 0)
            {
                newItem.quantity = quantity;

            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения в поля количество");
                return;
            }
            newItem.quantity = int.Parse(QuantTB.Text);
            newItem.item_price = int.Parse(PriceTB.Text);
            newItem.id_order = (OrderCB.SelectedItem as Orders)?.order_id ?? 0;
            newItem.id_product = (ProdCB.SelectedItem as Products)?.product_id ?? 0;

            if (AnimalCB.SelectedItem != null)
            {
                newItem.id_animal = (AnimalCB.SelectedItem as Animals)?.animal_id;
                newItem.id_product = null;

            }
            else
            {
                newItem.id_animal = null;
            }

            if (ProdCB.SelectedItem != null)
            {
                newItem.id_product = (ProdCB.SelectedItem as Products)?.product_id;
                newItem.id_animal = null;

            }
            else
            {
                newItem.id_product = null;
            }

            zoo.OrderItems.Add(newItem);
            zoo.SaveChanges();

            OrderItemGrid.ItemsSource = zoo.OrderItems.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (OrderItemGrid.SelectedItem != null)
            {
                var selectedItem = OrderItemGrid.SelectedItem as OrderItems;

                if (int.TryParse(QuantTB.Text, out int quantity) && quantity >= 0)
                {
                    selectedItem.quantity = quantity;
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите корректные числовые значения в поля количество");
                    return;
                }

                selectedItem.id_order = (OrderCB.SelectedItem as Orders)?.order_id ?? 0;

                if (ProdCB.SelectedItem != null)
                {
                    selectedItem.id_product = (ProdCB.SelectedItem as Products)?.product_id ?? 0;
                    selectedItem.item_price = (ProdCB.SelectedItem as Products)?.price ?? 0; 
                }
                else if (AnimalCB.SelectedItem != null)
                {
                    selectedItem.id_animal = (AnimalCB.SelectedItem as Animals)?.animal_id;
                    selectedItem.item_price = (AnimalCB.SelectedItem as Animals)?.price ?? 0;
                }

                zoo.SaveChanges();

                OrderItemGrid.ItemsSource = zoo.OrderItems.ToList();
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (OrderItemGrid.SelectedItem != null)
            {
                zoo.OrderItems.Remove(OrderItemGrid.SelectedItem as OrderItems);
                zoo.SaveChanges();

                OrderItemGrid.ItemsSource = zoo.OrderItems.ToList();
            }
        }

        private void QuantTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (QuantTB.Text == "0")
            {
                QuantTB.Text = "1";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            QuantTB.Text = "";
            PriceTB.Text = "";


            OrderCB.SelectedItem = null;
            ProdCB.SelectedItem = null;
            AnimalCB.SelectedItem = null;

            OrderCB.IsEnabled = true;
            ProdCB.IsEnabled = true;
            AnimalCB.IsEnabled = true;
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            if (OrderItemGrid.SelectedItem != null)
            {
                CartGrid.Items.Add(OrderItemGrid.SelectedItem);

                double totalAmount = 0;
                foreach (var item in CartGrid.Items)
                {
                    var orderItem = item as OrderItems;
                    totalAmount += orderItem.quantity * orderItem.item_price;
                }
                TotalAmountLabel.Content = $"Итого к оплате: {totalAmount}";
            }
        }

        private void ExportReceipt_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder receiptContent = new StringBuilder();
            receiptContent.AppendLine(programName);
            receiptContent.AppendLine($"Чек #{receiptNumber}");

            foreach (var item in CartGrid.Items)
            {
                var orderItem = item as OrderItems;
                if (orderItem.Products != null)
                {
                    receiptContent.AppendLine($"{orderItem.Products.nameP} - {orderItem.item_price}");
                }
                else if (orderItem.Animals != null)
                {
                    receiptContent.AppendLine($"{orderItem.Animals.nameA} - {orderItem.item_price}");
                }
            }

            double totalAmount = 0;
            foreach (var item in CartGrid.Items)
            {
                var orderItem = item as OrderItems;
                totalAmount += orderItem.quantity * orderItem.item_price;
            }

            double paymentAmount;
            if (!double.TryParse(PaymentAmountTextBox.Text, out paymentAmount))
            {
                MessageBox.Show("Некорректная сумма внесенных средств.");
                return;
            }

            if (paymentAmount < totalAmount)
            {
                MessageBox.Show("Недостаточно средств для оплаты.");
                return;
            }

            if (totalAmount == 0)
            {
                MessageBox.Show("Выберите товары");
                return;
            }
            receiptContent.AppendLine($"Итого к оплате: {totalAmount}");
            receiptContent.AppendLine($"Внесено: {paymentAmount}");
            receiptContent.AppendLine($"Сдача: {paymentAmount - totalAmount}");

            string filePath = $"Чек #{receiptNumber}.txt";
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filePath = System.IO.Path.Combine(desktopPath, filePath);
            System.IO.File.WriteAllText(filePath, receiptContent.ToString());

            receiptNumber++;

            MessageBox.Show("Чек успешно экспортирован.");
            CartGrid.Items.Clear();
            totalAmount = 0;
            TotalAmountLabel.Content = $"Итого к оплате: {totalAmount}";
            PaymentAmountTextBox.Text = "";

        }

    }
}
