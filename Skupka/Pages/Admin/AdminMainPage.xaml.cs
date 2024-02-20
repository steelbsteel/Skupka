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

namespace Skupka.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminMainPage.xaml
    /// </summary>
    public partial class AdminMainPage : Page
    {
        public AdminMainPage()
        {
            InitializeComponent();
            NameSurnameTB.Text = $"{App.currentUser.Surname} {App.currentUser.Name}";
            var products = App.Connection.ProductStorage.Where(x => x.count > 0).ToList();
            if (products.Count > 0)
            {
                ProductList.ItemsSource = products;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void WorkersTBClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new WorkersPage());
        }

        private void SuppliesTBClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AdminSuppliesPage());
        }
    }
}
