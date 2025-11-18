using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL;
using WebApp.Models;

namespace WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AppointmentsController : Controller
    {
        private readonly HospitalDB _context;

        public AppointmentsController(HospitalDB context)
        {
            _context = context;
        }

        // GET: Admin/Appointments
        public async Task<IActionResult> Index()
        {
            var HospitalDB = _context.AppointmentDefinitions
                //.Include(r => r.Member)
                .Include(r => r.Polyclinic)
                .Include(r => r.Doctor)
                .Include(r => r.Date)
                .Include(r => r.Time);
            return View(await HospitalDB.ToListAsync());
        }

        // GET: Admin/Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var randevu = await _context.Appointments
                .Include(r => r.Member)
                .Include(r => r.AppointmentDefinitions)
                .Include(r => r.AppointmentDefinitions.Doctor)
                .Include(r => r.AppointmentDefinitions.Time)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }

        // GET: Admin/Appointments/Create
        public IActionResult Create()
        {
            ViewData["MemberID"] = new SelectList(_context.Members, "Id", "Id");
            ViewData["DoctorID"] = new SelectList(_context.Doctors, "DoctorID", "DoctorName");
            ViewData["TimeID"] = new SelectList(_context.Times, "TimeID", "AppointmentTimes");
            return View();
        }

        // POST: Admin/Appointments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MemberID,DoctorID,AppointmentDate,MemberArrived,TimeID")] Appointment randevu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(randevu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MemberID"] = new SelectList(_context.Members, "Id", "Id", randevu.MemberID);
            ViewData["DoctorID"] = new SelectList(_context.Doctors, "DoctorID", "DoctorName", randevu.DoctorID);
            ViewData["TimeID"] = new SelectList(_context.Times, "TimeID", "AppointmentTimes", randevu.TimeID);
            return View(randevu);
        }

        // GET: Admin/Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var randevu = await _context.Appointments.FindAsync(id);
            if (randevu == null)
            {
                return NotFound();
            }
            ViewData["MemberID"] = new SelectList(_context.Members, "Id", "Id", randevu.MemberID);
            ViewData["DoctorID"] = new SelectList(_context.Doctors, "DoctorID", "DoctorName", randevu.DoctorID);
            ViewData["TimeID"] = new SelectList(_context.Times, "TimeID", "AppointmentTimes", randevu.TimeID);
            return View(randevu);
        }

        // POST: Admin/Appointments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MemberID,DoctorID,AppointmentDate,MemberArrived,TimeID")] Appointment randevu)
        {
            if (id != randevu.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(randevu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(randevu.ID))
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
            ViewData["MemberID"] = new SelectList(_context.Members, "Id", "Id", randevu.MemberID);
            ViewData["DoctorID"] = new SelectList(_context.Doctors, "DoctorID", "DoctorName", randevu.DoctorID);
            ViewData["TimeID"] = new SelectList(_context.Times, "TimeID", "AppointmentTimes", randevu.TimeID);
            return View(randevu);
        }

        // GET: Admin/Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var randevu = await _context.Appointments
                .Include(r => r.Member)
                .Include(r => r.AppointmentDefinitions)
                .Include(r => r.AppointmentDefinitions.Doctor)
                .Include(r => r.AppointmentDefinitions.Time)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }

        // POST: Admin/Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Appointments == null)
            {
                return Problem("Entity set 'HospitalDB.Appointments'  is null.");
            }
            var randevu = await _context.Appointments.FindAsync(id);
            if (randevu != null)
            {
                _context.Appointments.Remove(randevu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.ID == id);
        }
    }
}