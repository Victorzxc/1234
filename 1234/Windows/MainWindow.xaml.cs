using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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

namespace _1234
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<User> users = Singletone.DB.User.Where(user => user.login == login.Text && user.password == password.Password).ToList();
            if  (users.Count == 1 ) 
            {
                User user = users[0];
                List<string> roles = new List<string>() ;
                string separator = ", ";

                foreach (Role role in user.Role)
                {
                    roles.Add(role.Name);

                }
                MessageBox.Show($"Здравствуйте, {user.login}, ваши роли: {String.Join(separator, roles)}");
                if (roles.Contains("Зав отделения"));
                {
                    ZavOtdeleniem zavOtdeleniem = new ZavOtdeleniem();
                    Hide();
                    zavOtdeleniem.ShowDialog();
                    Show();
                }
                if (!roles.Contains("Зав отделения")) ;
                {
                    Window1 window11 = new Window1();
                    Hide();
                    window11.ShowDialog();
                    Show(); 
                }
                Window1 window1 = new Window1();
                Hide();
                window1.ShowDialog();
                Show();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
