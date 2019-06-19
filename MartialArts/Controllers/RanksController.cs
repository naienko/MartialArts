using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MartialArts.Data;
using MartialArts.Models;
using Microsoft.AspNetCore.Authorization;

namespace MartialArts.Controllers
{
    public class RanksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RanksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ranks/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rank = await _context.Rank
                .Include(r => r.Style)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rank == null)
            {
                return NotFound();
            }

            return View(rank);
        }

        // GET: Ranks/Create
        [Authorize]
        public IActionResult Create(int StyleId)
        {

            ViewData["StyleId"] = new SelectList(_context.Style, "Id", "Name", StyleId);
            return View();
        }

        // POST: Ranks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(Rank rank)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rank);
                await _context.SaveChangesAsync();
                Style style = new Style
                {
                    Id = rank.StyleId
                };
                return RedirectToAction(nameof(Details), "Styles", style);
            }
            ViewData["StyleId"] = new SelectList(_context.Style, "Id", "Name", rank.StyleId);
            return View(rank);
        }

        // GET: Ranks/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rank = await _context.Rank.FindAsync(id);
            if (rank == null)
            {
                return NotFound();
            }
            ViewData["StyleId"] = new SelectList(_context.Style, "Id", "Name", rank.StyleId);
            return View(rank);
        }

        // POST: Ranks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,TimeInRank,StyleId")] Rank rank)
        {
            if (id != rank.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rank);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RankExists(rank.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                Style style = new Style
                {
                    Id = rank.StyleId
                };
                return RedirectToAction(nameof(Details), "Styles", style);
            }
            ViewData["StyleId"] = new SelectList(_context.Style, "Id", "Name", rank.StyleId);
            return View(rank);
        }

        //// GET: Ranks/Delete/5
        //[Authorize]
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var rank = await _context.Rank
        //        .Include(r => r.Style)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (rank == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(rank);
        //}

        //// POST: Ranks/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //[Authorize]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var rank = await _context.Rank.FindAsync(id);
        //    _context.Rank.Remove(rank);
        //    await _context.SaveChangesAsync();
        //    Style style = new Style
        //    {
        //        Id = rank.StyleId
        //    };
        //    return RedirectToAction(nameof(Details), "Styles", style);
        //}

        private bool RankExists(int id)
        {
            return _context.Rank.Any(e => e.Id == id);
        }
    }
}
