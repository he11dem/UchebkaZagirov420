using Microsoft.Win32;
using SuperSchool420.DB;
using System;
using System.Collections.Generic;
using System.Data.Common;
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

namespace SuperSchool420.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public static List<Service> services { get; set; }
        public static Service ser = new Service();
        public AddWindow()
        {
            InitializeComponent();
            services = new List<Service>(DBConnection.super.Service.ToList());
            this.DataContext = this;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            ser.Title = NameTB.Text;
            ser.Cost = Convert.ToInt32(CostTB.Text);
            //ser.DurationInSeconds = Convert.ToInt32(DurationTB.Text);
            //ser.Discount =Convert.ToInt32(SaleTB.Text);
            //ser.Description = DescriptionTB.Text;

            DBConnection.super.Service.Add(ser);
            DBConnection.super.SaveChanges();
            this.DialogResult = true;
            MessageBox.Show("Товар успешно добавлен!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ClouseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
        private void changeBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                TestImg.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            };
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void AddPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == true)
            {
                TestImg.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }
    }
}
