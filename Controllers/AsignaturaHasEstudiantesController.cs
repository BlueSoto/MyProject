using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class AsignaturaHasEstudiantesController : Controller
    {
        private readonly FormularioContext _context;

        public AsignaturaHasEstudiantesController(FormularioContext context)
        {
            _context = context;
        }

        // GET: AsignaturaHasEstudiantes
        public async Task<IActionResult> Index()
        {
            var formularioContext = _context.AsignaturaHasEstudiantes.Include(a => a.Asignatura).Include(a => a.Estudiante);
            return View(await formularioContext.ToListAsync());
        }

        // GET: AsignaturaHasEstudiantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AsignaturaHasEstudiantes == null)
            {
                return NotFound();
            }

            var asignaturaHasEstudiante = await _context.AsignaturaHasEstudiantes
                .Include(a => a.Asignatura)
                .Include(a => a.Estudiante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asignaturaHasEstudiante == null)
            {
                return NotFound();
            }

            return View(asignaturaHasEstudiante);
        }

        // GET: AsignaturaHasEstudiantes/Create
        public IActionResult Create()
        {
            ViewData["AsignaturaId"] = new SelectList(_context.Asignaturas, "Id", "Id");
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Id");
            return View();
        }

        // POST: AsignaturaHasEstudiantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AsignaturaId,EstudianteId")] AsignaturaHasEstudiante asignaturaHasEstudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignaturaHasEstudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AsignaturaId"] = new SelectList(_context.Asignaturas, "Id", "Id", asignaturaHasEstudiante.AsignaturaId);
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Id", asignaturaHasEstudiante.EstudianteId);
            return View(asignaturaHasEstudiante);
        }

        // GET: AsignaturaHasEstudiantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AsignaturaHasEstudiantes == null)
            {
                return NotFound();
            }

            var asignaturaHasEstudiante = await _context.AsignaturaHasEstudiantes.FindAsync(id);
            if (asignaturaHasEstudiante == null)
            {
                return NotFound();
            }
            ViewData["AsignaturaId"] = new SelectList(_context.Asignaturas, "Id", "Id", asignaturaHasEstudiante.AsignaturaId);
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Id", asignaturaHasEstudiante.EstudianteId);
            return View(asignaturaHasEstudiante);
        }

        // POST: AsignaturaHasEstudiantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AsignaturaId,EstudianteId")] AsignaturaHasEstudiante asignaturaHasEstudiante)
        {
            if (id != asignaturaHasEstudiante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignaturaHasEstudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignaturaHasEstudianteExists(asignaturaHasEstudiante.Id))
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
            ViewData["AsignaturaId"] = new SelectList(_context.Asignaturas, "Id", "Id", asignaturaHasEstudiante.AsignaturaId);
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Id", asignaturaHasEstudiante.EstudianteId);
            return View(asignaturaHasEstudiante);
        }

        // GET: AsignaturaHasEstudiantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AsignaturaHasEstudiantes == null)
            {
                return NotFound();
            }

            var asignaturaHasEstudiante = await _context.AsignaturaHasEstudiantes
                .Include(a => a.Asignatura)
                .Include(a => a.Estudiante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asignaturaHasEstudiante == null)
            {
                return NotFound();
            }

            return View(asignaturaHasEstudiante);
        }

        // POST: AsignaturaHasEstudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AsignaturaHasEstudiantes == null)
            {
                return Problem("Entity set 'FormularioContext.AsignaturaHasEstudiantes'  is null.");
            }
            var asignaturaHasEstudiante = await _context.AsignaturaHasEstudiantes.FindAsync(id);
            if (asignaturaHasEstudiante != null)
            {
                _context.AsignaturaHasEstudiantes.Remove(asignaturaHasEstudiante);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignaturaHasEstudianteExists(int id)
        {
          return (_context.AsignaturaHasEstudiantes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
