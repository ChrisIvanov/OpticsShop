namespace OpticsShop.Services.FileIO.Reader
{
    using OpticsShop.Database.Entities;
    using OpticsShop.Database.Models;
    using OpticsShop.Global;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class Appointments
    {
        public async Task<List<AppointmentViewModel>> GetAllFutureAppointments()
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);

            List<AppointmentViewModel> result = new List<AppointmentViewModel>();

            var filePath = File.ReadAllText(GlobalVariables.APPOINTMENTS_FILE_PATH);
            using FileStream stream = File.OpenRead(filePath);

            await foreach (Appointment appointment in JsonSerializer.DeserializeAsyncEnumerable<Appointment>(stream))
            {
                // допълнителни проверки TODO

                if (DateOnly.FromDateTime(appointment!.AppointmentDate) < today) continue;

                AppointmentViewModel appointmentViewModel = new AppointmentViewModel()
                {
                    Title = appointment.Title,
                    PatientName = appointment.PatientName,
                    AppointmentDate = appointment.AppointmentDate,
                    Description = appointment.Description,
                    
                };

                result.Add(appointmentViewModel);
            }

            return result
                .OrderByDescending(x => x.AppointmentDate)
                .ToList();
        }

        public async Task<bool> IsTimeSlotAvailable(DateTime appointmentDatetime)
        {
            var filePath = GlobalVariables.APPOINTMENTS_FILE_PATH;
            using FileStream stream = File.OpenRead(filePath);

            await foreach (Appointment appointment in JsonSerializer.DeserializeAsyncEnumerable<Appointment>(stream))
            {
                if (appointment.AppointmentDate == appointmentDatetime) return true;
            }

            return false;
        }
    }
}
