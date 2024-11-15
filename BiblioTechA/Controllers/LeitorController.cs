using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BiblioTechA.Data;
using BiblioTechA.Models;

namespace BiblioTechA.Controllers
{
    public class LeitorController : Controller
    {
        private readonly BiblioTechAContext _context;

        public LeitorController(BiblioTechAContext context)
        {
            _context = context;
        }

        // GET: Leitor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Leitores.ToListAsync());
        }

        // GET: Leitor/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leitor = await _context.Leitores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leitor == null)
            {
                return NotFound();
            }

            return View(leitor);
        }

        // GET: Leitor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Leitor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Leitor leitor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leitor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leitor);
        }

        // GET: Leitor/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leitor = await _context.Leitores.FindAsync(id);
            if (leitor == null)
            {
                return NotFound();
            }
            return View(leitor);
        }

        // POST: Leitor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Nome")] Leitor leitor)
        {
            if (id != leitor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leitor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeitorExists(leitor.Id))
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
            return View(leitor);
        }

        // GET: Leitor/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leitor = await _context.Leitores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leitor == null)
            {
                return NotFound();
            }

            return View(leitor);
        }

        // POST: Leitor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var leitor = await _context.Leitores.FindAsync(id);
            if (leitor != null)
            {
                _context.Leitores.Remove(leitor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeitorExists(string id)
        {
            return _context.Leitores.Any(e => e.Id == id);
        }
    }
}
