using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using L01P02_2020DL602.Models;

namespace L01P02_2020DL602.Controllers
{
    public class publiciacionesController : Controller
    {
        private readonly blogDbContext _context;

        public publiciacionesController(blogDbContext context)
        {
            _context = context;
        }

        // GET: publiciaciones
        public async Task<IActionResult> Index()
        {
              return _context.publiciaciones != null ? 
                          View(await _context.publiciaciones.ToListAsync()) :
                          Problem("Entity set 'blogDbContext.publiciaciones'  is null.");
        }

        // GET: publiciaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.publiciaciones == null)
            {
                return NotFound();
            }

            var publiciaciones = await _context.publiciaciones
                .FirstOrDefaultAsync(m => m.publicacionId == id);
            if (publiciaciones == null)
            {
                return NotFound();
            }

            return View(publiciaciones);
        }

        // GET: publiciaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: publiciaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("publicacionId,titulo,descripcion,usuarioId")] publicaciones publiciaciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publiciaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(publiciaciones);
        }

        // GET: publiciaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.publiciaciones == null)
            {
                return NotFound();
            }

            var publiciaciones = await _context.publiciaciones.FindAsync(id);
            if (publiciaciones == null)
            {
                return NotFound();
            }
            return View(publiciaciones);
        }

        // POST: publiciaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("publicacionId,titulo,descripcion,usuarioId")] publicaciones publiciaciones)
        {
            if (id != publiciaciones.publicacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publiciaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!publiciacionesExists(publiciaciones.publicacionId))
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
            return View(publiciaciones);
        }

        // GET: publiciaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.publiciaciones == null)
            {
                return NotFound();
            }

            var publiciaciones = await _context.publiciaciones
                .FirstOrDefaultAsync(m => m.publicacionId == id);
            if (publiciaciones == null)
            {
                return NotFound();
            }

            return View(publiciaciones);
        }

        // POST: publiciaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.publiciaciones == null)
            {
                return Problem("Entity set 'blogDbContext.publiciaciones'  is null.");
            }
            var publiciaciones = await _context.publiciaciones.FindAsync(id);
            if (publiciaciones != null)
            {
                _context.publiciaciones.Remove(publiciaciones);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool publiciacionesExists(int id)
        {
          return (_context.publiciaciones?.Any(e => e.publicacionId == id)).GetValueOrDefault();
        }
    }
}
