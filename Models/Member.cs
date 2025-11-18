using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Member:IdentityUser<int>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

      

        public ICollection<Appointment>? Appointments { get; set; }

    }
}