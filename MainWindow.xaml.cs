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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Finaly2.Model;

namespace Finaly2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txb_password.IsEnabled = false;
        }

        public static class Globals
        {
            public static int UserRole;
            public static User userinfo { get; set; }
        }

        private void btn_sign(object sender, RoutedEventArgs e)
        {
            var curentuser = AppData.db.User.FirstOrDefault(u => u.Login == txb_login.Text);
            if(curentuser != null)
            {
                Globals.UserRole = curentuser.RoleId;
                Globals.userinfo = curentuser;
                txb_password.IsEnabled = true;
                signin.Visibility = Visibility.Hidden;
                signin1.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Не тот логин");
            }

        }

        private async void btn_sign1(object sender, RoutedEventArgs e)
        {
            var curentuser1 = AppData.db.User.FirstOrDefault(u => u.Login == txb_login.Text && u.Password == txb_password.Text);
            if (curentuser1 != null)
            {
                Globals.UserRole = curentuser1.RoleId;
                Globals.userinfo = curentuser1;
                txb_login.IsEnabled = false;
                txb_password.IsEnabled=false;
                kapt.Visibility = Visibility.Visible;

                while(true)
                {
                    Random x = new Random();
                    int a = x.Next(1000, 9999);
                    txb1.Text = a.ToString();
                    await Task.Delay(10000);
                }

            }
            else
            {
                MessageBox.Show("Не тот пароль");
            }
        }
        private void btn_next(object sender, RoutedEventArgs e)
        {
            if(txb2.Text == txb1.Text)
            {
                Second second = new Second();
                second.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Не те циферки");
            }
        }
    }
}
