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
    /// Логика взаимодействия для AnimalTypePage.xaml
    /// </summary>
    public partial class AnimalTypePage : Page
    {
        private ZooAnimalHomeEntities zoo = new ZooAnimalHomeEntities();

        public AnimalTypePage()
        {
            InitializeComponent();
            AnimalTypeGrid.ItemsSource = zoo.AnimalTypes.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AnimalTypeNameTB.Text))
            {
                MessageBox.Show("Ошибка: поле не должно быть пустым");
                return;
            }
            string animalTypeName = AnimalTypeNameTB.Text;

            if (Regex.IsMatch(animalTypeName, @"[^\p{IsCyrillic}\s]"))
            {
                MessageBox.Show("Ошибка: поле не должно содержать смайлики, цифры или латинские буквы");
                return;
            }

            if (zoo.AnimalTypes.Any(a => a.type_nameA == animalTypeName))
            {
                MessageBox.Show("Ошибка: такой тип животного уже существует");
                return;
            }
            AnimalTypes animalname = new AnimalTypes();
            animalname.type_nameA = AnimalTypeNameTB.Text;

            zoo.AnimalTypes.Add(animalname);

            zoo.SaveChanges();
            AnimalTypeGrid.ItemsSource = zoo.AnimalTypes.ToList();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (AnimalTypeGrid.SelectedItem != null)
            {
                if (string.IsNullOrWhiteSpace(AnimalTypeNameTB.Text))
                {
                    MessageBox.Show("Ошибка: поле не должно быть пустым");
                    return;
                }

                string animalTypeName = AnimalTypeNameTB.Text;

                if (Regex.IsMatch(animalTypeName, @"[^\p{IsCyrillic}\s]"))
                {
                    MessageBox.Show("Ошибка: поле не должно содержать смайлики, цифры или латинские буквы");
                    return;
                }

                var selectedType = AnimalTypeGrid.SelectedItem as AnimalTypes;
                if (zoo.AnimalTypes.Any(a => a.type_nameA == animalTypeName && a.type_idA != selectedType.type_idA))
                {
                    MessageBox.Show("Ошибка: такой тип животного уже существует");
                    return;
                }
                selectedType.type_nameA = AnimalTypeNameTB.Text;
                zoo.SaveChanges();
                AnimalTypeGrid.ItemsSource = zoo.AnimalTypes.ToList();

            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (AnimalTypeGrid.SelectedItem != null)
            {
                zoo.AnimalTypes.Remove(AnimalTypeGrid.SelectedItem as AnimalTypes);
                zoo.SaveChanges();
                AnimalTypeGrid.ItemsSource = zoo.AnimalTypes.ToList();
            }
        }

        private void AnimalTypeGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AnimalTypeGrid.SelectedItem != null)
            {
                var selectedType = AnimalTypeGrid.SelectedItem as AnimalTypes;

                AnimalTypeNameTB.Text = selectedType.type_nameA;

            }
        }
    }
}
