namespace OpticsShop.Database.Entities
{
    internal class Patient : User
    {
        internal List<Appointment> Appointments { get; set; }

    }
}
