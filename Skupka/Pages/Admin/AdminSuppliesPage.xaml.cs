using Skupka.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Логика взаимодействия для AdminSuppliesPage.xaml
    /// </summary>
    public partial class AdminSuppliesPage : Page
    {
        public AdminSuppliesPage()
        {
            InitializeComponent();
            var list = App.Connection.ProductAdmission.Where(x => x.Accepted == false).ToList();
            if(list.Count > 0)
            {
                SuppliesList.ItemsSource = list;
            }
        }

        private void AcceptAdmissionBtnClick(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).Tag;
            ProductAdmission admission = App.Connection.ProductAdmission.Where(x => x.idProductAdmission == id).FirstOrDefault();
            admission.Accepted = true;
            var prStorage = App.Connection.ProductStorage.Where(x => x.idProduct == admission.idProduct).FirstOrDefault();
            prStorage.count += admission.Count;
            App.Connection.ProductAdmission.AddOrUpdate(admission);
            App.Connection.ProductStorage.AddOrUpdate(prStorage);
            App.Connection.SaveChanges();
            MessageBox.Show("Вы успешно приняли поставку!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.Navigate(new AdminMainPage());
        }

        private void GoBackBtnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void DeclineBtnClick(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).Tag;
            ProductAdmission admission = App.Connection.ProductAdmission.Where(x => x.idProductAdmission == id).FirstOrDefault();
            App.Connection.ProductAdmission.Remove(admission);
            App.Connection.SaveChanges();
            MessageBox.Show("Вы успешно отклонили поставку!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.Navigate(new AdminMainPage());
        }
    }
}
