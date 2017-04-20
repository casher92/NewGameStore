using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStore.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int UPC { get; set; }
        public decimal Price { get; set; }
        public int Inventory { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}