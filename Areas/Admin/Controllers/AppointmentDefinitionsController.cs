using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApp.DAL;
using WebApp.Models;

namespace WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AppointmentDefinitionsController : Controller
    {
        private readonly HospitalDB _context;

        public AppointmentDefinitionsController(HospitalDB context)
        {
            _context = context;
        }

        // GET: Admin/AppointmentDefinitions
        public async Task<IActionResult> Index()
        {
            var appointments = await _context.AppointmentDefinitions
                .Include(a => a.PatientName)
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.Polyclinic)
                .Include(a => a.Time)
                .Include(a => a.Date)
                .ToListAsync();

            ViewBag.AppointmentDefinitions = appointments;
            return View();
        }

        // GET: Admin/AppointmentDefinitions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AppointmentDefinitions == null)
            {
                return NotFound();
            }

            var appointmentDefinition = await _context.AppointmentDefinitions
                .Include(r => r.Polyclinic)
                .Include(r => r.Time)
                .FirstOrDefaultAsync(m => m.AppointmentDefinitionID == id);
            if (appointmentDefinition == null)
            {
                return NotFound();
            }

            return View(appointmentDefinition);
        }

        // GET: Member/Appointments/Create
        public IActionResult Create(int? polyclinicId, int? doctorId, int? dateId, int? timeId)
        {
            var polyclinics = _context.Polyclinics.ToList();
            int selectedPolyclinicId = polyclinicId ?? polyclinics.FirstOrDefault()?.PolyclinicID ?? 0;

            var doctors = _context.Doctors
                .Where(d => d.PolyclinicID == selectedPolyclinicId)
                .ToList();
            int selectedDoctorId = doctorId ?? doctors.FirstOrDefault()?.DoctorID ?? 0;

            var availableDates = _context.Dates
                .Where(d => d.DoctorId == selectedDoctorId)
                .OrderBy(d => d.Date)
                .Select(d => new { d.DateEntityID, d.Date, DateDisplay = d.Date.ToString("yyyy-MM-dd") })
                .Distinct()
                .ToList();

            int selectedDateId = dateId ?? availableDates.FirstOrDefault()?.DateEntityID ?? 0;

            var availableTimes = _context.Dates
                .Where(d => d.DoctorId == selectedDoctorId && d.DateEntityID == selectedDateId)
                .Join(_context.Times, de => de.TimeID, t => t.TimeID, (de, t) => new { t.TimeID, t.AppointmentTimes })
                .ToList();

            ViewBag.Polyclinics = new SelectList(polyclinics, "PolyclinicID", "PolyclinicName", selectedPolyclinicId);
            ViewBag.Doctors = new SelectList(doctors, "DoctorID", "DoctorName", selectedDoctorId);
            ViewBag.AvailableDates = new SelectList(availableDates, "DateEntityID", "DateDisplay", selectedDateId);
            ViewBag.Times = new SelectList(availableTimes, "TimeID", "AppointmentTimes", timeId);

            return View();
        }

        // POST: Member/Appointments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Appointment model, int? dateId, int? polyclinicId, int? doctorId, int? timeId)
        {
            if (ModelState.IsValid)
            {
                //model.MemberID = GetUserID();

                // Get the selected date from DateEntity
                if (dateId.HasValue)
                {
                    var dateEntity = _context.Dates.FirstOrDefault(d => d.DateEntityID == dateId.Value);
                    if (dateEntity != null)
                    {
                        model.AppointmentDate = dateEntity.Date;
                    }
                }

                // Check if the slot is available
                var def = _context.AppointmentDefinitions
                    .FirstOrDefault(a =>
                        a.DoctorID == model.DoctorID &&
                        a.TimeID == model.TimeID &&
                        a.Date.Date == model.AppointmentDate.Date);

                if (def == null)
                {
                    // Redirect to GET with current filter values to preserve selections
                    return RedirectToAction("Create", new
                    {
                        polyclinicId = polyclinicId,
                        doctorId = doctorId,
                        dateId = dateId,
                        timeId = timeId
                    });
                }

                //def.AppointmentStatus = true;
                //model.AppointmentDate = def.Date;

                _context.Appointments.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index", "Member");
            }

            // If model state is invalid, redirect to GET with current filter values
            return RedirectToAction("Create", new
            {
                polyclinicId = polyclinicId,
                doctorId = doctorId,
                dateId = dateId,
                timeId = timeId
            });
        }

        // GET: Admin/AppointmentDefinitions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AppointmentDefinitions == null)
            {
                return NotFound();
            }

            var appointmentDefinition = await _context.AppointmentDefinitions.FindAsync(id);
            if (appointmentDefinition == null)
            {
                return NotFound();
            }
            ViewData["PolyclinicID"] = new SelectList(_context.Polyclinics, "PolyclinicID", "PolyclinicName", appointmentDefinition.PolyclinicID);
            ViewData["TimeID"] = new SelectList(_context.Times, "TimeID", "AppointmentTimes", appointmentDefinition.TimeID);
            return View(appointmentDefinition);
        }

        // POST: Admin/AppointmentDefinitions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentDefinitionID,PolyclinicID,TimeID,Date,AppointmentStatus")] AppointmentDefinition appointmentDefinition)
        {
            if (id != appointmentDefinition.AppointmentDefinitionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointmentDefinition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentDefinitionExists(appointmentDefinition.AppointmentDefinitionID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PolyclinicID"] = new SelectList(_context.Polyclinics, "PolyclinicID", "PolyclinicName", appointmentDefinition.PolyclinicID);
            ViewData["TimeID"] = new SelectList(_context.Times, "TimeID", "AppointmentTimes", appointmentDefinition.TimeID);
            return View(appointmentDefinition);
        }

        // GET: Admin/AppointmentDefinitions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AppointmentDefinitions == null)
            {
                return NotFound();
            }

            var appointmentDefinition = await _context.AppointmentDefinitions
                .Include(r => r.Polyclinic)
                .Include(r => r.Time)
                .FirstOrDefaultAsync(m => m.AppointmentDefinitionID == id);
            if (appointmentDefinition == null)
            {
                return NotFound();
            }

            return View(appointmentDefinition);
        }

        // POST: Admin/AppointmentDefinitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AppointmentDefinitions == null)
            {
                return Problem("Entity set 'HospitalDB.AppointmentDefinition'  is null.");
            }
            var appointmentDefinition = await _context.AppointmentDefinitions.FindAsync(id);
            if (appointmentDefinition != null)
            {
                _context.AppointmentDefinitions.Remove(appointmentDefinition);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentDefinitionExists(int id)
        {
            return _context.AppointmentDefinitions.Any(e => e.AppointmentDefinitionID == id);
        }
    }
}