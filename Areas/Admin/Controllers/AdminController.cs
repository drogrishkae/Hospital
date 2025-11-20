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

        //public async Task <IActionResult> Index()
        //{


        //    var appointments = await _context.AppointmentDefinitions
        //        //.Include(a => a.PatientName)
        //        .Include(a => a.Doctor)
        //            .ThenInclude(d => d.Polyclinic)
        //        .Include(a => a.Time)
        //        .Include(a => a.Date)
        //        .ToListAsync();


        //    ViewBag.AppointmentDefinitions = appointments;

        //    return View();
        //}

        public async Task<IActionResult> Index(string identificationNumber)
        {
            var query = _context.AppointmentDefinitions
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.Polyclinic)
                .Include(a => a.Time)
                .Include(a => a.Date)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(identificationNumber))
            {
                query = query.Where(a => a.IdentificationNumber.Contains(identificationNumber));
            }

            var appointments = await query.ToListAsync();

            return View(appointments); // Pass as model
        }
    }
}
