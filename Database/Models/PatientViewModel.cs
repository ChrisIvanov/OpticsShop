namespace OpticsShop.Database.Models
{
    public class PatientViewModel : UserViewModel
    {
        public List<AppointmentViewModel> Appointments { get; set; }
    }
}
