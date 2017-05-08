using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GameStore.ViewModels
{
    public class PurchaseDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? PurchaseDate { get; set; }

        public int PurchaseCount { get; set; }
    }
}