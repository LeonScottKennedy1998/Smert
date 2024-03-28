using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Логика взаимодействия для LoginData.xaml
    /// </summary>
    public partial class CustomersPage : Page
    {
        private ZooAnimalHomeEntities zoo = new ZooAnimalHomeEntities();

        public CustomersPage()
        {
            InitializeComponent();
            CustomerGrid.ItemsSource = zoo.Customers.ToList();
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FirstNameBx.Text) || string.IsNullOrWhiteSpace(LastNameBx.Text) || string.IsNullOrWhiteSpace(EmailBx.Text) || string.IsNullOrWhiteSpace(PhoneBx.Text))
            {
                MessageBox.Show("Ошибка, все поля должны быть заполнены (отчество может быть пустым)");
                return;
            }

            Customers customer = new Customers();
            customer.first_name = FirstNameBx.Text;
            customer.last_name = LastNameBx.Text;
            customer.middle_name = MiddleNameBx.Text;

            if (!Regex.IsMatch(customer.first_name, @"^[а-яА-Я]+$") || !Regex.IsMatch(customer.last_name, @"^[а-яА-Я]+$") || (!string.IsNullOrWhiteSpace(customer.middle_name) && !Regex.IsMatch(customer.middle_name, @"^[а-яА-Я]+$")))
            {
                MessageBox.Show("Ошибка, поля ФИО должны содержать русские буквы");
                return;
            }
            string email = EmailBx.Text;
            if (Regex.IsMatch(email, @"[а-яА-Я]") || Regex.IsMatch(email, @"[\uD800-\uDFFF\uDC00-\uDFFF]") || email.StartsWith("@"))
            {
                MessageBox.Show("Ошибка, адрес электронной почты содержит недопустимые символы или начинается с '@'");
                return;
            }

            if (zoo.Customers.Any(em => em.email == email && em.customer_id != customer.customer_id))
            {
                MessageBox.Show("Ошибка, такая почта уже существует");
                return;
            }

            customer.email = EmailBx.Text;


            string phone = PhoneBx.Text;
            if (!Regex.IsMatch(phone, @"^\d+$"))
            {
                MessageBox.Show("Ошибка, номер телефона должен содержать только цифры");
                return;
            }

            if (zoo.Customers.Any(c => c.phone == phone))
            {
                MessageBox.Show("Ошибка, такой номер телефона уже существует");
                return;
            }
            if (phone.Length != 11)
            {
                MessageBox.Show("Ошибка, номер телефона должен содержать 11 цифр");
                return;
            }

            customer.phone = phone;

            zoo.Customers.Add(customer);
            zoo.SaveChanges();
            CustomerGrid.ItemsSource = zoo.Customers.ToList();
        }

        private void SaveCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerGrid.SelectedItem != null)
            {
                
                var selectedCustomer = CustomerGrid.SelectedItem as Customers;

                string oldFirstName = selectedCustomer.first_name;
                string oldLastName = selectedCustomer.last_name;
                string oldMiddleName = selectedCustomer.middle_name;
                string OldEmail = selectedCustomer.email;
                string OldPhone = selectedCustomer.phone;

                selectedCustomer.first_name = FirstNameBx.Text;
                selectedCustomer.last_name = LastNameBx.Text;
                selectedCustomer.middle_name = MiddleNameBx.Text;
                if (string.IsNullOrWhiteSpace(FirstNameBx.Text) || string.IsNullOrWhiteSpace(LastNameBx.Text) || string.IsNullOrWhiteSpace(EmailBx.Text) || string.IsNullOrWhiteSpace(PhoneBx.Text))
                {
                    MessageBox.Show("Ошибка, все поля должны быть заполнены (отчество может быть пустым)");
                    selectedCustomer.first_name = oldFirstName;
                    selectedCustomer.last_name = oldLastName;
                    selectedCustomer.phone = OldPhone;
                    selectedCustomer.email = OldEmail;
                    return;
                }
                if (!Regex.IsMatch(selectedCustomer.first_name, @"^[а-яА-Я]+$") || !Regex.IsMatch(selectedCustomer.last_name, @"^[а-яА-Я]+$") || (!string.IsNullOrWhiteSpace(selectedCustomer.middle_name) && !Regex.IsMatch(selectedCustomer.middle_name, @"^[а-яА-Я]+$")))
                {
                    MessageBox.Show("Ошибка, поля ФИО должны содержать русские буквы");
                    selectedCustomer.first_name = oldFirstName;
                    selectedCustomer.last_name = oldLastName;
                    selectedCustomer.middle_name = oldMiddleName;
                    return;
                }
                string email = EmailBx.Text;
                if (Regex.IsMatch(selectedCustomer.email, @"[а-яА-Я]") || Regex.IsMatch(selectedCustomer.email, @"[^\u0020-\u007E]") || email.StartsWith("@"))
                {
                    MessageBox.Show("Ошибка, адрес электронной почты содержит недопустимые символы");
                    selectedCustomer.email = OldEmail;
                    return;
                }
                if (zoo.Customers.Any(em => em.email == email && em.customer_id != selectedCustomer.customer_id))
                {
                    MessageBox.Show("Ошибка, такая почта уже существует");
                    selectedCustomer.first_name = oldFirstName;
                    selectedCustomer.last_name = oldLastName;
                    selectedCustomer.middle_name = oldMiddleName;
                    selectedCustomer.phone = OldPhone;
                    selectedCustomer.email = OldEmail;
                    return;
                }
                selectedCustomer.email = EmailBx.Text;
                string phone = PhoneBx.Text;
                if (!Regex.IsMatch(phone, @"^\d+$"))
                {
                    MessageBox.Show("Ошибка, номер телефона должен содержать только цифры");
                    selectedCustomer.phone = OldPhone;
                    return;
                }
                if (zoo.Customers.Any(c => c.phone == phone && c.customer_id != selectedCustomer.customer_id))
                {
                    MessageBox.Show("Ошибка, такой номер телефона уже существует");
                    selectedCustomer.first_name = oldFirstName;
                    selectedCustomer.last_name = oldLastName;
                    selectedCustomer.middle_name = oldMiddleName;
                    selectedCustomer.phone = OldPhone;
                    selectedCustomer.email = OldEmail;
                    return;
                }
                if (phone.Length != 11)
                {
                    MessageBox.Show("Ошибка, номер телефона должен содержать 11 цифр");
                    return;
                }
                selectedCustomer.phone = PhoneBx.Text;

                zoo.SaveChanges();
                CustomerGrid.ItemsSource = zoo.Customers.ToList();
            }
        }

        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerGrid.SelectedItem != null)
            {
                zoo.Customers.Remove(CustomerGrid.SelectedItem as Customers);
                zoo.SaveChanges();
                CustomerGrid.ItemsSource = zoo.Customers.ToList();
            }
        }

        private void CustomerGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CustomerGrid.SelectedItem != null)
            {
                var selectedCustomer = CustomerGrid.SelectedItem as Customers;
                LastNameBx.Text = selectedCustomer.last_name;
                FirstNameBx.Text = selectedCustomer.first_name;
                MiddleNameBx.Text = selectedCustomer.middle_name;
                EmailBx.Text = selectedCustomer.email;
                PhoneBx.Text = selectedCustomer.phone;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<CustomersModel> forImport = JsonImport.DeserializeObject<List<CustomersModel>>();
                foreach (var customer in forImport)
                {
                    if (zoo.Customers.Any(c => c.email == customer.email || c.phone == customer.phone))
                    {
                        MessageBox.Show("Ошибка: Клиент с таким email или телефоном уже существует.");
                        return;
                    }

                    zoo.Customers.Add(new Customers
                    {
                        first_name = customer.first_name,
                        last_name = customer.last_name,
                        middle_name = customer.middle_name,
                        email = customer.email,
                        phone = customer.phone
                    });
                }

                zoo.SaveChanges();

                CustomerGrid.ItemsSource = zoo.Customers.ToList();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Данные из Json-файла не подходят для этой таблицы");
                return;
            }
        }
       
    }
}
