namespace WebApp.Models
{
    public class DateEntity
    {
        public int DateEntityID { get; set; }
        public DateTime Date { get; set; }
        public int DoctorId { get; set; } 
        public Doctor Doctor { get; set; } 
        public int TimeID { get; set; } 
        public Time Time { get; set; } 
        public ICollection<AppointmentDefinition> AppointmentDefinitions { get; set; }
    }
}
