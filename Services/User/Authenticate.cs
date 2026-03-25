namespace OpticsShop.Services.User
{
    using System;
    using Services.FileIO.Reader;
    using Database.Models;

    public class Authenticate
    {
        public bool userIsAdmin = false;
        public bool userIsAuthenticated = false;
        public UserViewModel currentUser;
        private List<UserViewModel> allUsersList;

        public Authenticate(UserViewModel userViewModel)
        {
            currentUser = userViewModel;
            AuthenticatedUser = new UserViewModel();
            AllUsersList = new List<UserViewModel>();
            this.GetAllUsers();
            AuthenticateUser(userViewModel.Name, userViewModel.Password);
        }

        public List<UserViewModel> AllUsersList { get; set; }
        public UserViewModel NewUser { get; set; }
        public static UserViewModel AuthenticatedUser { get; set; }

        public static UserViewModel GetAuthenticatedUser()
        {
            return AuthenticatedUser;
        }

        public void AuthenticateUser(string username, string password)
        {
            if(AllUsersList.Any(x => x.Name == username && x.Password == password))
            {
                AuthenticatedUser = AllUsersList.Where(x => x.Name == username && x.Password == password).FirstOrDefault();
            }
            else 
            {
                Console.WriteLine("Нов потребител. Създаване.");
                new Create(currentUser);
            }
        }

        public bool IsCurrentUserAdmin()
        {
            if (AuthenticatedUser.Role.RoleName == "Admin") return true;

            return false;
        }

        private async Task GetAllUsers()
        {   
            Users users = new Users();
            AllUsersList = await users.GetAllUsers();
        }

    }
}
