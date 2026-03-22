namespace OpticsShop.Services.FileIO.Reader
{
    using OpticsShop.Global;
    using Database.Models;
    using System.Threading.Tasks;
    using System.Text.Json;
    using OpticsShop.Database.Entities;

    internal class Users
    {
        public static async Task<List<UserViewModel>> GetAllUsers()
        {
            using FileStream stream = File.OpenRead(GlobalVariables.USERS_FILE_PATH);

            List<UserViewModel> result = new();

            await foreach (User user in JsonSerializer.DeserializeAsyncEnumerable<User>(stream))
            {
                UserViewModel userModel = new UserViewModel()
                {
                    Name = user.Name,
                    Role =
                    {
                        Id = user.Role.Id,
                        RoleName = user.Role.RoleName
                    },
                    Description = user.Description,
                    Purchases = MapPurchases(user.Purchases),
                };

                result.Add(userModel);
            }

            return result;
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
