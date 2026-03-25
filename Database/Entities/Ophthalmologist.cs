namespace OpticsShop.Database.Entities
{
    using OpticsShop.Database.Entities.Interfaces;
    using System;

    public class Ophthalmologist : User, IStaff
    {

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public List<Appointment> appointments { get; set; } = new List<Appointment>();


    }
}