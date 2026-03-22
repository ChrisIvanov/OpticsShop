namespace OpticsShop.Services.Printer.User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class PrintAuthenticationForm
    {
        public PrintAuthenticationForm()
        {
            Print();
        }

        private void Print()
        {
            StringBuilder sb = new();

            sb.AppendLine("Въведете своите потребителски данни по-долу. В случай, че нямате профил формата ще създаде нов.");
            sb.Append("Име: ");
            string username = Console.ReadLine();
            sb.Append("Парола: ");
            string password = Console.ReadLine();

            Services.User.Authenticate.IsUserRegistered();
        }
    }
}
