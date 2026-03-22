namespace OpticsShop.Services.Appointment
{
    using OpticsShop.Database.Entities;
    using System;
    using Database.Models;
    using System.Runtime.InteropServices;

    public static class Create
    {
        private PatientViewModel patientModel; 

        public Create(DateOnly date, int timeslot, PatientViewModel patient)
        {
            GenerateAppiointmentTime(date, timeslot);
            PatientModel = patient;
            // Проверка дали съществува вече записан час
            IsTimeSlotAvailable();
            // Запазване на часа за преглед в постоянната памет
        }

        public PatientViewModel PatientModel { get; set; }

        // проверка за свободен час 
        public static bool IsTimeSlotAvailable()
        {
            Read
            return true;
        }

        private void GenerateAppiointmentTime(DateOnly date, int timeslot)
        {
            // имплементиране на 

            DateTime appointmentDate = new DateTime();
            switch (timeslot)
            {
                // 10:00 - 10:45
                case 1: appointmentDate = new DateTime(date: date, new TimeOnly(10, 0)); break;
                // 11:00 - 11:45
                case 2: appointmentDate = new DateTime(date: date, new TimeOnly(11, 0)); break;
                // 12:00 - 12:45
                case 3: appointmentDate = new DateTime(date: date, new TimeOnly(12, 0)); break;
                // 13:00 - 13:45
                case 4: appointmentDate = new DateTime(date: date, new TimeOnly(13, 0)); break;
                // 14:00 - 14:45
                case 5: appointmentDate = new DateTime(date: date, new TimeOnly(14, 0)); break;
            }

            AppointmentDate = appointmentDate;
        }
    }
}
