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
    /// Логика взаимодействия для ProductCategoryPage.xaml
    /// </summary>
    public partial class ProductCategoryPage : Page
    {
        private ZooAnimalHomeEntities zoo = new ZooAnimalHomeEntities();

        public ProductCategoryPage()
        {
            InitializeComponent();
            ProductCategoryGrid.ItemsSource = zoo.ProductCategories.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string categoryName = CategoryTB.Text;

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("Ошибка: поле категории не должно быть пустым.");
                return;
            }

            if (Regex.IsMatch(categoryName, @"[^\p{IsCyrillic}\s]"))
            {
                MessageBox.Show("Ошибка: категория не должна содержать смайликов, цифр или английских букв.");
                return;
            }

            if (zoo.ProductCategories.Any(cat => cat.category_name == categoryName))
            {
                MessageBox.Show("Ошибка: такая категория уже существует.");
                return;
            }

            ProductCategories productcat = new ProductCategories();
            productcat.category_name = CategoryTB.Text;

            zoo.ProductCategories.Add(productcat);

            zoo.SaveChanges();
            ProductCategoryGrid.ItemsSource = zoo.ProductCategories.ToList();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductCategoryGrid.SelectedItem != null)
            {
                string categoryName = CategoryTB.Text;

                if (string.IsNullOrWhiteSpace(categoryName))
                {
                    MessageBox.Show("Ошибка: поле категории не должно быть пустым.");
                    return;
                }

                if (Regex.IsMatch(categoryName, @"[^\p{IsCyrillic}\s]"))
                {
                    MessageBox.Show("Ошибка: категория не должна содержать смайликов, цифр или английских букв.");
                    return;
                }

                var selectedcat = ProductCategoryGrid.SelectedItem as ProductCategories;
                if (zoo.ProductCategories.Any(cat => cat.category_name == categoryName))
                {
                    MessageBox.Show("Ошибка: такая категория уже существует.");
                    return;
                }
                selectedcat.category_name = CategoryTB.Text;
                zoo.SaveChanges();
                ProductCategoryGrid.ItemsSource = zoo.ProductCategories.ToList();

            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductCategoryGrid.SelectedItem != null)
            {
                zoo.ProductCategories.Remove(ProductCategoryGrid.SelectedItem as ProductCategories);
                zoo.SaveChanges();
                ProductCategoryGrid.ItemsSource = zoo.ProductCategories.ToList();
            }
        }

        private void ProductCategoryGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductCategoryGrid.SelectedItem != null)
            {
                var selectedcat = ProductCategoryGrid.SelectedItem as ProductCategories;

                CategoryTB.Text = selectedcat.category_name;

            }
        }
    }
}
