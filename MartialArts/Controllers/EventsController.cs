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
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Event
                .Include(e => e.Staff)
                .Include(e => e.Style)
                .ThenInclude(e => e.Style);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .Include(e => e.Staff)
                .Include(e => e.Style)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["StaffId"] = new SelectList(_context.Student, "Id", "FullName");
            ViewData["Style"] = new SelectList(_context.Style, "Id", "Name");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(EventCreateViewModel newEvent)
        {
            ViewData["StaffId"] = new SelectList(_context.Student, "Id", "FullName", newEvent.Event.StaffId);
            ViewData["Style"] = new SelectList(_context.Style, "Id", "Name", newEvent.EventStyle);
            
            if (ModelState.IsValid)
            {
                _context.Add(newEvent.Event);

                foreach (int styleid in newEvent.EventStyle)
                {
                    EventStyle styleForEvent = new EventStyle
                    {
                        StyleId = styleid,
                        EventId = newEvent.Event.Id
                    };
                    _context.EventStyle.Add(styleForEvent);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newEvent);
        }

        // GET: Events/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<EventStyle> StyleList = _context.EventStyle.Where(e => e.EventId == id).ToList();

            EventCreateViewModel updateEvent = new EventCreateViewModel
            {
                Event = await _context.Event.FindAsync(id)
            };
            foreach (EventStyle item in StyleList)
            {
                updateEvent.EventStyle.Add(item.StyleId);
            }

            //var @event = await _context.Event.FindAsync(id);
            if (updateEvent.Event == null)
            {
                return NotFound();
            }
            ViewData["StaffId"] = new SelectList(_context.Student, "Id", "FullName", updateEvent.Event.StaffId);
            ViewData["Style"] = new SelectList(_context.Style, "Id", "Name", updateEvent.EventStyle);
            return View(updateEvent);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, EventCreateViewModel updateEvent)
        {
            if (id != updateEvent.Event.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    List<EventStyle> StyleList = _context.EventStyle.Where(e => e.EventId == id).ToList();
                    _context.Update(updateEvent.Event);

                    foreach (EventStyle item in StyleList)
                    {
                        _context.EventStyle.Remove(item);
                    }
                    foreach (int styleid in updateEvent.EventStyle)
                    {
                        EventStyle styleForEvent = new EventStyle
                        {
                            StyleId = styleid,
                            EventId = updateEvent.Event.Id
                        };
                        _context.EventStyle.Add(styleForEvent);
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(updateEvent.Event.Id))
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
            ViewData["StaffId"] = new SelectList(_context.Student, "Id", "FullName", updateEvent.Event.StaffId);
            ViewData["Style"] = new SelectList(_context.Style, "Id", "Name", updateEvent.EventStyle);
            return View(updateEvent);
        }

        // GET: Events/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .Include(e => e.Staff)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Event.FindAsync(id);
            _context.Event.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.Id == id);
        }
    }
}
