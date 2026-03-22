namespace OpticsShop.Database.Entities
{
    using OpticsShop.Database.Entities.Interfaces;
    using System;

    internal class Ophthalmologist : User, IStaff
    {
        private readonly string name;
        private readonly string description;
        public Ophthalmologist(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Appointment> appointments { get; set; }

        
    }
}