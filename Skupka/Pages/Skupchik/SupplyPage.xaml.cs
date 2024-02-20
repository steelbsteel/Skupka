using Skupka.DB;
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

namespace Skupka.Pages.Skupchik
{
    /// <summary>
    /// Логика взаимодействия для SupplyPage.xaml
    /// </summary>
    public partial class SupplyPage : Page
    {
        bool isEnabled = true;
        public SupplyPage()
        {
            InitializeComponent();

            var list = App.Connection.ProductStorage.Where(x => x.idUser == App.currentUser.idUser).ToList();
            if (list.Count > 0)
            {
                ProductCB.ItemsSource = list;
            }
        }

        private void SupplyBtnClick(object sender, RoutedEventArgs e)
        {
            if (!isEnabled)
            {
                MessageBox.Show("Вы уже сформировали данную поставку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (ProductCB.SelectedItem == null || string.IsNullOrEmpty(ProductCountTB.Text))
            {
                MessageBox.Show("Заполните данные корректно!");
                return;
            }

            if(int.Parse(ProductCountTB.Text) <= 0)
            {
                MessageBox.Show("Введите корректное значение количества продукции!");
                return;
            }

            ProductAdmission prAdm = new ProductAdmission();
            prAdm.idProduct = (ProductCB.SelectedItem as ProductStorage).Product.idProduct;
            prAdm.Count = int.Parse(ProductCountTB.Text);
            prAdm.Accepted = false;
            prAdm.Date = DateTime.Now.Date;
            prAdm.idUser = App.currentUser.idUser;

            App.Connection.ProductAdmission.Add(prAdm);
            App.Connection.SaveChanges();
            MessageBox.Show("Вы успешно сформировали поставку", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
            isEnabled = false;
        }

        private void GoBackBtnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
