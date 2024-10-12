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
    /// Логика взаимодействия для AddClientsWindow.xaml
    /// </summary>
    public partial class AddClientsWindow : Window
    {
        public static ClientService clientServices = new ClientService();
        public static List<Client> clients { get; set; }
        public static List<Service> Service = new List<Service>();
        public static List<Service> services { get; set; }
        public static Service ser { get; set; }
        public static Service service1 = new Service();

        private void InitializeDataInPage()
        {
            Service = new List<Service>(DBConnection.super.Service.ToList());
        }
        public AddClientsWindow(DB.Service selectedService)
        {
            InitializeComponent();
            InitializeDataInPage();
            service1 = selectedService;
            ser = selectedService;
            Calendar.DisplayDateStart = DateTime.Now;
            clients = new List<Client>(DBConnection.super.Client.ToList());

            this.DataContext = this;
        }

        private void ClouseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
        private void AddClientsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ClientsCB.Text == "" || Calendar.Text == "")
            {
                MessageBox.Show("Заполните все данные!!!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var a = ClientsCB.SelectedItem as Client;
                clientServices.ClientID = a.ID;
                var s = ser.ID;
                clientServices.ServiceID = s;
                clientServices.StartTime = Convert.ToDateTime(Calendar.Text);

                DBConnection.super.ClientService.Add(clientServices);
                DBConnection.super.SaveChanges();
                this.DialogResult = true;
                MessageBox.Show("Запись успешно добавлена!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
