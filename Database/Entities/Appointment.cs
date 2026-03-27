namespace OpticsShop.Database.Entities
{
    using System.Runtime.InteropServices;

    public class Appointment
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime AppointmentDate { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;

    }
}
