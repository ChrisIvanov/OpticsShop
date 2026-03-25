namespace OpticsShop.Database.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } 
        public double Total { get; set; } 
        public List<Item> Items { get; set; } = new List<Item>(); 
    }
}
