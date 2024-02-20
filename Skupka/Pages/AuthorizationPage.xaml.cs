using Skupka.DB;
using Skupka.Pages.Admin;
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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void GoBackBtnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void AuthorizeBtnClick(object sender, RoutedEventArgs e)
        {

            Authorization authCkeckExitsts = new Authorization();

            if (!string.IsNullOrEmpty(LoginTB.Text))
            {
                authCkeckExitsts = App.Connection.Authorization.FirstOrDefault(x => x.Login ==  LoginTB.Text);
            }

            if (authCkeckExitsts == null)
            {
                MessageBox.Show("Проверьте правильность логина. Такого пользователя не существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(LoginTB.Text) || string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Проверьте правильность введенных данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (authCkeckExitsts.Password == PasswordBox.Password)
            {
                MessageBox.Show("Вы успешно авторизировались", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                App.currentUser = App.Connection.User.FirstOrDefault(x => x.idAuthorization ==  authCkeckExitsts.idAuthorization);
                switch (App.currentUser.idRole)
                {
                     case 1: NavigationService.Navigate(new AdminMainPage()); break;
                     case 2: NavigationService.Navigate(new SkupchikPage()); break;
                }
            }
            else
            {
                MessageBox.Show("Проверьте правильность ввода пароля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
