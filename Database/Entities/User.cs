namespace OpticsShop.Database.Entities
{
    internal class User
    {
        internal int Id { get; set; }
        internal string Name { get; set; }
        internal string Description { get; set; }
        internal Role Role { get; set; }
        internal List<Purchase> Purchases { get; set; }
    }
}
