using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL;
using WebApp.Models;
using System.Linq;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly HospitalDB _context;

        public AdminController(HospitalDB context)
        {
            _context = context;
        }

        public async Task <IActionResult> Index()
        {
            // Get the "Member" role id
            //var memberRole = _context.Roles.FirstOrDefault(r => r.Name == "Member");
            //if (memberRole == null)
            //{
            //    ViewBag.Patients = new List<WebApp.Models.Member>();
            //}
            //else
            //{
            //    // Get user ids that have the "Member" role
            //    var memberIds = _context.UserRoles
            //        .Where(ur => ur.RoleId == memberRole.Id)
            //        .Select(ur => ur.UserId)
            //        .ToList();

            //    // Get only users with the "Member" role
            //    var patients = _context.Members
            //        .Where(m => memberIds.Contains(m.Id))F
            //        .ToList();

            //    ViewBag.Patients = patients;
            //}

            var appointments = await _context.AppointmentDefinitions
                //.Include(a => a.PatientName)
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.Polyclinic)
                .Include(a => a.Time)
                .Include(a => a.Date)
                .ToListAsync();


            ViewBag.AppointmentDefinitions = appointments;

            return View();
        }
    }
}
