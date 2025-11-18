using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApp.DAL;
using WebApp.Models;

namespace WebApp.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class AppointmentsController : Controller
    {
        private readonly HospitalDB _context;
        private readonly UserManager<WebApp.Models.Member> _userManager;

        public AppointmentsController(HospitalDB context, UserManager<WebApp.Models.Member> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private int GetUserID()
        {
            return int.Parse(_userManager.GetUserId(User));
        }

        public IActionResult Index()
        {
            var userId = GetUserID();

            var definitions = _context.AppointmentDefinitions
                .Include(a => a.Doctor)
                .Include(a => a.Polyclinic)
                .Include(a => a.Time)
                .Include(a => a.Date)
                .Where(a => a.MemberId == userId)
                .ToList();

            return View(definitions);
        }



        [HttpGet]
        public IActionResult Create(int? polyclinicId, int? doctorId, int? dateId, int? timeId)
        {
            var polyclinics = _context.Polyclinics.ToList();
            int selectedPolyclinicId = polyclinicId ?? polyclinics.FirstOrDefault()?.PolyclinicID ?? 0;

            var doctors = _context.Doctors
                .Where(d => d.PolyclinicID == selectedPolyclinicId)
                .ToList();
            int selectedDoctorId = doctorId ?? doctors.FirstOrDefault()?.DoctorID ?? 0;

            var availableDates = _context.Dates
                .Where(de => de.DoctorId == selectedDoctorId)
                .OrderBy(de => de.Date)
                .ToList();

            int selectedDateId = dateId ?? availableDates.FirstOrDefault()?.DateEntityID ?? 0;

            var availableTimes = _context.Dates
                .Where(de => de.DoctorId == selectedDoctorId && de.DateEntityID == selectedDateId)
                .Select(de => de.TimeID)
                .Distinct()
                .Join(_context.Times, tid => tid, t => t.TimeID, (tid, t) => t)
                .ToList();

            int selectedTimeId = timeId.HasValue && availableTimes.Any(t => t.TimeID == timeId.Value)
                ? timeId.Value
                : availableTimes.FirstOrDefault()?.TimeID ?? 0;

            ViewBag.Polyclinics = new SelectList(polyclinics, "PolyclinicID", "PolyclinicName", selectedPolyclinicId);
            ViewBag.Doctors = new SelectList(doctors, "DoctorID", "DoctorName", selectedDoctorId);
            ViewBag.AvailableDates = new SelectList(
                availableDates.Select(de => new { de.DateEntityID, DateDisplay = de.Date.ToString("yyyy-MM-dd") }),
                "DateEntityID", "DateDisplay", selectedDateId
            );
            ViewBag.Times = new SelectList(availableTimes, "TimeID", "AppointmentTimes", selectedTimeId);

            var model = new AppointmentDefinition
            {
                PolyclinicID = selectedPolyclinicId,
                DoctorID = selectedDoctorId,
                DateEntityId = selectedDateId,
                TimeID = selectedTimeId
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AppointmentDefinition model, int? polyclinicId, int? doctorId, int? dateId, int? timeId)
        {
            model.PolyclinicID = polyclinicId ?? 0;
            model.DoctorID = doctorId ?? 0;
            model.DateEntityId = dateId ?? 0;
            model.TimeID = timeId ?? 0;
            model.MemberId = GetUserID();

            if (!_context.Doctors.Any(d => d.DoctorID == model.DoctorID && d.PolyclinicID == model.PolyclinicID))
                ModelState.AddModelError("DoctorID", "Selected doctor is not in the chosen polyclinic.");

            if (!_context.Dates.Any(de => de.DateEntityID == model.DateEntityId && de.DoctorId == model.DoctorID))
                ModelState.AddModelError("DateEntityId", "Selected date is not available for the chosen doctor.");

            if (!_context.Dates.Any(de => de.DateEntityID == model.DateEntityId && de.DoctorId == model.DoctorID && de.TimeID == model.TimeID))
                ModelState.AddModelError("TimeID", "Selected time is not available for the chosen doctor and date.");

            if (ModelState.IsValid)
            {
                _context.AppointmentDefinitions.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                foreach (var entry in ModelState)
                {
                    var key = entry.Key;
                    foreach (var error in entry.Value.Errors)
                    {
                        System.Diagnostics.Debug.WriteLine($"ModelState error for '{key}': {error.ErrorMessage}");
                    }
                }
            }

            var polyclinics = _context.Polyclinics.ToList();
            var doctors = _context.Doctors.Where(d => d.PolyclinicID == model.PolyclinicID).ToList();
            var availableDates = _context.Dates.Where(de => de.DoctorId == model.DoctorID).OrderBy(de => de.Date).ToList();
            var availableTimes = _context.Dates
                .Where(de => de.DoctorId == model.DoctorID && de.DateEntityID == model.DateEntityId)
                .Select(de => de.TimeID)
                .Distinct()
                .Join(_context.Times, tid => tid, t => t.TimeID, (tid, t) => t)
                .ToList();

            ViewBag.Polyclinics = new SelectList(polyclinics, "PolyclinicID", "PolyclinicName", model.PolyclinicID);
            ViewBag.Doctors = new SelectList(doctors, "DoctorID", "DoctorName", model.DoctorID);
            ViewBag.AvailableDates = new SelectList(
                availableDates.Select(de => new { de.DateEntityID, DateDisplay = de.Date.ToString("yyyy-MM-dd") }),
                "DateEntityID", "DateDisplay", model.DateEntityId
            );
            ViewBag.Times = new SelectList(availableTimes, "TimeID", "AppointmentTimes", model.TimeID);

            return View(model);
        }

        

        [HttpGet]
        public IActionResult Edit(int id, int? polyclinicId, int? doctorId, int? dateId, int? timeId)
        {
            var appointment = _context.AppointmentDefinitions
                .Include(a => a.Doctor)
                .Include(a => a.Polyclinic)
                .Include(a => a.Time)
                .Include(a => a.Date)
                .FirstOrDefault(a => a.AppointmentDefinitionID == id);

            if (appointment == null)
                return NotFound();

            var polyclinics = _context.Polyclinics.ToList();
            int selectedPolyclinicId = polyclinicId ?? appointment.PolyclinicID;

            var doctors = _context.Doctors
                .Where(d => d.PolyclinicID == selectedPolyclinicId)
                .ToList();

            int selectedDoctorId = doctorId.HasValue && doctors.Any(d => d.DoctorID == doctorId.Value)
                ? doctorId.Value
                : appointment.DoctorID;

            var availableDates = _context.Dates
                .Where(d => d.DoctorId == selectedDoctorId)
                .OrderBy(d => d.Date)
                .ToList();
            int selectedDateId = dateId ?? appointment.DateEntityId;

            var availableTimes = _context.Times
                .Where(t => _context.Dates.Any(d =>
                    d.DateEntityID == selectedDateId &&
                    d.TimeID == t.TimeID &&
                    d.DoctorId == selectedDoctorId &&
                    !_context.AppointmentDefinitions.Any(a =>
                        a.DateEntityId == d.DateEntityID &&
                        a.TimeID == t.TimeID &&
                        a.DoctorID == selectedDoctorId)))
                .Select(t => new { t.TimeID, t.AppointmentTimes })
                .ToList();
            int selectedTimeId = timeId ?? appointment.TimeID;

            ViewBag.Polyclinics = new SelectList(polyclinics, "PolyclinicID", "PolyclinicName", selectedPolyclinicId);
            ViewBag.Doctors = new SelectList(doctors, "DoctorID", "DoctorName", selectedDoctorId);
            ViewBag.AvailableDates = new SelectList(
                availableDates.Select(d => new { d.DateEntityID, DateDisplay = d.Date.ToString("yyyy-MM-dd") }),
                "DateEntityID", "DateDisplay", selectedDateId
            );
            ViewBag.Times = new SelectList(availableTimes, "TimeID", "AppointmentTimes", selectedTimeId);

            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, AppointmentDefinition model, int? dateId, int? polyclinicId, int? doctorId, int? timeId)
        {
            var appointment = _context.AppointmentDefinitions.Find(id);
            if (appointment == null)
                return NotFound();

            appointment.PatientName = model.PatientName;
            appointment.IdentificationNumber = model.IdentificationNumber;
            appointment.PolyclinicID = polyclinicId ?? appointment.PolyclinicID;
            appointment.DoctorID = doctorId ?? appointment.DoctorID;
            appointment.DateEntityId = dateId ?? appointment.DateEntityId;
            appointment.TimeID = timeId ?? appointment.TimeID;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var appointment = _context.AppointmentDefinitions
                .Include(a => a.Doctor)
                .Include(a => a.Polyclinic)
                .Include(a => a.Time)
                .Include(a => a.Date)
                .FirstOrDefault(a => a.AppointmentDefinitionID == id);

            if (appointment == null)
                return NotFound();

            return View(appointment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var appointment = _context.AppointmentDefinitions.Find(id);
            if (appointment != null)
            {
                _context.AppointmentDefinitions.Remove(appointment);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}