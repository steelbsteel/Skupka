
using Skupka.DB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Skupka
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SkupkaEntities2 Connection = new SkupkaEntities2();
        public static User currentUser {  get; set; }
    }
}
