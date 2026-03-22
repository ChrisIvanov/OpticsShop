namespace OpticsShop.Database.Models
{
    using System;

    public class AppointmentViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string PatientName { get; set; }
    }
}
