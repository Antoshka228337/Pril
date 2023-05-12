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

namespace Finaly2
{
    /// <summary>
    /// Логика взаимодействия для Second.xaml
    /// </summary>
    public partial class Second : Window
    {
        public Second()
        {
            InitializeComponent();

            if(MainWindow.Globals.UserRole==1)
            {
                Adminchik.Visibility = Visibility.Visible;
                Userok.Visibility = Visibility.Hidden;
            }
            else
            {
                Adminchik.Visibility = Visibility.Hidden;
                Userok.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
