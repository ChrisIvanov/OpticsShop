namespace OpticsShop.Database.Models
{
    using System;
    using System.Collections.Generic;

    public class PurchaseViewModel
    {
        public DateTime CreatedAt { get; set; }
        public double Total { get; set; }
        public List<ItemViewModel> Items { get; set; }
    }
}
