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

namespace MartialArts
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Student
                .Include(e => e.Styles)
                .ThenInclude(e => e.Style)
                .Include(e => e.Styles)
                .ThenInclude(e => e.Rank);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(e => e.Styles)
                .ThenInclude(e => e.Style)
                .Include(e => e.Styles)
                .ThenInclude(e => e.Rank)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            StudentCreateViewModel newStudent = new StudentCreateViewModel(_context.Style, _context.Rank);
            //ViewData["Style"] = new SelectList(_context.Style, "Id", "Name");
            //ViewData["Rank"] = new SelectList(_context.Rank, "Id", "Name");
            return View(newStudent);
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentCreateViewModel newStudent)
        {
            //ViewData["Style"] = new SelectList(_context.Style, "Id", "Name", newStudent.StudentStyle);
            //ViewData["Rank"] = new SelectList(_context.Rank, "Id", "Name", newStudent.StudentRank);
            if (ModelState.IsValid)
            {
                _context.Add(newStudent.Student);
                //create StudentStyle object here
                StudentStyle newstudentStyle = new StudentStyle
                {
                    StudentId = newStudent.Student.Id,
                    StyleId = newStudent.StartingStyle,
                    RankId = newStudent.StartingRank
                };
                _context.StudentStyle.Add(newstudentStyle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newStudent);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student updateStudent = await _context.Student.FindAsync(id);
            
            if (updateStudent == null)
            {
                return NotFound();
            }
            return View(updateStudent);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentCreateViewModel updateStudent)
        {
            if (id != updateStudent.Student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(updateStudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(updateStudent.Student.Id))
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
            return View(updateStudent);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.FindAsync(id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }
    }
}
