using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MartialArts.Data;
using MartialArts.Models;

namespace MartialArts.Controllers
{
    public class EventStylesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventStylesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EventStyles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EventStyle.Include(e => e.Event).Include(e => e.Style);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EventStyles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventStyle = await _context.EventStyle
                .Include(e => e.Event)
                .Include(e => e.Style)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventStyle == null)
            {
                return NotFound();
            }

            return View(eventStyle);
        }

        // GET: EventStyles/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Event, "Id", "Title");
            ViewData["StyleId"] = new SelectList(_context.Style, "Id", "Name");
            return View();
        }

        // POST: EventStyles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EventId,StyleId")] EventStyle eventStyle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventStyle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Event, "Id", "Title", eventStyle.EventId);
            ViewData["StyleId"] = new SelectList(_context.Style, "Id", "Name", eventStyle.StyleId);
            return View(eventStyle);
        }

        // GET: EventStyles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventStyle = await _context.EventStyle.FindAsync(id);
            if (eventStyle == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Event, "Id", "Title", eventStyle.EventId);
            ViewData["StyleId"] = new SelectList(_context.Style, "Id", "Name", eventStyle.StyleId);
            return View(eventStyle);
        }

        // POST: EventStyles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EventId,StyleId")] EventStyle eventStyle)
        {
            if (id != eventStyle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventStyle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventStyleExists(eventStyle.Id))
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
            ViewData["EventId"] = new SelectList(_context.Event, "Id", "Title", eventStyle.EventId);
            ViewData["StyleId"] = new SelectList(_context.Style, "Id", "Name", eventStyle.StyleId);
            return View(eventStyle);
        }

        // GET: EventStyles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventStyle = await _context.EventStyle
                .Include(e => e.Event)
                .Include(e => e.Style)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventStyle == null)
            {
                return NotFound();
            }

            return View(eventStyle);
        }

        // POST: EventStyles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventStyle = await _context.EventStyle.FindAsync(id);
            _context.EventStyle.Remove(eventStyle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventStyleExists(int id)
        {
            return _context.EventStyle.Any(e => e.Id == id);
        }
    }
}
