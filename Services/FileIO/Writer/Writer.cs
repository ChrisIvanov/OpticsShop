namespace OpticsShop.Services.FileIO.Writer
{
    using OpticsShop.Database.Entities;
    using OpticsShop.Database.Models;
    using OpticsShop.Global;
    using OpticsShop.Services.FileIO.Reader;
    using OpticsShop.Services.Patient;
    using System;
    using System.Text.Json;

    public static class Writer
    {
        // метод за записване на данни в JSON формат
        public static async Task SaveAppointmentsAsync(AppointmentViewModel appointment)
        {
            string filePath = GlobalVariables.APPOINTMENTS_FILE_PATH;

            List<Appointment> appointments = await Reader.LoadFromFileAsync<Appointment>(filePath);

            appointment.Id = appointments.Count;
            var newAppointment = MapToAppointment(appointment);
            AddAppointmentToPatient.Attach(newAppointment);
            appointments.Add(newAppointment);

            string json = JsonSerializer.Serialize(appointments, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            await File.WriteAllTextAsync(filePath, json);
        }


        public static async Task SaveUserAsync(User user)
        {
            string filePath = GlobalVariables.USERS_FILE_PATH;

            List<User> users = await Reader.LoadFromFileAsync<User>(filePath);

            user.Id = users.Count;
            users.Add(user);

            string json = JsonSerializer.Serialize(users, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            await File.WriteAllTextAsync(filePath, json);
        }

        public static async Task SaveItemAsync(ItemViewModel item)
        {
            string filePath = GlobalVariables.ITEMS_FILE_PATH;

            List<Item> items = await Reader.LoadFromFileAsync<Item>(filePath);

            int itemId = items.Count;
            var newItem = MapToItem(item);

            var itemExists = items.Any(x => x.Name == newItem.Name);

            if (itemExists)
            {
                Console.WriteLine("Продукт с това име вече съществува. Моля, изберете друго име за продукта.");
                return;
            }
            else
            {
                newItem.Id = itemId;
                items.Add(newItem);

                string json = JsonSerializer.Serialize(items, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                await File.WriteAllTextAsync(filePath, json);
            }
        }

        public static async Task SaveItemsAsync(List<ItemViewModel> items)
        {
            string filePath = GlobalVariables.ITEMS_FILE_PATH;

            List<Item> newItemsList = new();

            foreach (var _currItem in items)
            {
                int itemId = items.Count;
                var newItem = MapToItem(_currItem);

                newItem.Id = itemId;
                newItemsList.Add(newItem);

                string json = JsonSerializer.Serialize(newItemsList, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                await File.WriteAllTextAsync(filePath, json);
            }
        }

        private static Item MapToItem(ItemViewModel item)
            => new Item
            {
                Name = item.Name,
                Price = item.Price,
                Descripton = item.Description,
                Quantity = item.Quantity,
                IsInStock = item.IsInStock
            };

        public static Appointment MapToAppointment(AppointmentViewModel appointment)
            => new Appointment
            {
                Id = appointment.Id,
                Title = appointment.Title,
                Description = appointment.Description,
                AppointmentDate = appointment.AppointmentDate,
                PatientName = appointment.PatientName
            };
    }
}
