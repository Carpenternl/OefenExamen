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
    public class TaakController : Controller
    {
        private readonly StorageContext _context;

        public TaakController(StorageContext context)
        {
            _context = context;
        }

        // GET: Taak
        public async Task<IActionResult> Index()
        {
            return View(await _context.TakenLijst.ToListAsync());
        }

        // GET: Taak/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taakModel = await _context.TakenLijst
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taakModel == null)
            {
                return NotFound();
            }

            return View(taakModel);
        }

        // GET: Taak/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Taak/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] TaakModel taakModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taakModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taakModel);
        }

        // GET: Taak/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taakModel = await _context.TakenLijst.FindAsync(id);
            if (taakModel == null)
            {
                return NotFound();
            }
            return View(taakModel);
        }

        // POST: Taak/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] TaakModel taakModel)
        {
            if (id != taakModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taakModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaakModelExists(taakModel.Id))
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
            return View(taakModel);
        }

        // GET: Taak/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taakModel = await _context.TakenLijst
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taakModel == null)
            {
                return NotFound();
            }

            return View(taakModel);
        }

        // POST: Taak/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taakModel = await _context.TakenLijst.FindAsync(id);
            if (taakModel != null)
            {
                _context.TakenLijst.Remove(taakModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaakModelExists(int id)
        {
            return _context.TakenLijst.Any(e => e.Id == id);
        }
    }
}
