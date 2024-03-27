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
    /// Логика взаимодействия для StorageWindow.xaml
    /// </summary>
    public partial class StorageWindow : Window
    {
        public StorageWindow()
        {
            InitializeComponent();
        }

        private void TypeAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AnimalTypePage());

        }

        private void AnimalButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AnimalPage());

        }

        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProductPage());

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AnimalTypePage());

        }

        private void ProductTypeButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProductCategoryPage());
        }
    }
}
