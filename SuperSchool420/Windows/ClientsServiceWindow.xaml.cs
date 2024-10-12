using SuperSchool420.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;


namespace SuperSchool420.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientsServiceWindow.xaml
    /// </summary>
    public partial class ClientsServiceWindow : Window
    {
        public static List<ClientService> clientServices { get; set; }
        public static List<Client> clients { get; set; }
        public static List<Service> services { get; set; }
        public ClientsServiceWindow()
        {
            InitializeComponent();
            clientServices = new List<ClientService>(DBConnection.super.ClientService.ToList());
            clients = new List<Client>(DBConnection.super.Client.ToList());
            services = new List<Service>(DBConnection.super.Service.ToList());
            Refresh();
            this.DataContext = this;
        }

        private void Refresh()
        {
            DateTime yesterday = DateTime.Now;
            DateTime tomorrow = DateTime.Today.AddDays(1);
            var filteredItems = DBConnection.super.ClientService.Where(i => i.StartTime >= yesterday).ToList();
            var sortedData = filteredItems.OrderBy(row => DateTime.Parse(row.StartTime.ToString()));
            ProductLV.ItemsSource = sortedData; 
        }


        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
