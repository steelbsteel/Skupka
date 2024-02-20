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
    /// Логика взаимодействия для Sells.xaml
    /// </summary>
    public partial class Sells : Page
    {
        public Sells()
        {
            InitializeComponent();
            var sells = App.Connection.Sell.Where(x => x.idUser == App.currentUser.idUser).ToList();
            if(sells.Count > 0)
            {
                SellsListView.ItemsSource = sells;
            }
            else
            {
                MessageBox.Show("Вы ещё не продали ни одного товара!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GoBackBtnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SkupchikPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new MakeSellWindow();
            window.ShowDialog();
        }
    }
}
