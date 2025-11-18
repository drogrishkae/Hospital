namespace WebApp.Models
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public int PolyclinicID { get; set; }
        public Polyclinic? Polyclinic { get; set; }
        public ICollection<DateEntity>? DateEntities { get; set; } 
        public ICollection<AppointmentDefinition>? AppointmentDefinitions { get; set; }
    }

}
