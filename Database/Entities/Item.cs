namespace OpticsShop.Database.Entities
{
    internal class Item
    {
        internal int Id { get; set; }
        internal string Name { get; set; }
        internal string Descripton { get; set; }
        internal double Price { get; set; }
        internal int Quantity { get; set; }
        internal bool IsInStock { get; set; }
    }
}
