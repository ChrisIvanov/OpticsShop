namespace OpticsShop.Services.Printer.Products
{
    using OpticsShop.Services.FileIO.Reader;
    using OpticsShop.Services.FileIO.Writer;
    using System;

    internal class PrintDeleteProductForm
    {
        public PrintDeleteProductForm()
        {
            Print();
        }

        private async void Print()
        {
            Console.WriteLine("Меню изтриване на продукт.");
            Console.Write("Въведете референтния номер на продукта.");

            string referenceNumber = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(referenceNumber))
            {
                Console.WriteLine("Референтният номер не може да бъде празен. Моля, опитайте отново.");
                return;
            }

            int.TryParse(referenceNumber, out int itemId);

            var allItems = await Items.GetAllItems();

            var isSuccessfullyRemoved = allItems.Remove(allItems.Where(x => x.Id == itemId).FirstOrDefault());

            await Writer.SaveItemsAsync(allItems);

            if (isSuccessfullyRemoved)
            {
                await Writer.SaveItemsAsync(allItems);
                Console.WriteLine("Успешно изтрит продукт.");
                return;
            }
            else
            {
                Console.WriteLine("Неуспешно изтриване на продукта. Моля, проверете референтния номер и опитайте отново.");
                return;

            }
        }
    }
}
