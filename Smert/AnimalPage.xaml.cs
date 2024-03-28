using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
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
using static System.Net.Mime.MediaTypeNames;

namespace Smert
{
    /// <summary>
    /// Логика взаимодействия для AnimalPage.xaml
    /// </summary>
    public partial class AnimalPage : Page
    {
        private ZooAnimalHomeEntities zoo = new ZooAnimalHomeEntities();

        public AnimalPage()
        {
            InitializeComponent();
            AnimalGrid.ItemsSource = zoo.Animals.ToList();
            IdCB.ItemsSource = zoo.AnimalTypes.ToList();
        }

        private void AddAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTb.Text) || string.IsNullOrWhiteSpace(BreedTB.Text) ||
                string.IsNullOrWhiteSpace(AgeTB.Text) || string.IsNullOrWhiteSpace(GenderTB.Text) ||
                string.IsNullOrWhiteSpace(PriceTB.Text) || string.IsNullOrWhiteSpace(ArrivalDateTB.Text))
            {
                MessageBox.Show("Ошибка: заполните все поля.");
                return;
            }

            if (Regex.IsMatch(NameTb.Text, @"[a-zA-Z]") || Regex.IsMatch(BreedTB.Text, @"[a-zA-Z]") ||
                Regex.IsMatch(GenderTB.Text, @"[a-zA-Z]") || Regex.IsMatch(NameTb.Text, @"^\d+$") || Regex.IsMatch(BreedTB.Text, @"^\d+$")
                || Regex.IsMatch(GenderTB.Text, @"^\d+$"))
            {
                MessageBox.Show("Ошибка: поля должны содержать только кириллицу.");
                return;
            }

            if (!(Regex.IsMatch(AgeTB.Text, @"^\d+$")))
            {
                MessageBox.Show("Ошибка: в поле 'Возраст' должны быть только положительные цифры.");
                return;
            }

            if (!(Regex.IsMatch(PriceTB.Text, @"^\d+$")))
            {
                MessageBox.Show("Ошибка: в поле 'Цена' должны быть только положительные цифры.");
                return;
            }

            if (GenderTB.Text != "Мужской" && GenderTB.Text != "Женский")
            {
                MessageBox.Show("Ошибка: пол должен быть 'Мужской' или 'Женский'.");
                return;
            }

            DateTime arrivalDate;
            if (!DateTime.TryParseExact(ArrivalDateTB.Text, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out arrivalDate) || arrivalDate.Year < 2000 || arrivalDate.Year > 2024)
            {
                MessageBox.Show("Ошибка: неверный формат даты. Используйте формат dd.MM.yyyy и год должен быть больше 2000 и меньше 2025.");
                return;
            }


            if (Regex.IsMatch(NameTb.Text, @"[\uD800-\uDFFF\uDC00-\uDFFF]") || Regex.IsMatch(BreedTB.Text, @"[\uD800-\uDFFF\uDC00-\uDFFF]"))
            {
                MessageBox.Show("Ошибка: поля не должны содержать смайлики.");
                return;
            }
            Animals animal = new Animals();
            animal.nameA = NameTb.Text;
            animal.breed = BreedTB.Text;
            animal.age = int.Parse(AgeTB.Text);
            animal.gender = GenderTB.Text;
            animal.price = int.Parse(PriceTB.Text);
            animal.arrival_date = DateTime.Parse(ArrivalDateTB.Text);
            animal.id_type = (IdCB.SelectedItem as AnimalTypes)?.type_idA ?? 0;

            zoo.Animals.Add(animal);

            zoo.SaveChanges();
            AnimalGrid.ItemsSource = zoo.Animals.ToList();
        }

        private void SaveAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (AnimalGrid.SelectedItem != null)
            {
                var selectedAnimal = AnimalGrid.SelectedItem as Animals;
                if (string.IsNullOrWhiteSpace(NameTb.Text) || string.IsNullOrWhiteSpace(BreedTB.Text) ||
                string.IsNullOrWhiteSpace(AgeTB.Text) || string.IsNullOrWhiteSpace(GenderTB.Text) ||
                string.IsNullOrWhiteSpace(PriceTB.Text) || string.IsNullOrWhiteSpace(ArrivalDateTB.Text))
                {
                    MessageBox.Show("Ошибка: заполните все поля.");
                    return;
                }

                if (Regex.IsMatch(NameTb.Text, @"[a-zA-Z]") || Regex.IsMatch(BreedTB.Text, @"[a-zA-Z]") ||
                    Regex.IsMatch(GenderTB.Text, @"[a-zA-Z]") || Regex.IsMatch(NameTb.Text, @"^\d+$") || Regex.IsMatch(BreedTB.Text, @"^\d+$")
                    || Regex.IsMatch(GenderTB.Text, @"^\d+$"))
                {
                    MessageBox.Show("Ошибка: поля должны содержать только кириллицу.");
                    return;
                }

                if (!(Regex.IsMatch(AgeTB.Text, @"^\d+$")))
                {
                    MessageBox.Show("Ошибка: в поле 'Возраст' должны быть только положительные цифры.");
                    return;
                }

                if (!(Regex.IsMatch(PriceTB.Text, @"^\d+$")))
                {
                    MessageBox.Show("Ошибка: в поле 'Цена' должны быть только положительные цифры.");
                    return;
                }

                if (GenderTB.Text != "Мужской" && GenderTB.Text != "Женский")
                {
                    MessageBox.Show("Ошибка: пол должен быть 'Мужской' или 'Женский'.");
                    return;
                }

                DateTime arrivalDate;
                if (!DateTime.TryParseExact(ArrivalDateTB.Text, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out arrivalDate) || arrivalDate.Year < 2000 || arrivalDate.Year > 2024)
                {
                    MessageBox.Show("Ошибка: неверный формат даты. Используйте формат dd.MM.yyyy и год должен быть больше 2000 и меньше 2025.");
                    return;
                }

                if (Regex.IsMatch(NameTb.Text, @"[\uD800-\uDFFF\uDC00-\uDFFF]") || Regex.IsMatch(BreedTB.Text, @"[\uD800-\uDFFF\uDC00-\uDFFF]"))
                {
                    MessageBox.Show("Ошибка: поля не должны содержать смайлики.");
                    return;
                }

                var selectedType = IdCB.SelectedItem as AnimalTypes;
                if (selectedType == null)
                {
                    MessageBox.Show("Ошибка: Выберите тип животного.");
                    return;
                }

                selectedAnimal.id_type = selectedType.type_idA;
                selectedAnimal.nameA = NameTb.Text;
                selectedAnimal.breed = BreedTB.Text;
                selectedAnimal.age = int.Parse(AgeTB.Text);
                selectedAnimal.gender = GenderTB.Text;
                selectedAnimal.price = int.Parse(PriceTB.Text);
                selectedAnimal.arrival_date = DateTime.Parse(ArrivalDateTB.Text);
                selectedAnimal.id_type = (IdCB.SelectedItem as AnimalTypes)?.type_idA ?? 0;

                zoo.SaveChanges();
                AnimalGrid.ItemsSource = zoo.Animals.ToList();

            }
        }

        private void DeleteAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (AnimalGrid.SelectedItem != null)
            {
                zoo.Animals.Remove(AnimalGrid.SelectedItem as Animals);
                zoo.SaveChanges();
                AnimalGrid.ItemsSource = zoo.Animals.ToList();
            }
        }

        private void IdCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IdCB.SelectedItem != null)
            {
                var selectedPosition = IdCB.SelectedItem as AnimalTypes;
                IdCB.Text = selectedPosition.type_nameA;
            }
        }

        private void AnimalGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AnimalGrid.SelectedItem != null)
            {
                var selectedAnimal = AnimalGrid.SelectedItem as Animals;

                NameTb.Text = selectedAnimal.nameA;
                BreedTB.Text = selectedAnimal.breed;
                AgeTB.Text = selectedAnimal.age.ToString();
                GenderTB.Text = selectedAnimal.gender;
                PriceTB.Text = selectedAnimal.price.ToString();
                ArrivalDateTB.Text = selectedAnimal.arrival_date.ToShortDateString();


                var position = zoo.AnimalTypes.FirstOrDefault(p => p.type_idA == selectedAnimal.id_type);
                if (position != null)
                {
                    IdCB.SelectedItem = position;
                }
            }
        }
    }
}
