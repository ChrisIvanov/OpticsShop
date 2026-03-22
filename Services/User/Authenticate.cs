namespace OpticsShop.Services.User
{
    using System;
    using Services.FileIO.Reader;
    using Database.Models;
    using OpticsShop.Database.Entities;

    public static class Authenticate
    {
        public async static Task<bool> IsUserRegistered()
        {
            // изтегляне на данни от записите
            List<UserViewModel> allusers = await Users.GetAllUsers();

            // проверка на името

            // 1. налично - отваряне на допълнителни опции (запис на час, промоции)

            // 2. неналичен - регистрация

            return true;
        }

        
    }
}
