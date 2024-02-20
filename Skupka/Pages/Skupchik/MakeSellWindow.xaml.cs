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
using System.Windows.Shapes;

namespace Skupka.Pages.Skupchik
{
    /// <summary>
    /// Логика взаимодействия для MakeSupplyWindow.xaml
    /// </summary>
    public partial class MakeSellWindow : Window
    {
        public MakeSellWindow()
        {
            InitializeComponent();
            var list = App.Connection.ProductStorage.Where(x => x.idUser == App.currentUser.idUser).ToList();
            if(list.Count > 0)
            {
                ProductCB.ItemsSource = list;
            }
        }

        private void SupplyBtnClick(object sender, RoutedEventArgs e)
        {
            if (ProductCB.SelectedItem == null || string.IsNullOrEmpty(ProductCountTB.Text))
            {
                MessageBox.Show("Введите данные корректно!");
                return;            
            }
            if(int.Parse(ProductCountTB.Text) > (ProductCB.SelectedItem as ProductStorage).count)
            {
                MessageBox.Show("Количество продажи не может быть больше количества хранящегося на складе!");
                return;
            }

            ProductStorage prStorage = ProductCB.SelectedItem as ProductStorage;
            prStorage.count -= int.Parse(ProductCountTB.Text);
            App.currentUser.Balance += prStorage.Product.Price * int.Parse(ProductCountTB.Text);
            App.Connection.User.AddOrUpdate(App.currentUser);
            App.Connection.ProductStorage.AddOrUpdate(prStorage);
            App.Connection.SaveChanges();
            Sell sell = new Sell();
            sell.idUser = App.currentUser.idUser;
            sell.Date = DateTime.Now.Date;
            sell.idProduct = prStorage.idProduct;
            sell.Count = int.Parse(ProductCountTB.Text);
            App.Connection.Sell.Add(sell);
            App.Connection.SaveChanges();
            MessageBox.Show("Вы успешно продали товар");
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
