namespace OpticsShop.Services.Printer.Appointments
{
    using System.Linq;

    internal class PrintAllFutureAppointments
    {
        public PrintAllFutureAppointments()
        {
            Print();
        }

        private async void Print()
        {
            var appointments = new FileIO.Reader.Appointments();
            var futureAppointments = await appointments.GetAllFutureAppointments();

            var table = new AsciiTable()
                   .AddColumn("Пациент", 20)
                   .AddColumn("Дата на преглед", 20);

            foreach (var appointment in futureAppointments)
            {
                table.AddRow(appointment.PatientName, appointment.AppointmentDate.ToString("dd/MM/yyyy hh:mm"));
            }
        }
    }
}
