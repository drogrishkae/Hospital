using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class AppointmentDefinition
    {
        public int AppointmentDefinitionID { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string PatientName { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "Invalid identification number")]
        public string IdentificationNumber { get; set; }


        public int PolyclinicID { get; set; }
        public int DoctorID { get; set; }
        public int TimeID { get; set; }

        public int MemberId { get; set; } 
        public int DateEntityId { get; set; }
        public DateEntity? Date { get; set; }
        
        public Time? Time { get; set; }
        public Polyclinic? Polyclinic { get; set; }
        public Doctor? Doctor { get; set; }

        [ValidateNever]
        public Member Member { get; set; }

        // Self-referencing relationship
        //public int? ParentAppointmentDefinitionID { get; set; }
       // public AppointmentDefinition? Parent { get; set; }
        //public ICollection<AppointmentDefinition>? Children { get; set; }
    }
}
