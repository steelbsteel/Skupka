using Microsoft.Win32;
using Skupka.DB;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для ProductAddRequestPage.xaml
    /// </summary>
    public partial class ProductAddRequestPage : Page
    {
        Product product = new Product();
        public ProductAddRequestPage()
        {
            InitializeComponent();
            ProductCB.ItemsSource = App.Connection.ProductType.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new OpenFileDialog();

            if (window.ShowDialog() != true)
            {
                MessageBox.Show("Изображение не выбрано");
                return;
            }

            IMG.Source = new BitmapImage(new Uri(window.FileName));
            product.Image = File.ReadAllBytes(window.FileName);
        }

        private void AddProductBtnClick(object sender, RoutedEventArgs e)
        {

            List<ProductStorage> prStorages = App.Connection.ProductStorage.Where(x => x.idUser == App.currentUser.idUser).ToList();

            if (IMG.Source == null || ProductCB.SelectedItem == null || string.IsNullOrEmpty(ProductNameTB.Text) || string.IsNullOrEmpty(PriceTB.Text))
            {
                MessageBox.Show("Заполните данные корректно");
                return;
            }

            if(int.Parse(PriceTB.Text) <= 0)
            {
                MessageBox.Show("Цена товара не может быть меньше, или равна нулю!");
                return;
            }

            foreach(ProductStorage product in prStorages)
            {
                if(ProductNameTB.Text == product.Product.Title)
                {
                    MessageBox.Show("Продукт с таким названием уже существует!");
                    return;
                }
            }
            product.Title = ProductNameTB.Text;
            product.idTypeProduct = (ProductCB.SelectedItem as ProductType).idProductType;
            product.Price = int.Parse(PriceTB.Text);

            ProductStorage prStorage = new ProductStorage();
           
            App.Connection.Product.Add(product);
            App.Connection.SaveChanges();

            prStorage.idProduct = product.idProduct;
            prStorage.idUser = App.currentUser.idUser;
            prStorage.count = 0;

            App.Connection.ProductStorage.Add(prStorage);
            App.Connection.SaveChanges();
            MessageBox.Show("Продукт успешно создан", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void GoBackBtnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
