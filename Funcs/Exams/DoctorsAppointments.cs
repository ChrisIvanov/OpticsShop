namespace OpticsShop.Funcs.Exams
{
    using OpticsShop.Global;
    using OpticsShop.Services.Printer;
    using OpticsShop.Services.Appointment;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Services.FileIO.Reader;
    using OpticsShop.Database.Entities;
    using OpticsShop.Database.Models;

    using OpticsShop.Services.Appointment;

    internal class DoctorsAppointments
    {
        internal List<PatientViewModel> patients;
        internal List<AppointmentViewModel> appointments;
        public static List<AppointmentViewModel> appointmentsModelList;
        public static List<AppointmentViewModel> futureAppointmentsModelList;

        public DoctorsAppointments()
        {
            // PullPatientsListFromFile();
            if (patients == null) patients = new List<PatientViewModel>();
            // PullAppointmentsListFromFile();
            if (appointments == null) appointments = new List<AppointmentViewModel>();
            
            if (appointmentsModelList == null) appointmentsModelList = new List<AppointmentViewModel>();
            if (appointmentsModelList == null) futureAppointmentsModelList = new List<AppointmentViewModel>();

            this.Patients = patients;
            this.Appointments = appointments;
        }

        private List<PatientViewModel> Patients { get; set; }
        private List<AppointmentViewModel> Appointments { get; set; }

        public bool AddAppointment(DateOnly date, int timeslot, PatientViewModel patient)
        {
            Create newAppointmnet = new(date, timeslot, patient);
            return true;
        }
        //public List<AppointmentViewModel> GetAppointments()
        //{
        //    List<AppointmentViewModel> appointmentsModels = new List<AppointmentViewModel>();
        //    foreach (var appointment in Appointments)
        //    {
        //        AppointmentViewModel appointmentViewModel = new AppointmentViewModel();
        //        appointmentViewModel.Title = appointment.Title;
        //        appointmentViewModel.Description = appointment.Description;
        //        appointmentViewModel.AppointmentDate = appointment.AppointmentDate;
        //        appointmentViewModel.PatientName = appointment.Patient.Name;
        //    }

        //    return appointmentsModels;
        //}

        // списък с бъдещи часове за преглед
        private List<AppointmentViewModel> GetFutureAppointments()
        {
            return Appointments.Where(x => x.AppointmentDate >= DateTime.Today).ToList();
        }

        private void CreatePatient()
        {
            Patient newPatient = new Patient();
            newPatient.Id = GetPatientCount() + 1;

        }

        public int GetPatientCount()
        {
            return Patients.Count();
        }

        // функционалност за админи
        // проверка за права на достъп
        //public void GetAllAppointments()
        //{
        //    string path = GlobalVariables.APPOINTMENTS_FILE_PATH;
        //    string contents = File.ReadAllText(path);
        //    foreach (Appointment appointment in Appointments)
        //    {
        //        AppointmentViewModel curr = new AppointmentViewModel();
        //        curr.Title = appointment.Title;
        //        curr.Description = appointment.Description;
        //        curr.AppointmentDate = appointment.AppointmentDate;
        //        curr.PatientName = appointment.Patient.Name;

        //        appointmentsModelList.Add(curr);
        //    }
        //}

        // извличане на списъка в конзолата в табличен формат
        public async void PrintAllFutureAppointments()
        {
            var table = new AsciiTable
            {
                Title = "Записани часове за преглед"
            }
            .AddColumn("Пореден номер", 4)
            .AddColumn("Име", 20)
            .AddColumn("Дата", 10)
            .AddColumn("Описание", 10);

            var appointments = new Appointments();
            List<AppointmentViewModel> futureAppointments = await appointments.GetAllFutureAppointments();

            for (int i = 0; i < futureAppointments.Count; i++)
            {
                AppointmentViewModel curr = futureAppointments[i];
                int rowCounter = i + 1;
                table.AddRow(rowCounter, curr.PatientName, curr.AppointmentDate, curr.Description);
            }


            table.Write();
        }
    }
}
