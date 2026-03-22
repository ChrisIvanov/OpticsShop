namespace OpticsShop.Database.Entities
{
    using System.Runtime.InteropServices;

    internal class Appointment
    {
        internal int Id { get; set; }
        internal string Title { get; set; }
        internal string Description { get; set; }
        internal DateTime CreatedDate { get; set; }
        internal DateTime AppointmentDate { get; set; }
        internal Patient Patient { get; set; }

    }
}
