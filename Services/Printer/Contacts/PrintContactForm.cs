namespace OpticsShop.Services.Printer.Contacts
{
    using OpticsShop.Database.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;

    internal class PrintContactForm
    {
        private string contactDetail;
        private Patient patient;
        public PrintContactForm()
        {
            Print();
        }

        private void Print()
        {
            bool repeat = false;
            string email = string.Empty;
            do
            {
                Console.WriteLine("Моля, оставете имейл адрес за контакт и въпроса си. Ние ще се свържем с Вас веднага!");
                Console.Write("Въведете Вашата електронна поща: ");
                email = Console.ReadLine();

                var trimmedEmail = email.Trim();

                if (trimmedEmail.EndsWith(".") || string.IsNullOrEmpty(contactDetail))
                {
                    repeat = true;
                }

                try
                {
                    repeat = !new EmailAddressAttribute().IsValid(trimmedEmail);
                }
                catch
                {
                    repeat = true;
                }

                if (repeat)
                { 
                    Console.WriteLine("Моля, въведете електронна поща или натиснете [Q] за изход.");
                }

            } while (repeat || email != "Q");
        }
    }
}
