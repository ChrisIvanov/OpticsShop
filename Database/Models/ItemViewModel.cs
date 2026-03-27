namespace OpticsShop.Database.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Descripton { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool IsInStock { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
