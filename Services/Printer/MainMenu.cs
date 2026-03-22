namespace OpticsShop.Services.Printer
{
    using System;
    using System.Text;
    using OpticsShop.Services.Printer.Appointments;
    using OpticsShop.Services.Printer.Contacts;
    using OpticsShop.Services.Printer.Products;
    using OpticsShop.Services.Printer.User;

    internal class MainMenu
    {
        public MainMenu()
        {
            Print();
        }

        private void Print()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\r\nИзберете опция от основното меню:");
            sb.AppendLine("1. Разгледайте продуктите.");
            sb.AppendLine("2. Запишете час за преглед.");
            sb.AppendLine("3. Разговаряйте с наш представаител.");
            sb.AppendLine("4. Вход в профил/Регистрация.");

            Console.WriteLine(sb);
        }

        internal void Selection(string input)
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
    }
}
