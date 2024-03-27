using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ZooAnimalHomeEntities zoo = new ZooAnimalHomeEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = LoginBx.Text;
            string password = PasswordBx.Password;

            var user = zoo.Employees.SingleOrDefault(User => User.UsernameE == username && User.PasswordE == password);
            if (user != null)
            {

                if (user.id_position == 1)
                {
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                }
                else if (user.id_position == 2)
                {
                    SellerWindow sellerWindow = new SellerWindow();
                    sellerWindow.Show();
                }
                else if (user.id_position == 3)
                {
                    StorageWindow storageWindow = new StorageWindow();
                    storageWindow.Show();
                }
                else 
                {
                    NewRoleWindow newrole = new NewRoleWindow();
                    newrole.Show();
                }
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль");
            }

        }

    }
}
