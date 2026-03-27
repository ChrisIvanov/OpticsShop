namespace OpticsShop.Services.Printer.User
{
    using OpticsShop.Database.Models;
    using OpticsShop.Services.User;
    using OpticsShop.Services.FileIO.Reader;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class PrintAddAdminForm
    {
        public PrintAddAdminForm()
        {
            Print();
        }

        private void Print()
        {
            Console.Write("Потребителско име: ");
            string username = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(username))
            {
                Console.WriteLine("Потребителското име не може да бъде празно. Моля, опитайте отново.");
                return;
            }

            var newAdmin = new UserViewModel() 
            { 
                Name = username,
                Password = "admin123",
                Description = "Администраторски профил с пълни права.",
                Role = new RoleViewModel() 
                { 
                    RoleName = "Admin" 
                } 
            };

            Create createUser = new(newAdmin);
        }
    }
}
