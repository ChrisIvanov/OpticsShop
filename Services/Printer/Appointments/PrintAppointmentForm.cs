namespace OpticsShop.Services.Printer.Appointments
{
    using System.Text;

    internal class PrintAppointmentForm
    {
        public PrintAppointmentForm()
        {
            Print();
        }

        private void Print()
        {
            StringBuilder sb = new();

            sb.AppendLine("Задайте дата на прегледа.");
            sb.AppendLine("Ден (1-31): ");
            sb.AppendLine("Месец (1-12: ");
            sb.AppendLine("Час (изберете диапазон).");
            sb.AppendLine("1. 10:00 - 10:45");
            sb.AppendLine("2. 11:00 - 11:45");
            sb.AppendLine("3. 12:00 - 12:45");
            sb.AppendLine("4. 13:00 - 13:45");
            sb.AppendLine("5. 14:00 - 14:45");
        }
    }
}
