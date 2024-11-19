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
    public class LivroController : Controller
    {
        private readonly BiblioTechAContext _context;

        public LivroController(BiblioTechAContext context)
        {
            _context = context;
        }

        // GET: Livro
        public async Task<IActionResult> Index()
        {
            var livros = await _context.Livros
                .AsNoTracking()  // Desabilita o tracking, forçando uma nova consulta
                .Include(l => l.Biblioteca) // Certifique-se de carregar a biblioteca junto
                .ToListAsync();

            return View(livros);
        }

        // GET: Livro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros
                .Include(m => m.Biblioteca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // GET: Livro/Create
        public IActionResult Create()
        {
            ViewData["BibliotecaId"] = new SelectList(_context.Biblioteca, "Id", "BiblioNome");
            return View();
        }

        // POST: Livro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descricao,Genero, BibliotecaId")] Livro livro)
        {
            if (!ModelState.IsValid)
            {
                ViewData["BibliotecaId"] = new SelectList(_context.Biblioteca, "Id", "BiblioNome", livro.Id);
                return View(livro);
            }

            if (livro == null)
            {
                return NotFound();
            }

            _context.Add(livro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Livro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }
            ViewData["BibliotecaId"] = new SelectList(_context.Biblioteca, "Id", "BiblioNome");
            return View(livro);
        }

        // POST: Livro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao,Genero, BibliotecaId")] Livro livro)
        {
            if (id != livro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(livro.Id))
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
            return View(livro);
        }

        // GET: Livro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // POST: Livro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro != null)
            {
                _context.Livros.Remove(livro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(int id)
        {
            return _context.Livros.Any(e => e.Id == id);
        }
    }
}
