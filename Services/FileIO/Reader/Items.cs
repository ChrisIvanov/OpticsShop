namespace OpticsShop.Services.FileIO.Reader
{
    using OpticsShop.Database.Entities;
    using OpticsShop.Database.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Items
    {
        public static async Task<List<ItemViewModel>> GetAllItems()
        {
            string filePath = Global.GlobalVariables.ITEMS_FILE_PATH;
            if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
                return new List<ItemViewModel>();
            using FileStream stream = File.OpenRead(filePath);
            List<Item>? items = await Reader.LoadFromFileAsync<Item>(filePath);
            return MapItemsToModel(items);

        }

        private static List<ItemViewModel> MapItemsToModel(List<Item> items)
            =>  items.Select(item => new ItemViewModel
                {
                    IsInStock = item.IsInStock,
                    Quantity = item.Quantity,
                    Name = item.Name,
                    Descripton = item.Descripton,
                    Price = item.Price
                }).ToList();
    }
}
