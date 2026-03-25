namespace OpticsShop.Services.FileIO.Writer
{
    using OpticsShop.Database.Entities;
    using OpticsShop.Database.Models;
    using OpticsShop.Global;
    using OpticsShop.Services.FileIO.Reader;
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

        public static Appointment MapToAppointment(AppointmentViewModel appointment)
            => new Appointment
            {
                Id = appointment.Id,
                Title = appointment.Title,
                Description = appointment.Description,
                AppointmentDate = appointment.AppointmentDate,
                Patient = new Patient
                {
                    Name = appointment.PatientName
                }
            };
    }
}
