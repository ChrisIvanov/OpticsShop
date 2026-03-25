namespace OpticsShop.Services.Printer.Products
{
    using OpticsShop.Global;
    using OpticsShop.Services.FileIO.Reader;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class PrintProducts
    {
        public PrintProducts()
        {
            Print();
        }

        private async void Print()
        {
            var table = new AsciiTable()
                    .AddColumn("ID", 4)
                    .AddColumn("Модел", 20)
                    .AddColumn("Цена", 10)
                    .AddColumn("Наличност", 10);

            var allProducts = await Items.GetAllItems();
            int count = 1;
            foreach (var product in allProducts)
            {
                table.AddRow(count++, product.Name, product.Price, product.IsInStock ? "Да" : "Не");
            }
            table.AddRow(1, "Ray-Ban Aviator", "299.99", "Да");
            table.AddRow(2, "Optimus Prime Titanium Edition", "459.00", "Не");
            table.AddRow(3, "Classic Frame", "129.50", "Да");

            table.Write();
        }

        public void PrintAddProductForm()
        {

            
        }
    }
}
