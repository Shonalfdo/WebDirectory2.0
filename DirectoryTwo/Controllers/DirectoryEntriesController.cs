using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DirectoryTwo.Data;
using DirectoryTwo.Models;

namespace DirectoryTwo.Controllers
{
    public class DirectoryEntriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DirectoryEntriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DirectoryEntries
        public async Task<IActionResult> Index()
        {
            return View(await _context.DirectoryEntry.ToListAsync());
        }

        // GET: DirectoryEntries/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // POST: DirectoryEntries/ShowSearchForm
        public async Task<IActionResult> ShowSearchResults(string SearchName)
        {
            return View("Index",await _context.DirectoryEntry.Where( j => j.SiteName.Contains(SearchName)).ToListAsync());
        }

        // GET: DirectoryEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directoryEntry = await _context.DirectoryEntry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (directoryEntry == null)
            {
                return NotFound();
            }

            return View(directoryEntry);
        }

        // GET: DirectoryEntries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DirectoryEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Prot,SubDom,Dom,TopDom,SiteName,SiteType")] DirectoryEntry directoryEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(directoryEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(directoryEntry);
        }

        // GET: DirectoryEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directoryEntry = await _context.DirectoryEntry.FindAsync(id);
            if (directoryEntry == null)
            {
                return NotFound();
            }
            return View(directoryEntry);
        }

        // POST: DirectoryEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Prot,SubDom,Dom,TopDom,SiteName,SiteType")] DirectoryEntry directoryEntry)
        {
            if (id != directoryEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(directoryEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectoryEntryExists(directoryEntry.Id))
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
            return View(directoryEntry);
        }

        // GET: DirectoryEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directoryEntry = await _context.DirectoryEntry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (directoryEntry == null)
            {
                return NotFound();
            }

            return View(directoryEntry);
        }

        // POST: DirectoryEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var directoryEntry = await _context.DirectoryEntry.FindAsync(id);
            _context.DirectoryEntry.Remove(directoryEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectoryEntryExists(int id)
        {
            return _context.DirectoryEntry.Any(e => e.Id == id);
        }
    }
}
