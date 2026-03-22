namespace OpticsShop.Database.Models
{

    public class UserViewModel
    {
        public string Name { get; set; }
        public RoleViewModel Role { get; set; }
        public string Description { get; set; }
        public List<PurchaseViewModel> Purchases { get; set; }
        public string Password { get; set; }
    }
}
