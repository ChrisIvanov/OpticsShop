namespace OpticsShop.Services.FileIO.Reader
{
    using OpticsShop.Global;
    using Database.Models;
    using System.Threading.Tasks;
    using System.Text.Json;
    using OpticsShop.Database.Entities;

    internal class Users
    {
        public async Task<List<UserViewModel>> GetAllUsers()
        {
            string filePath = GlobalVariables.USERS_FILE_PATH;

            if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
                return new List<UserViewModel>();

            await using FileStream stream = File.OpenRead(filePath);

            List<User>? users = await Reader.LoadFromFileAsync<User>(filePath);

            return users.Select(user => new UserViewModel
            {
                Name = user.Name,
                Password = user.Password,
                Description = user.Description,
                Purchases = user.Purchases == null ? new List<PurchaseViewModel>() : MapPurchases(user.Purchases),
                Role = new RoleViewModel
                {
                    Id = user.Role.Id,
                    RoleName = user.Role.RoleName
                }
            }).ToList();
        }

        private static List<PurchaseViewModel> MapPurchases(List<Purchase> purchases)
        {
            List<PurchaseViewModel> result = new List<PurchaseViewModel>();
            
            foreach (Purchase purchase in purchases)
            {
                PurchaseViewModel curr = new PurchaseViewModel()
                {
                    CreatedAt = purchase.CreatedAt,
                    Items = purchase.Items.Select(x => new ItemViewModel() 
                    { 
                        Descripton = x.Descripton,
                        Price = x.Price,
                        Name = x.Name
                    })
                    .ToList(),

                    Total = purchase.Total
                };

                result.Add(curr);
            }

            return result;
        }
    }
}
