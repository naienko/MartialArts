using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MartialArts.Data;
using MartialArts.Models;
using MartialArts.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace MartialArts.Controllers
{
    public class AttendancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Attendance/Test/Create
        [Authorize]
        public ActionResult TestAttendance(int EventId)
        {
            TestAttendanceViewModel Event = new TestAttendanceViewModel
            {
                EventId = EventId,
                Event = _context.Event.Find(EventId)
            };
            ViewData["Students"] = new SelectList(_context.Student, "Id", "FullName");
            return View(Event);
        }

        // POST: Attendance/Test
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> TestAttendance(TestAttendanceViewModel model)
        {
            ViewData["Students"] = new SelectList(_context.Student, "Id", "FullName", model.AllStudents);
            model.Event = _context.Event.Find(model.EventId);

            foreach (int StudentId in model.AllStudents)
            {
                attendance_test EventAttendance = new attendance_test
                {
                    StudentId = StudentId,
                    EventId = model.EventId
                };
                if (model.all_pass == true)
                {
                    EventAttendance.did_pass = true;
                };
                _context.Attendance_Test.Add(EventAttendance);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Events");
        }

        // GET: Attendance/Test/Remove
        [Authorize]
        public ActionResult DeleteAttendance(int id, int StudentId)
        {
            var @event = _context.Attendance_Test
                .Include(e => e.Student)
                .Include(e => e.Event)
                .FirstOrDefault(m => m.EventId == id && m.StudentId == StudentId);
            return View(@event);
        }

        // POST: Attendance/Test/Remove
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteAttendance(attendance_test model)
        {
            var @event = await _context.Attendance_Test.FindAsync(model.Id);
            _context.Attendance_Test.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Events", new { id = model.EventId });
        }

        // GET: Attendance/Class/Create
        [Authorize]
        public ActionResult ClassAttendance(int id)
        {
            ClassAttendanceViewModel specificClass = new ClassAttendanceViewModel
            {
                ClassId = id,
                Class = _context.Class
                .Include(c => c.Style)
                .First(c => c.Id == id),
                DateOfClass = DateTime.Today
            };
            ViewData["Students"] = new SelectList(_context.Student, "Id", "FullName");
            return View(specificClass);
        }

        // POST: Attendance/Test
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ClassAttendance(ClassAttendanceViewModel model)
        {
            ViewData["Students"] = new SelectList(_context.Student, "Id", "FullName", model.AllStudents);
            model.Class = _context.Class.Find(model.ClassId);

            if (model.DateOfClass > DateTime.Now.AddDays(1))
            {
                return View(model);
            }

            foreach (int StudentId in model.AllStudents)
            {
                attendance_class EventAttendance = new attendance_class
                {
                    StudentId = StudentId,
                    ClassId = model.ClassId,
                    Date = model.DateOfClass
                };
                _context.Attendance_Class.Add(EventAttendance);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Classes");
        }
    }
}