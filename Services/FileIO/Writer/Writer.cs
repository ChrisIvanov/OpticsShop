namespace OpticsShop.Services.FileIO.Writer
{
    using OpticsShop.Database.Entities;
    using OpticsShop.Global;
    using OpticsShop.Services.FileIO.Reader;
    using System.Text.Json;

    public static class Writer
    {
        // метод за записване на данни в JSON формат
        public static async Task SaveAppointmentsAsync(Appointment appointment)
        {
            string filePath = GlobalVariables.APPOINTMENTS_FILE_PATH;

            List<Appointment> appointments = await Reader.LoadFromFileAsync<Appointment>(filePath);

            appointment.Id = appointments.Count;
            appointments.Add(appointment);

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
    }
}
