using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Race_Track.Data;
using herramientas_parcial1_OliveraJorgeDaniel.Models;
using herramientas_parcial1_OliveraJorgeDaniel.ViewModels.PilotoViewModels;

namespace herramientas_parcial1_OliveraJorgeDaniel.Controllers
{
    public class PilotoController : Controller
    {
        private readonly VehiculoContext _context;

        public PilotoController(VehiculoContext context)
        {
            _context = context;
        }

        // GET: Piloto
        public async Task<IActionResult> Index(string nameFilter)
        {
            var query = from piloto in _context.Piloto.Include(i => i.Vehiculo) select piloto;

            if (!string.IsNullOrEmpty(nameFilter))
            {
                query = query.Where(x => x.PilotoNombre.Contains(nameFilter) || x.PilotoApellido.Contains(nameFilter) || x.PilotoDni.ToString() == nameFilter);
            }

            var model = new PilotoIndexViewModel();
            model.pilotos = await query.ToListAsync();

            return _context.Piloto != null ?
            View(model) :
            Problem("Entity set 'AeronaveContex.Aeronave' is null.");

        }

        // GET: Piloto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Piloto == null)
            {
                return NotFound();
            }

            var piloto = await _context.Piloto
                .Include(p => p.Vehiculo)
                .FirstOrDefaultAsync(m => m.PilotoId == id);
            if (piloto == null)
            {
                return NotFound();
            }

            var viewModel = new PilotoDetailViewModel();
            viewModel.PilotoNombre = piloto.PilotoNombre;
            viewModel.PilotoApellido = piloto.PilotoApellido;
            viewModel.PilotoExpedicion = piloto.PilotoExpedicion;
            viewModel.PilotoDni = piloto.PilotoDni;
            viewModel.PilotoNumeroLicencia = piloto.PilotoNumeroLicencia;
            viewModel.PilotoPropietario = piloto.PilotoPropietario;
            viewModel.VehiculoId = piloto.VehiculoId;
            viewModel.Vehiculo = piloto.Vehiculo;

            return View(viewModel);
        }

        // GET: Piloto/Create
        public IActionResult Create()
        {
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculo, "VehiculoId", "VehiculoTipo");
            return View();
        }

        // POST: Piloto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("PilotoId,PilotoNombre,PilotoApellido,PilotoDni,PilotoNumeroLicencia,PilotoExpedicion,PilotoPropietario,VehiculoId")] Piloto piloto)

        public async Task<IActionResult> Create([Bind("PilotoId,PilotoNombre,PilotoApellido,PilotoDni,PilotoNumeroLicencia,PilotoExpedicion,PilotoPropietario,VehiculoId")] Piloto piloto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(piloto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculo, "VehiculoId", "VehiculoApellido", piloto.VehiculoId);
            return View(piloto);
        }

        // GET: Piloto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Piloto == null)
            {
                return NotFound();
            }

            var piloto = await _context.Piloto.FindAsync(id);
            if (piloto == null)
            {
                return NotFound();
            }
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculo, "VehiculoId", "VehiculoTipo", "piloto.VehiculoId");
            return View(piloto);
        }

        // POST: Piloto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PilotoId,PilotoNombre,PilotoApellido,PilotoDni,PilotoNumeroLicencia,PilotoExpedicion,PilotoPropietario,VehiculoId")] Piloto piloto)
        {
            if (id != piloto.PilotoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(piloto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PilotoExists(piloto.PilotoId))
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
            return View(piloto);
        }

        // GET: Piloto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Piloto == null)
            {
                return NotFound();
            }

            var piloto = await _context.Piloto
                .Include(p => p.Vehiculo)
                .FirstOrDefaultAsync(m => m.PilotoId == id);
            if (piloto == null)
            {
                return NotFound();
            }
            var viewModel = new PilotoDeleteViewModel();
            viewModel.PilotoNombre = piloto.PilotoNombre;
            viewModel.PilotoApellido = piloto.PilotoApellido;
            viewModel.PilotoExpedicion = piloto.PilotoExpedicion;
            viewModel.PilotoDni = piloto.PilotoDni;
            viewModel.PilotoNumeroLicencia = piloto.PilotoNumeroLicencia;
            viewModel.PilotoPropietario = piloto.PilotoPropietario;
            viewModel.VehiculoId = piloto.VehiculoId;
            viewModel.Vehiculo = piloto.Vehiculo;

            return View(viewModel);
        }

        // POST: Piloto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Piloto == null)
            {
                return Problem("Entity set 'VehiculoContext.Piloto'  is null.");
            }
            var piloto = await _context.Piloto.FindAsync(id);
            if (piloto != null)
            {
                _context.Piloto.Remove(piloto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PilotoExists(int id)
        {
            return (_context.Piloto?.Any(e => e.PilotoId == id)).GetValueOrDefault();
        }
    }
}
