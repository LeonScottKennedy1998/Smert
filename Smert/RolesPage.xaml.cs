using System;
using System.Collections.Generic;
using System.Data;
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

namespace Smert
{
    /// <summary>
    /// Логика взаимодействия для RolesPage.xaml
    /// </summary>
    public partial class RolesPage : Page
    {
        private ZooAnimalHomeEntities zoo = new ZooAnimalHomeEntities();

        public RolesPage()
        {
            InitializeComponent();
            RoleGrid.ItemsSource = zoo.EmployeesPositions.ToList();
        }

        private void DeleteRoleButton_Click(object sender, RoutedEventArgs e)
        {
            if (RoleGrid.SelectedItem != null)
            {
                zoo.EmployeesPositions.Remove(RoleGrid.SelectedItem as EmployeesPositions);
                zoo.SaveChanges();
                RoleGrid.ItemsSource = zoo.EmployeesPositions.ToList();
            }
        }

        private void SaveRoleButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RoleNameTextBox.Text))
            {
                MessageBox.Show("Ошибка, поле должно быть заполнено");
                return;
            }
            string roleName = RoleNameTextBox.Text;

            if (roleName.Any(char.IsDigit) || roleName.Any(char.IsSurrogate))
            {
                MessageBox.Show("Поле должно содержать только текст без цифр и смайликов.");
                return;
            }
            if (zoo.EmployeesPositions.Any(p => p.name_position == roleName))
            {
                MessageBox.Show("Ошибка, такая роль уже существует");
                return;
            }
            if (RoleGrid.SelectedItem != null)
            {
                try
                {
                    var selectedRole = RoleGrid.SelectedItem as EmployeesPositions;
                    selectedRole.name_position = roleName;
                    zoo.SaveChanges();
                    RoleGrid.ItemsSource = zoo.EmployeesPositions.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка при изменении роли");
                }
            }
        }

        private void RoleGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RoleGrid.SelectedItem != null)
            {
                var selectedRole = RoleGrid.SelectedItem as EmployeesPositions;

                RoleNameTextBox.Text = selectedRole.name_position;

            }

        }

        private void AddRoleButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RoleNameTextBox.Text))
            {
                MessageBox.Show("Ошибка, поле должно быть заполнено");
                return;
            }
            string roleName = RoleNameTextBox.Text;

            if (roleName.Any(char.IsDigit) || roleName.Any(char.IsSurrogate))
            {
                MessageBox.Show("Поле должно содержать только текст без цифр и смайликов.");
                return;
            }
            if (zoo.EmployeesPositions.Any(p => p.name_position == roleName))
            {
                MessageBox.Show("Ошибка, такая роль уже существует");
                return;
            }
            try
            {
                EmployeesPositions positionname = new EmployeesPositions();
                positionname.name_position = roleName;

                zoo.EmployeesPositions.Add(positionname);

                zoo.SaveChanges();
                RoleGrid.ItemsSource = zoo.EmployeesPositions.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при добавлении роли");
            }
        }

       
    }
}
