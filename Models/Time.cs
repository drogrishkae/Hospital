namespace WebApp.Models
{
    public class Time
    {
        public int TimeID { get; set; }
        public string AppointmentTimes { get; set; }
        public ICollection<AppointmentDefinition> AppointmentDefinitions { get; set; }
    }
}
