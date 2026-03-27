namespace OpticsShop.Database.Models
{

    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public RoleViewModel Role { get; set; } 
        public string Description { get; set; } = string.Empty;
        public List<PurchaseViewModel> Purchases { get; set; } = new List<PurchaseViewModel>();
        public string Password { get; set; } = string.Empty;
    }
}
