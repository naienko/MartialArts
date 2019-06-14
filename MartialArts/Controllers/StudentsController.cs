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
                .Include(e => e.Forms)
                .ThenInclude(e => e.Form)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        [Authorize]
        public IActionResult Create()
        {
            StudentCreateViewModel newStudent = new StudentCreateViewModel(_context.Style, _context.Rank);
            //ViewData["Style"] = new SelectList(_context.Style, "Id", "Name");
            //ViewData["Rank"] = new SelectList(_context.Rank, "Id", "Name");
            return View(newStudent);
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(StudentCreateViewModel newStudent)
        {
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
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student updateStudentPersonal = await _context.Student.FindAsync(id);
            
            if (updateStudentPersonal == null)
            {
                return NotFound();
            }
            return View(updateStudentPersonal);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, Student updateStudent)
        {
            if (id != updateStudent.Id)
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
                    if (!StudentExists(updateStudent.Id))
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

        // GET: add a new style to an existing Student
        [Authorize]
        public ActionResult AddNewStyle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            StudentAddStyle updateStudentStyle = new StudentAddStyle(_context.Style);
            updateStudentStyle.StudentId = (int)id;

            if (updateStudentStyle == null)
            {
                return NotFound();
            }
            return View(updateStudentStyle);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize]
        // PUSH: adds a new bit of data to the model and pushes it to the next view
        public ActionResult AddNewStyle(int id, StudentAddStyle addStudentStyle) { 
            if (id != addStudentStyle.StudentId)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(AddRankAndForms),addStudentStyle);
        }

        // GET: displays new form fields based on the previous page's choice
        [Authorize]
        public ActionResult AddRankAndForms(int id, StudentAddStyle addStudentRank)
        {
            ViewData["Forms"] = new SelectList(_context.Form.Where(f => f.StyleId == addStudentRank.StyleId), "Id", "Name");
            ViewData["Ranks"] = new SelectList(_context.Rank.Where(f => f.StyleId == addStudentRank.StyleId), "Id", "Name");
            return View(addStudentRank);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        // POST
        public async Task<IActionResult> AddRankAndForms(StudentAddStyle addStudentRank)
        {
            ViewData["Forms"] = new SelectList(_context.Form.Where(f => f.StyleId == addStudentRank.StyleId), "Id", "Name", addStudentRank.FormsList);
            ViewData["Ranks"] = new SelectList(_context.Rank.Where(f => f.StyleId == addStudentRank.StyleId), "Id", "Name", addStudentRank.RankId);

            if (ModelState.IsValid)
            {
                StudentStyle newStyle = new StudentStyle
                {
                    StudentId = addStudentRank.StudentId,
                    StyleId = addStudentRank.StyleId,
                    RankId = addStudentRank.RankId
                };
                _context.StudentStyle.Add(newStyle);

                foreach (int formid in addStudentRank.FormsList)
                {
                    StudentForms newForm = new StudentForms
                    {
                        StudentId = addStudentRank.StudentId,
                        StyleId = addStudentRank.StyleId,
                        FormId = formid
                    };
                    _context.StudentForms.Add(newForm);
                }

                await _context.SaveChangesAsync();
                Student student = new Student
                {
                    Id = addStudentRank.StudentId
                };
                return RedirectToAction(nameof(Details), student);
            }
            return View(addStudentRank);
        }

        // GET: Edit Rank &| Forms
        [Authorize]
        public async Task<IActionResult> EditRankAndForms(int StudentId, int StyleId)
        {
            ViewData["Forms"] = new SelectList(_context.Form.Where(f => f.StyleId == StyleId), "Id", "Name");
            ViewData["Ranks"] = new SelectList(_context.Rank.Where(f => f.StyleId == StyleId), "Id", "Name");

            Student student = _context.Student
                .Include(e => e.Styles)
                .First(s => s.Id == StudentId);

            StudentAddStyle editStudentRank = new StudentAddStyle
            {
                StudentId = StudentId,
                StyleId = StyleId,
                RankId = student.Styles.First(s => s.StyleId == StyleId).RankId
            };

            return View(editStudentRank);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        // POST
        public async Task<IActionResult> EditRankAndForms(StudentAddStyle editStudentRank)
        {
            ViewData["Forms"] = new SelectList(_context.Form.Where(f => f.StyleId == editStudentRank.StyleId), "Id", "Name", editStudentRank.FormsList);
            ViewData["Ranks"] = new SelectList(_context.Rank.Where(f => f.StyleId == editStudentRank.StyleId), "Id", "Name", editStudentRank.RankId);

            if (ModelState.IsValid)
            {
                StudentStyle updatedRank = _context.StudentStyle.First(s => s.StudentId == editStudentRank.StudentId && s.StyleId == editStudentRank.StyleId);
                updatedRank.RankId = editStudentRank.RankId;
                _context.StudentStyle.Update(updatedRank);

                List<StudentForms> deleteForms = _context.StudentForms.Where(s => s.StudentId == editStudentRank.StudentId && s.StyleId == editStudentRank.StyleId).ToList();
                foreach (StudentForms item in deleteForms)
                {
                    _context.StudentForms.Remove(item);
                }

                foreach (int formid in editStudentRank.FormsList)
                {
                    StudentForms newForm = new StudentForms
                    {
                        StudentId = editStudentRank.StudentId,
                        StyleId = editStudentRank.StyleId,
                        FormId = formid
                    };
                    _context.StudentForms.Add(newForm);
                }
                await _context.SaveChangesAsync();
                Student student = new Student
                {
                    Id = editStudentRank.StudentId
                };
                return RedirectToAction(nameof(Details), student);
            }
            return View(editStudentRank);
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }
    }
}
