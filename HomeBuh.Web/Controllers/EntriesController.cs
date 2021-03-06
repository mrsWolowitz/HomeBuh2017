using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HomeBuh.Data;
using HomeBuh.Models;
using System.Globalization;

namespace HomeBuh.Controllers
{
    public class EntriesController : Controller
    {
        private readonly BuhContext _context;

        public EntriesController(BuhContext context)
        {
            _context = context;    
        }

        // GET: Entries
        public async Task<IActionResult> Index()
        {
            ViewData["Message"] = _context.Settings.FirstOrDefault().DateProhibitionEditing.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            return View(await _context.Entries.OrderByDescending(x=>x.DateOperation).ToListAsync());
        }

        public IEnumerable<Entry> GetByPeriod(DateTime DateBegin, DateTime DateEnd)
        {
            var entries = _context.Entries.Where(x => x.DateLastUpdate >= DateBegin && x.DateLastUpdate < DateEnd).ToList();
            return entries;
        }

        public bool SetProhibitionEditing(DateTime date)
        {
            var entry = _context.Settings.FirstOrDefault();
            entry.DateProhibitionEditing = date;

            try
            {
                _context.Settings.Update(entry);
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntryExists(entry.ID))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        // GET: Entries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Entries
                .SingleOrDefaultAsync(m => m.ID == id);
            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        // GET: Entries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DateOperation,BuhAccountID,Value,Description")] Entry entry)
        {
            if (ModelState.IsValid)
            {
                if (entry.DateOperation.ToUniversalTime() < _context.Settings.FirstOrDefault().DateProhibitionEditing)
                    return View(entry);

                _context.Add(entry);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(entry);
        }

        // GET: Entries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var entry = await _context.Entries.SingleOrDefaultAsync(m => m.ID == id);
            if (entry == null)
            {
                return NotFound();
            }

            if (entry.DateOperation.ToUniversalTime() < _context.Settings.FirstOrDefault().DateProhibitionEditing)
                return NotFound();
            
            return View(entry);
        }

        // POST: Entries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DateOperation,BuhAccountID,Value,Description")] Entry entry)
        {
            if (id != entry.ID)
            {
                return NotFound();
            }

            if (entry.DateOperation.ToUniversalTime() < _context.Settings.FirstOrDefault().DateProhibitionEditing)
                return View(entry);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntryExists(entry.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(entry);
        }

        // GET: Entries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Entries
                .SingleOrDefaultAsync(m => m.ID == id);
            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        // POST: Entries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entry = await _context.Entries.SingleOrDefaultAsync(m => m.ID == id);
            _context.Entries.Remove(entry);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EntryExists(int id)
        {
            return _context.Entries.Any(e => e.ID == id);
        }
    }
}
