using SuperSchool420.DB;
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

namespace SuperSchool420.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientHomePage.xaml
    /// </summary>
    public partial class ClientHomePage : Page
    {
        public static List<Service> services { get; set; }
        Service service1 { get; set; }
        public ClientHomePage()
        {
            InitializeComponent();
            ProductLV.ItemsSource = new List<Service>(DBConnection.super.Service.ToList());
            EditDataCount();
            this.DataContext = this;
            FiltrCb.Items.Add("По умолчанию");
            FiltrCb.Items.Add("По убыванию");
            FiltrCb.Items.Add("По возрастанию");

            FiltrSaleCb.Items.Add("от 0 до 5%");
            FiltrSaleCb.Items.Add("от 5% до 15%");
            FiltrSaleCb.Items.Add("от 15% до 30%");
            FiltrSaleCb.Items.Add("от 30% до 70%");
            FiltrSaleCb.Items.Add("от 70% до 100%");
            FiltrSaleCb.Items.Add("Все");
        }

        private void SearchTbx_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            Refresh();
            EditDataCount();
        }

        private void EditDataCount()
        {
            tbDataCount.Text = $"{ProductLV.Items.Count} из {DBConnection.super.Service.ToList().Count}";
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
        private void Refresh()
        {
            var filterProduct = DBConnection.super.Service.ToList();

            if (SearchTbx.Text.Length > 0)
            {
                filterProduct = filterProduct.Where(i => i.Title.ToLower().StartsWith(SearchTbx.Text.Trim().ToLower())).ToList();
            }

            List<Service> services = new List<Service>(DBConnection.super.Service.ToList());
            {
                services = services.Where(i => i.Title.ToLower().StartsWith(SearchTbx.Text.Trim().ToLower())
                   || i.Title.ToLower().StartsWith(SearchTbx.Text.Trim().ToLower())).ToList();
            }

            ProductLV.ItemsSource = services;

            if (FiltrCb.SelectedIndex == 0)
            {
                ProductLV.ItemsSource = services;
            }
            if (FiltrCb.SelectedIndex == 1)
            {
                ProductLV.ItemsSource = services.OrderByDescending(x => x.Cost).ToList();
            }
            if (FiltrCb.SelectedIndex == 2)
            {
                ProductLV.ItemsSource = services.OrderBy(x => x.Cost).ToList();
            }


            if (FiltrSaleCb.SelectedIndex == 0)
            {
                ProductLV.ItemsSource = services.Where(x => x.Discount >= 0 && x.Discount < 5).ToList();
            }
            if (FiltrSaleCb.SelectedIndex == 1)
            {
                ProductLV.ItemsSource = services.Where(x => x.Discount >= 5 && x.Discount < 15).ToList();
            }
            if (FiltrSaleCb.SelectedIndex == 2)
            {
                ProductLV.ItemsSource = services.Where(x => x.Discount >= 15 && x.Discount < 30).ToList();
            }
            if (FiltrSaleCb.SelectedIndex == 3)
            {
                ProductLV.ItemsSource = services.Where(x => x.Discount >= 30 && x.Discount < 70).ToList();
            }
            if (FiltrSaleCb.SelectedIndex == 4)
            {
                ProductLV.ItemsSource = services.Where(x => x.Discount >= 70 && x.Discount < 100).ToList();
            }
            if (FiltrSaleCb.SelectedIndex == 5)
            {
                ProductLV.ItemsSource = services;
            }
        }

        private void FiltrCbClik(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
            EditDataCount();
        }

        private void FiltrSaleCb_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
            EditDataCount();
        }
    }
    
}
