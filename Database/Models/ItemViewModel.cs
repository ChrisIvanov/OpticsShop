namespace OpticsShop.Database.Models
{
    public class ItemViewModel
    {
        public string Name { get; set; }
        public string Descripton { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool IsInStock { get; set; }
    }
}
