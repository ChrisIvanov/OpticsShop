namespace OpticsShop
{
    using OpticsShop.Database;
    using OpticsShop.Services.Printer;

    internal class Program
    {
        static void Main(string[] args)
        {
            new MainTitle();
            string input;
            while (true)
            {
                MainMenu mainMenu = new MainMenu();
               
                input = Console.ReadLine();
                if (input == "Край") return;

                mainMenu.Selection(input);

                

            }
        }
    }
}
