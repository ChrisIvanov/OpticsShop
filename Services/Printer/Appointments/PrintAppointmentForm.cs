namespace OpticsShop.Services.Printer.Appointments
{
    using OpticsShop.Database.Entities;
    using OpticsShop.Database.Models;
    using OpticsShop.Services.FileIO.Reader;
    using OpticsShop.Services.FileIO.Writer;
    using OpticsShop.Services.User;
    using System.Net.Http.Headers;
    using System.Text;

    internal class PrintAppointmentForm
    {
        private int appointmentMonth;
        private int appointmentDay;
        private int appointmentTime;
        private int appointmentTimeslot;

        public PrintAppointmentForm()
        {
            if (Authenticate.AuthenticatedUser == null)
            {
                Console.WriteLine("Моля, влезте в системата с вашия потребителски профил или се регистрирайте.");
                return;
            }
            AppointmentDateTime = new DateTime();
            Console.WriteLine("Задайте дата на прегледа.");
            PrintMonth();
            PrintDate();
            PrintTime();
            Appointment = CreateAppointment();
            Writer.SaveAppointmentsAsync(Appointment);
        }

        private AppointmentViewModel CreateAppointment()
        {
            if (Appointment == null)
            {
                Appointment = new AppointmentViewModel();
            }
            Appointment.AppointmentDate = AppointmentDateTime;
            Appointment.PatientName = Authenticate.AuthenticatedUser.Name;
            Appointment.Title = "Очен преглед.";
            Appointment.Description = $"Час за преглед на {AppointmentDateTime.ToShortDateString()} от {AppointmentTime.ToShortTimeString()}.";

            return Appointment;
        }

        public AppointmentViewModel Appointment { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public TimeOnly AppointmentTime { get; set; }
        public int AppointmentTimeslot { get; set; }
        public int AppointmentDay { get; set; }
        public int AppointmentMonth { get; set; }

        private void PrintMonth()
        {
            string monthInput = "";
            bool repeat = false;

            do
            {
                string month = "Изберете месец (1-12): ";
                Console.Write(month);
                monthInput = Console.ReadLine();

                int.TryParse(monthInput, out int appointmentMonth);

                if (appointmentMonth < 1 || appointmentMonth > 12)
                {
                    Console.WriteLine("Моля, въведете избрания месец като число (1 - 12) или натиснете [Q], за да напуснете формуляра.");
                    repeat = true;
                }

                AppointmentMonth = appointmentMonth;

            } while (repeat && monthInput != "Q");
        }

        private void PrintDate()
        {
            int year = DateTime.Now.Year;
            int numberOfDaysInMonth = DateTime.DaysInMonth(year, AppointmentMonth);
            bool repeat = false;
            string dayInput;

            do
            {
                Console.Write($"Изберете ден (1-{numberOfDaysInMonth}): ");

                dayInput = Console.ReadLine();

                int.TryParse(dayInput, out int appointmentDay);

                if (appointmentDay < 1 || appointmentDay > numberOfDaysInMonth)
                {
                    Console.Write($"Моля, изберете ден от месеца в указания диапазон 1 - {numberOfDaysInMonth} или натиснете [Q], за да напуснете формуляра.");
                    repeat = true;
                }
                else repeat = false;

                DateOnly appointmentDate = new DateOnly(year, AppointmentMonth, appointmentDay);
                if (IsWeekend(appointmentDate.DayOfWeek))
                {
                    Console.WriteLine("Избрали сте почивен ден.");
                    Console.WriteLine("Посочете работен ден от Понеделник до Петък.");
                    repeat = true;
                }
                else repeat = false;

                // избраният ден е в миналото
                if (appointmentDate < DateOnly.FromDateTime(DateTime.Today))
                {
                    Console.WriteLine("Избрали сте ден от миналото.");
                    Console.WriteLine("Посочете валиден ден.");
                    repeat = true;
                }
                else repeat = false;

            } while (repeat && dayInput != "Q");

            AppointmentDay = appointmentDay;
        }

        private void PrintTime()
        {
            bool repeat = false;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Изберете диапазон за часа на преглед между 10:00 и 15:00. Последният възможен час е от 14:00.");
            sb.AppendLine("Час (изберете диапазон).");
            sb.AppendLine("1. 10:00 - 10:45");
            sb.AppendLine("2. 11:00 - 11:45");
            sb.AppendLine("3. 12:00 - 12:45");
            sb.AppendLine("4. 13:00 - 13:45");
            sb.AppendLine("5. 14:00 - 14:45");

            string timeInput = "";

            do
            {
                Console.WriteLine(sb);

                timeInput = Console.ReadLine();

                int.TryParse(timeInput, out int appointmentTimeslot);

                if (appointmentTimeslot < 1 || appointmentTimeslot > 5)
                {
                    Console.Write($"Моля, изберете посочен часови диапазон или натиснете [Q], за да напуснете формуляра.");
                    repeat = true;
                }
                else repeat = false;

            } while (repeat && timeInput != "Q");

            AppointmentTimeslot = int.Parse(timeInput);

            TimeOnly appointmentTime = AppointmentTimeslot switch
            {
                1 => new TimeOnly(10, 00),
                2 => new TimeOnly(11, 00),
                3 => new TimeOnly(12, 00),
                4 => new TimeOnly(13, 00),
                5 => new TimeOnly(14, 00)
            };

            AppointmentTime = appointmentTime;
        }

        private bool IsWeekend(DayOfWeek dayOfWeek)
        {
            if (dayOfWeek == DayOfWeek.Saturday ||
                dayOfWeek == DayOfWeek.Sunday) return true;

            return false;
        }

        private void GenerateAppointmentDateTime()
        {
            int year = DateTime.Now.Year;
            DateOnly date = new DateOnly(year, AppointmentMonth, AppointmentDay);

            TimeOnly time = new TimeOnly();
            AppointmentDateTime = date.ToDateTime(time);
        }
    }
}
