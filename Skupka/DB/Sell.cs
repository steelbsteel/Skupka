//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Skupka.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sell
    {
        public int idSell { get; set; }
        public int idProduct { get; set; }
        public int Count { get; set; }
        public int idUser { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}