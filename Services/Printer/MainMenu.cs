namespace OpticsShop.Services.Printer
{
    using OpticsShop.Database.Models;
    using OpticsShop.Services.Printer.Appointments;
    using OpticsShop.Services.Printer.Contacts;
    using OpticsShop.Services.Printer.Products;
    using OpticsShop.Services.Printer.User;
    using OpticsShop.Services.User;
    using System;
    using System.Text;

    internal class MainMenu
    {
        public MainMenu()
        {
            Print();
        }

        public UserViewModel AuthenticatedUser { get; set; }

        private void Print()
        {
            AuthenticatedUser = Authenticate.GetAuthenticatedUser();
            bool userIsAuthenticated = Authenticate.GetAuthenticatedUser() != new UserViewModel();
            StringBuilder sb = new StringBuilder();

            if (userIsAuthenticated)
            {
                sb.AppendLine($"\r\nЗдравейте, {AuthenticatedUser.Name}!");
            }
            sb.AppendLine("\r\nИзберете опция от основното меню:");
            sb.AppendLine("1. Разгледайте продуктите.");
            sb.AppendLine("2. Запишете час за преглед.");
            sb.AppendLine("3. Разговаряйте с наш представаител.");
            if (userIsAuthenticated)
            {
                sb.AppendLine("4. Изход от прифла.");
            }
            else
            {
                sb.AppendLine("4. Вход в профил/Регистрация.");
            }


            if (AuthenticatedUser != null)
            {
                if (AuthenticatedUser.Role.RoleName == "Admin")
                {
                    sb.AppendLine("\r\n Администраторски досъп...");
                    sb.AppendLine("5. Добавяне на нов администратор.");
                    sb.AppendLine("6. Добавяне на продукт.");
                    sb.AppendLine("7. Изтриване на продукт.");
                }
            }

            Console.WriteLine(sb);
        }

        internal void Selection(string input)
        {
            AuthenticatedUser = Authenticate.GetAuthenticatedUser();
            bool userIsAuthenticated = Authenticate.GetAuthenticatedUser() != new UserViewModel();
            if (!userIsAuthenticated)
            {

                switch (input)
                {
                    case "1": new PrintProducts(); break;
                    case "2": new PrintAppointmentForm(); break;
                    case "3": new PrintContactForm(); break;
                    case "4": new PrintAuthenticationForm(); break;
                    default:
                        break;
                }
            }
            else if (userIsAuthenticated && AuthenticatedUser.Role.RoleName == "Admin")
            {
                switch (input)
                {
                    case "1": new PrintProducts(); break;
                    case "2": new PrintAppointmentForm(); break;
                    case "3": new PrintContactForm(); break;
                    case "4": new PrintAuthenticationForm(); break;
                    case "5": new PrintAddAdminForm(); break;
                    case "6": new PrintAddProductForm(); break;
                    case "7": new PrintDeleteProductForm(); break;
                    default:
                        break;
                }
            }
        }
    }
}
