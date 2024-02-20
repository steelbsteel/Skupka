using Skupka.DB;
using Skupka.Pages.Skupchik;
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

namespace Skupka.Pages
{
    /// <summary>
    /// Логика взаимодействия для SkupchikPage.xaml
    /// </summary>
    public partial class SkupchikPage : Page
    {
        public SkupchikPage()
        {
            InitializeComponent();
            NameSurnameTB.Text = $"{App.currentUser.Surname} {App.currentUser.Name}";
            BalanceTB.Text = App.currentUser.Balance.ToString();
            var products = App.Connection.ProductStorage.Where(x => x.idUser == App.currentUser.idUser && x.count > 0).ToList();
            if(products.Count > 0 )
            {
                ProductList.ItemsSource = products;
            }
        }

        private void MakeSupplyTBClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new SupplyPage());
        }

        private void GoToSuppliesTBClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Supplies());
        }

        private void CreateProductTBClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ProductAddRequestPage());
        }

        private void SellsTBClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Sells());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
    }
}
