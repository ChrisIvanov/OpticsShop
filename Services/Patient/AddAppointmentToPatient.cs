namespace OpticsShop.Services.Patient
{
    using OpticsShop.Database.Models;
    using OpticsShop.Services.User;
    using OpticsShop.Database.Entities;
    using OpticsShop.Services.FileIO.Reader;
    using System;

    internal static class AddAppointmentToPatient
    {
        public static void Attach(Appointment appointent)
        {
            UserViewModel user = Authenticate.GetAuthenticatedUser();
            appointent.PatientName = user.Name;
            appointent.PatientId = user.Id;
        }
    }
}
