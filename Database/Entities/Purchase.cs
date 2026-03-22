namespace OpticsShop.Database.Entities
{
    internal class Purchase
    {
        internal int Id { get; set; }
        internal DateTime CreatedAt { get; set; }
        internal double Total { get; set; }
        internal List<Item> Items { get; set; } = new List<Item>();
    }
}
