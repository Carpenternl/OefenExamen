using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TakenlijstManager.Data;
using TakenlijstManager.Models;

namespace TakenlijstManager.Controllers
{
    public class StatusController : Controller
    {
        private readonly StorageContext _context;

        public StatusController(StorageContext context)
        {
            _context = context;
        }

        // GET: Status
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatusModel.ToListAsync());
        }

        // GET: Status/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusModel = await _context.StatusModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statusModel == null)
            {
                return NotFound();
            }

            return View(statusModel);
        }

        // GET: Status/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Status/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam,VolgendeStatus")] StatusModel statusModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusModel);
        }

        // GET: Status/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusModel = await _context.StatusModel.FindAsync(id);
            if (statusModel == null)
            {
                return NotFound();
            }
            return View(statusModel);
        }

        // POST: Status/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam,VolgendeStatus")] StatusModel statusModel)
        {
            if (id != statusModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusModelExists(statusModel.Id))
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
            return View(statusModel);
        }

        // GET: Status/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusModel = await _context.StatusModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statusModel == null)
            {
                return NotFound();
            }

            return View(statusModel);
        }

        // POST: Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statusModel = await _context.StatusModel.FindAsync(id);
            if (statusModel != null)
            {
                _context.StatusModel.Remove(statusModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusModelExists(int id)
        {
            return _context.StatusModel.Any(e => e.Id == id);
        }
    }
}
