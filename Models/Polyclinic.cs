namespace WebApp.Models
{
    public class Polyclinic
    {
        public int PolyclinicID { get; set; }
        public string PolyclinicName { get; set; }
        public string Image { get; set; }
        public ICollection<Doctor>? Doctors { get; set; } // Add this for navigation
        public ICollection<AppointmentDefinition>? AppointmentDefinitions { get; set; }
    }
}
