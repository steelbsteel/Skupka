using Skupka.Classes;
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
    /// Логика взаимодействия для WorkersPage.xaml
    /// </summary>
    public partial class WorkersPage : Page
    {
        public WorkersPage()
        {
            InitializeComponent();
            List<WorkerOutputClass> workersList = new List<WorkerOutputClass>();
            var listWorkers = App.Connection.User.Where(x => x.idUser != App.currentUser.idUser).ToList();
            if(listWorkers.Count > 0)
            {
                foreach(var user in listWorkers)
                {
                    WorkerOutputClass worker = new WorkerOutputClass(user);
                    workersList.Add(worker);
                }
                WorkersListView.ItemsSource = workersList;
            }
        }

        private void GoBackBtnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
