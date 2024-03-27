using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        private ZooAnimalHomeEntities zoo = new ZooAnimalHomeEntities();
        public ProductPage()
        {
            InitializeComponent();
            ProductGrid.ItemsSource = zoo.Products.ToList();
            IdcatCB.ItemsSource = zoo.ProductCategories.ToList();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTb.Text) || string.IsNullOrWhiteSpace(DescrTB.Text) ||
        string.IsNullOrWhiteSpace(PriceTB.Text) || string.IsNullOrWhiteSpace(AmountTb.Text))
            {
                MessageBox.Show("Ошибка: заполните все поля.");
                return;
            }

            if (!(Regex.IsMatch(PriceTB.Text, @"^[1-9]\d*$")) || !(Regex.IsMatch(AmountTb.Text, @"^[1-9]\d*$")))
            {
                MessageBox.Show("Ошибка: в полях 'Цена' и 'Количество' должны быть только положительные цифры.");
                return;
            }

            if (Regex.IsMatch(NameTb.Text, @"[\uD800-\uDFFF\uDC00-\uDFFF]") || Regex.IsMatch(DescrTB.Text, @"[\uD800-\uDFFF\uDC00-\uDFFF]"))
            {
                MessageBox.Show("Ошибка: поля не должны содержать смайлики.");
                return;
            }

            Products product = new Products();
            product.nameP = NameTb.Text;
            product.descriptionP = DescrTB.Text;
            product.price = int.Parse(PriceTB.Text);
            product.amount = int.Parse(AmountTb.Text);
            product.id_category = (IdcatCB.SelectedItem as ProductCategories)?.category_id ?? 0;

            zoo.Products.Add(product);
            zoo.SaveChanges();
            ProductGrid.ItemsSource = zoo.Products.ToList();

        }

        private void SaveProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductGrid != null)
            {
                var selectProduct = ProductGrid.SelectedItem as Products;
                if (string.IsNullOrWhiteSpace(NameTb.Text) || string.IsNullOrWhiteSpace(DescrTB.Text) ||
            string.IsNullOrWhiteSpace(PriceTB.Text) || string.IsNullOrWhiteSpace(AmountTb.Text))
                {
                    MessageBox.Show("Ошибка: заполните все поля.");
                    return;
                }

                if (!(Regex.IsMatch(PriceTB.Text, @"^[1-9]\d*$")) || !(Regex.IsMatch(AmountTb.Text, @"^[1-9]\d*$")))
                {
                    MessageBox.Show("Ошибка: в полях 'Цена' и 'Количество' должны быть только положительные цифры (без нуля).");
                    return;
                }

                if (Regex.IsMatch(NameTb.Text, @"[^\u0020-\u007E]") || Regex.IsMatch(DescrTB.Text, @"[^\u0020-\u007E]"))
                {
                    MessageBox.Show("Ошибка: поля не должны содержать смайлики.");
                    return;
                }
                selectProduct.nameP = NameTb.Text;
                selectProduct.descriptionP = DescrTB.Text;
                selectProduct.price = int.Parse(PriceTB.Text);
                selectProduct.amount = int.Parse(AmountTb.Text);
                selectProduct.id_category = (IdcatCB.SelectedItem as ProductCategories)?.category_id ?? 0;

                zoo.SaveChanges();
                ProductGrid.ItemsSource = zoo.Products.ToList();

            }
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductGrid.SelectedItem != null)
            {
                zoo.Products.Remove(ProductGrid.SelectedItem as Products);
                zoo.SaveChanges();
                ProductGrid.ItemsSource = zoo.Products.ToList();
            }
        }

        private void ProductGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductGrid.SelectedItem != null)
            {
                var selectedProduct = ProductGrid.SelectedItem as Products;
                NameTb.Text = selectedProduct.nameP;
                DescrTB.Text = selectedProduct.descriptionP;
                PriceTB.Text = selectedProduct.price.ToString();
                AmountTb.Text = selectedProduct.amount.ToString();
                var position = zoo.ProductCategories.FirstOrDefault(p => p.category_id == selectedProduct.id_category);
                if (position != null)
                {
                    IdcatCB.SelectedItem = position;
                }
            }
        }

        private void IdcatCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IdcatCB.SelectedItem != null)
            {
                var selectedPosition = IdcatCB.SelectedItem as ProductCategories;
                IdcatCB.Text = selectedPosition.category_name;
            }
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<ProductModel> forImport = JsonImport.DeserializeObject<List<ProductModel>>();
                foreach (var product in forImport)
                {
                    if (!zoo.ProductCategories.Any(c => c.category_id == product.id_category))
                    {
                        MessageBox.Show("Ошибка: Неверный id категории товара.");
                        return;
                    }

                    zoo.Products.Add(new Products
                    {
                        nameP = product.nameP,
                        descriptionP = product.descriptionP,
                        price = product.price,
                        amount = product.amount,
                        id_category = product.id_category
                    });
                }

                zoo.SaveChanges();

                ProductGrid.ItemsSource = zoo.Products.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Данные из Json-файла не подходят для этой таблицы");
            }
        }
        
    }
 }
