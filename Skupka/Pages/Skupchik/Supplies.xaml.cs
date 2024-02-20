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
    /// Логика взаимодействия для Supplies.xaml
    /// </summary>
    public partial class Supplies : Page
    {
        public Supplies()
        {
            InitializeComponent();
            var supplies = App.Connection.ProductAdmission.Where(x => x.idUser == App.currentUser.idUser).ToList();
            if(supplies.Count > 0)
            {
                SuppliesList.ItemsSource = supplies;
            }
            else
            {
                MessageBox.Show("Вы ещё не сформировали ни одной поставки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GoBackBtnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
