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
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        private ZooAnimalHomeEntities zoo = new ZooAnimalHomeEntities();

        public EmployeesPage()
        {
            InitializeComponent();
            EmployeeGrid.ItemsSource = zoo.Employees.ToList();
            PositionComboBox.ItemsSource = zoo.EmployeesPositions.ToList();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                Employees employee = new Employees();
                employee.first_name = FirstNameBx.Text;
                employee.last_name = LastNameBx.Text;
                employee.middle_name = MiddleNameBx.Text;
                employee.PasswordE = PasswordBx.Text;
                employee.UsernameE = LoginBx.Text;
                employee.id_position = (PositionComboBox.SelectedItem as EmployeesPositions)?.position_id ?? 0;

                string UsernameE = LoginBx.Text;
                string PasswordE = PasswordBx.Text;
                if (!Regex.IsMatch(employee.first_name, @"^[а-яА-Я]+$") || !Regex.IsMatch(employee.last_name, @"^[а-яА-Я]+$") || !Regex.IsMatch(employee.middle_name, @"^[а-яА-Я]+$"))
                {
                    MessageBox.Show("Ошибка, поля ФИО должны содержать русские буквы");
                    return;
                }

                if (!Regex.IsMatch(employee.UsernameE, @"^[a-zA-Z0-9\s]+$") || !Regex.IsMatch(employee.PasswordE, @"^[a-zA-Z0-9\s]+$"))
                {
                    MessageBox.Show("Ошибка, для логина и пароля используйте английские буквы и цифры");
                    return;
                }

                if (zoo.Employees.Any(s => s.UsernameE == UsernameE && s.employee_id != employee.employee_id))
                {
                    MessageBox.Show("Ошибка, такой логин уже существует");
                    return;
                }

                if (zoo.Employees.Any(s => s.PasswordE == PasswordE && s.employee_id != employee.employee_id))
                {
                    MessageBox.Show("Ошибка, такой пароль уже существует");
                    return;
                }
                zoo.Employees.Add(employee);

                zoo.SaveChanges();
                EmployeeGrid.ItemsSource = zoo.Employees.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при добавлении сотрудника");
            }
        }

        private void SaveEmployee_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (EmployeeGrid.SelectedItem != null)
                {
                    var selectedEmployee = EmployeeGrid.SelectedItem as Employees;

                    string oldFirstName = selectedEmployee.first_name;
                    string oldLastName = selectedEmployee.last_name;
                    string oldMiddleName = selectedEmployee.middle_name;
                    string oldUsername = selectedEmployee.UsernameE;
                    string oldPassword = selectedEmployee.PasswordE;

                    selectedEmployee.first_name = FirstNameBx.Text;
                    selectedEmployee.last_name = LastNameBx.Text;
                    selectedEmployee.middle_name = MiddleNameBx.Text;
                    selectedEmployee.UsernameE = LoginBx.Text;
                    selectedEmployee.PasswordE = PasswordBx.Text;
                    selectedEmployee.id_position = (PositionComboBox.SelectedItem as EmployeesPositions)?.position_id ?? 0;

                    string UsernameE = LoginBx.Text;
                    string PasswordE = PasswordBx.Text;

                    if (string.IsNullOrWhiteSpace(selectedEmployee.first_name) || string.IsNullOrWhiteSpace(selectedEmployee.last_name))
                    {
                        MessageBox.Show("Ошибка, поля фамилии и имени должны быть заполнены (отчество необязательно)");
                        selectedEmployee.first_name = oldFirstName;
                        selectedEmployee.last_name = oldLastName;
                        return;
                    }

                    if (!Regex.IsMatch(selectedEmployee.first_name, @"^[а-яА-Я]+$") || !Regex.IsMatch(selectedEmployee.last_name, @"^[а-яА-Я]+$") 
                        || (!string.IsNullOrWhiteSpace(selectedEmployee.middle_name) && !Regex.IsMatch(selectedEmployee.middle_name, @"^[а-яА-Я]+$")))
                    {
                        MessageBox.Show("Ошибка, введите только русские буквы в поля ФИО");
                        selectedEmployee.first_name = oldFirstName;
                        selectedEmployee.last_name = oldLastName;
                        selectedEmployee.middle_name = oldMiddleName;
                        return;
                    }

                    if (!Regex.IsMatch(selectedEmployee.UsernameE, @"^[a-zA-Z0-9\s]+$") || !Regex.IsMatch(selectedEmployee.PasswordE, @"^[a-zA-Z0-9\s]+$"))
                    {
                        MessageBox.Show("Для логина и пароля используйте только английские буквы и цифры");
                        selectedEmployee.UsernameE = oldUsername;
                        selectedEmployee.PasswordE = oldPassword;
                        return;
                    }

                    if (zoo.Employees.Any(s => s.UsernameE == UsernameE && s.employee_id != selectedEmployee.employee_id))
                    {
                        MessageBox.Show("Ошибка, такой логин уже существует");
                        selectedEmployee.UsernameE = oldUsername;
                        return;
                    }

                    if (zoo.Employees.Any(s => s.PasswordE == PasswordE && s.employee_id != selectedEmployee.employee_id))
                    {
                        MessageBox.Show("Ошибка, такой пароль уже существует");
                        selectedEmployee.PasswordE = oldPassword;
                        return;
                    }

                    zoo.SaveChanges();
                    EmployeeGrid.ItemsSource = zoo.Employees.ToList();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при обновлении сотрудника");
            }
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeGrid.SelectedItem != null)
            {
                zoo.Employees.Remove(EmployeeGrid.SelectedItem as Employees);
                zoo.SaveChanges();
                EmployeeGrid.ItemsSource = zoo.Employees.ToList();
            }
        }

        private void EmployeeGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeeGrid.SelectedItem != null)
            {
                var selectedEmployee = EmployeeGrid.SelectedItem as Employees;
                LastNameBx.Text = selectedEmployee.last_name;
                FirstNameBx.Text = selectedEmployee.first_name;
                MiddleNameBx.Text = selectedEmployee.middle_name;
                LoginBx.Text = selectedEmployee.UsernameE;
                PasswordBx.Text = selectedEmployee.PasswordE;

                var position = zoo.EmployeesPositions.FirstOrDefault(p => p.position_id == selectedEmployee.id_position);
                if (position != null)
                {
                    PositionComboBox.SelectedItem = position;
                }
            }
        }

        private void PositionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PositionComboBox.SelectedItem != null)
            {
                var selectedPosition = PositionComboBox.SelectedItem as EmployeesPositions;
                PositionComboBox.Text = selectedPosition.name_position;
            }
        }
    }
}
