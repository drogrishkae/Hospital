namespace WebApp.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        
        public int MemberID { get; set; }

        public int DoctorID { get; set; }

        //public int AppointmentDefinitionsID { get; set; }

        public DateTime AppointmentDate { get; set; }

        public bool MemberArrived { get; set; }

        public int TimeID { get; set; }


        public Member? Member { get; set; }

        public AppointmentDefinition? AppointmentDefinitions { get; set; }
    }
}