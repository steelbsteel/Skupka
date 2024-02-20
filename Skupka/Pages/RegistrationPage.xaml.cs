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

namespace Skupka.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void GoBackBtnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void RegistrationBtnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTB.Text) || string.IsNullOrEmpty(SurnameTB.Text) ||
                string.IsNullOrEmpty(PasswordBox.Password) || string.IsNullOrEmpty(LoginTB.Text))
            {
                MessageBox.Show("Проверьте правильность введенных данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                var checkLoginExists = App.Connection.Authorization.FirstOrDefault(x => x.Login == LoginTB.Text);
                if (checkLoginExists != null)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует. Измените логин", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                Authorization auth = new Authorization();
                auth.Login = LoginTB.Text;
                auth.Password = PasswordBox.Password;
                App.Connection.Authorization.Add(auth);
                App.Connection.SaveChanges();
                User user = new User();
                user.Name = NameTB.Text;
                user.Surname = SurnameTB.Text;
                user.idAuthorization = auth.idAuthorization;
                user.idRole = 2;
                App.Connection.User.Add(user);
                App.Connection.SaveChanges();
                MessageBox.Show("Вы успешно зарегистрировались", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new AuthorizationPage());
            }
        }
        
    }
}
