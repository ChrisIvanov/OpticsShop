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

            await foreach (User user in JsonSerializer.DeserializeAsyncEnumerable<User>(stream))
            {
                UserViewModel userModel = new UserViewModel()
                {
                    Name = user.Name,
                    Role = user.Role,
                };

            }
        }
    }
}
