using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppCollection.Data;
using AppCollection.Models;
using Microsoft.AspNetCore.Authorization;

namespace AppCollection.Controllers
{
    [Authorize]
    public class LeadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Leads
        public async Task<IActionResult> Index()
        {
              return _context.CollectLead != null ? 
                          View(await _context.CollectLead.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CollectLead'  is null.");
        }

        // GET: Leads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CollectLead == null)
            {
                return NotFound();
            }

            var collectLeadEntity = await _context.CollectLead
                .FirstOrDefaultAsync(m => m.Id == id);
            if (collectLeadEntity == null)
            {
                return NotFound();
            }

            return View(collectLeadEntity);
        }

        // GET: Leads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Leads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Mobile,Email,Source")] CollectLeadEntity collectLeadEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collectLeadEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(collectLeadEntity);
        }

        // GET: Leads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CollectLead == null)
            {
                return NotFound();
            }

            var collectLeadEntity = await _context.CollectLead.FindAsync(id);
            if (collectLeadEntity == null)
            {
                return NotFound();
            }
            return View(collectLeadEntity);
        }

        // POST: Leads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Mobile,Email,Source")] CollectLeadEntity collectLeadEntity)
        {
            if (id != collectLeadEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(collectLeadEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollectLeadEntityExists(collectLeadEntity.Id))
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
            return View(collectLeadEntity);
        }

        // GET: Leads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CollectLead == null)
            {
                return NotFound();
            }

            var collectLeadEntity = await _context.CollectLead
                .FirstOrDefaultAsync(m => m.Id == id);
            if (collectLeadEntity == null)
            {
                return NotFound();
            }

            return View(collectLeadEntity);
        }

        // POST: Leads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CollectLead == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CollectLead'  is null.");
            }
            var collectLeadEntity = await _context.CollectLead.FindAsync(id);
            if (collectLeadEntity != null)
            {
                _context.CollectLead.Remove(collectLeadEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollectLeadEntityExists(int id)
        {
          return (_context.CollectLead?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
