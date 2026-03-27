namespace OpticsShop.Services.Printer.User
{
    using OpticsShop.Services.User;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class PrintLogoutForm
    {
        public PrintLogoutForm()
        {
            Print();
        }

        private void Print()
        {
            Authenticate.AuthenticatedUser = null;
             Console.WriteLine("Успешно излязохте от профила си. До скоро!");
        }
    }
}
