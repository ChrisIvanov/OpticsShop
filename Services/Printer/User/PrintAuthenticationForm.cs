namespace OpticsShop.Services.Printer.User
{
    using OpticsShop.Database.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using OpticsShop.Services.User;
    using System.Threading.Tasks;

    internal class PrintAuthenticationForm
    {
        public PrintAuthenticationForm()
        {
            Print();
        }

        private void Print()

        {
            Console.WriteLine("Въведете своите потребителски данни по-долу. В случай, че нямате профил формата ще създаде нов.");
            Console.Write("Име: ");
            string username = Console.ReadLine();
            Console.Write("Парола: ");
            string password = Console.ReadLine();

            UserViewModel userModel = new UserViewModel() { Name = username, Password = password };
            new Authenticate(userModel);
        }
    }
}
