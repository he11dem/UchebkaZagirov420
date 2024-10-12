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
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {

        public static List<Service> Service = new List<Service>();
        public static List<Service> services { get; set; }
        public static Service ser { get; set; }
        public static Service service1 = new Service();


        private void InitializeDataInPage()
        {
            Service = new List<Service>(DBConnection.super.Service.ToList());
            NameTB.Text = DBConnection.super.Service.ToList().ToString();
            CostTB.Text = DBConnection.super.Service.ToList().ToString();
            DurationTB.Text = DBConnection.super.Service.ToList().ToString();
            SaleTB.Text = DBConnection.super.Service.ToList().ToString();
            DescriptionTB.Text = DBConnection.super.Service.ToList().ToString();
        }

        public EditWindow(DB.Service selectedService)
        {
            InitializeComponent();
            InitializeDataInPage();
            service1 = selectedService;
            ser = selectedService;
            this.DataContext = this;
        }
        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void ClouseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
        private void RedactBtn_Click(object sender, RoutedEventArgs e)
        {
            Service service = service1;
            service.Title = NameTB.Text;
            service.Cost = Convert.ToInt32(CostTB.Text);
            service.DurationInSeconds = Convert.ToInt32(DurationTB.Text);
            //if(SaleTB != null)
            //{
            //    service.Discount = Convert.ToDouble(SaleTB.Text);
            //}
            //else
            //{
            //    service.Discount = null;
            //}
            //if (DescriptionTB != null)
            //{
            //    service.Description = DescriptionTB.Text;
            //}
            //else
            //{
            //    service.Description = null;
            //}

            DBConnection.super.SaveChanges();

            MessageBox.Show("Данные изменены!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            this.DialogResult = true;
        }

       

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EditPhotoBtn_Click(object sender, RoutedEventArgs e)
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
