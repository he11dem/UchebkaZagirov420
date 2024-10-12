using SuperSchool420.Pages;
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

namespace SuperSchool420.Windows
{
    /// <summary>
    /// Логика взаимодействия для PasswordWindow.xaml
    /// </summary>
    public partial class PasswordWindow : Window
    {
        public PasswordWindow()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void VxodBT_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordPB.Password == "0000")
            {
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный пароль! Попробуйте еще раз.");
            }
        }

        private void checkPass_Checked(object sender, RoutedEventArgs e)
        {
            PasswordPB.PasswordChar = '0';
        }

        private void checkPass_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordPB.PasswordChar = '*';
        }

    
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Получите ссылку на текущее окно
            Window currentWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);

            // Закройте текущее окно, если оно существует
            if (currentWindow != null)
            {
                currentWindow.Close();
            }
        }
    }
}
