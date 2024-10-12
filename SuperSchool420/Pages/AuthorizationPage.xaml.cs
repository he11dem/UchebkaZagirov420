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
using SuperSchool420.Windows;

namespace SuperSchool420.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }
        private void btnLog_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientHomePage());
        }

        private void btnSot_Click(object sender, RoutedEventArgs e)
        {
            PasswordWindow passwordWindow = new PasswordWindow();
            if (passwordWindow.ShowDialog() != true) // Ожидаем результат
            {
                return;
            }
            // Если пароль введен правильно, переходим на новую страницу
            NavigationService.Navigate(new Pages.EmployeeHomePage());
        }
    }
}
