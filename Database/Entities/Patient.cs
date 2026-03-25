namespace OpticsShop.Database.Entities
{
    public class Patient : User
    {
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
