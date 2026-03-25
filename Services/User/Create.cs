namespace OpticsShop.Services.User
{
    using OpticsShop.Database.Entities;
    using OpticsShop.Database.Models;
    using OpticsShop.Services.FileIO.Reader;
    using OpticsShop.Services.FileIO.Writer;

    internal class Create
    {
        private User user;
        public Create(UserViewModel newUser)
        {
            GetAllUsers();
            RegisterUser(newUser);
            
        }

        public List<UserViewModel> AllUsers { get; set; }

        public async Task<bool> RegisterUser(UserViewModel newUser)
        {
            string input = "";

            do
            {
                // проверка на името
                if (!IsAvailable(newUser.Name))
                {
                    // 1. налично - регистрация
                    Console.WriteLine("Потребителското име е заето.");
                    Console.WriteLine("Моля, изберете ново или натиснете [Q] за изход.");
                    input = Console.ReadLine();
                    Console.Write("Потребителско име: ");
                    newUser.Name = Console.ReadLine();
                    Console.WriteLine("Парола: ");
                    newUser.Password = Console.ReadLine();
                }
                else
                {
                    // 2. наличноненаличен - отваряне на допълнителни опции (запис на час, промоции)
                    MapToUser(newUser);
                    await Writer.SaveUserAsync(user);
                    Console.WriteLine("Успешна регистрация");
                    break;
                }

            } while (input != "Q");

            return true;
        }

        private void MapToUser(UserViewModel newUser)
        {
            user = new User();
            user.Name = newUser.Name;
            user.Role = new Role { RoleName = newUser.Role.RoleName };
            user.Password = newUser.Password;
        }

        private async void GetAllUsers()
        {
            Users users = new Users();
            AllUsers = await users.GetAllUsers();
        }

        private bool IsAvailable(string newUsername) => AllUsers.Any(x => x.Name == newUsername);

        // implement password hasher
    }
}
