using Skupka.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skupka.Classes
{
    public class WorkerOutputClass
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public int countOfSells { get; set; }

        public int countOfProducts { get; set; }

        public WorkerOutputClass(User user)
        {
            Name = user.Name;
            Surname = user.Surname;
            var sells = App.Connection.Sell.Where(x => x.idUser == user.idUser).Count();
            var prStorages = App.Connection.ProductStorage.Where(x => x.idUser == user.idUser);
            if(sells > 0)
            {
                countOfSells = sells;
            }
            else
            {
                countOfSells = 0;
            }

            if(prStorages.Count() > 0)
            {
               foreach(var prStorage in prStorages)
               {
                    countOfProducts += prStorage.count;
               }
            }
            else
            {
                countOfProducts = 0;
            }         
        }
    }
}
