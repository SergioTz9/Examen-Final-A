using ControlCatedratico.Connection;
using ControlCatedratico.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlCatedratico.Controllers
{
    public class CatedraticoController : Controller
    {
        private readonly ILogger<CatedraticoController> _logger;
        private readonly Conn _context;

        public CatedraticoController(Conn context)

        {
            _context = context;
        }
        public IActionResult Catedratico()
        {
            return View();
        }
        public async Task<IActionResult> InicioCatedratico()
        {
            return View(await _context.tbl_RegistroCatedratico.ToListAsync());


        }
        [HttpPost]
        public async Task<IActionResult> Catedratico([Bind("CodigoCatedratico, NombreCatedratico, Genero, EstadoCivil, TelCatedratico, CorreoCatedratico, NoDpi, FechaIngreso, EstadoCatedratico")] CatedraticoModel catedraticomodel)
        {

            if (ModelState.IsValid)
            {
                _context.Add(catedraticomodel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(InicioCatedratico));

            }

            return View(catedraticomodel);

        }
        [HttpGet]
        public async Task<IActionResult> ConsultaCatedratico(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Datos = await _context.tbl_RegistroCatedratico
                .FirstOrDefaultAsync(a => a.CodigoCatedratico == int.Parse(id));

            return View(Datos);
        }
        public async Task<IActionResult> EditarCatedratico(string id)
        {
            int CodigoCatedratico;
            if (id == null)
            {
                return NotFound();
            }

            CodigoCatedratico = int.Parse(id);
            var Datos = await _context.tbl_RegistroCatedratico.FindAsync(CodigoCatedratico);

            if (Datos == null)
            {
                return NotFound();
            }
            return View(Datos);

        }
        [HttpPost]
        public async Task<IActionResult> EditarCatedratico(string id, [Bind("CodigoCatedratico, NombreCatedratico, Genero, EstadoCivil, TelCatedratico, CorreoCatedratico, NoDpi, FechaIngreso, EstadoCatedratico")] CatedraticoModel catedraticomodel)
        {

            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
                try
                {
                    _context.Update(catedraticomodel);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuscaCatedratico(catedraticomodel.CodigoCatedratico.ToString()))
                    {
                        return NotFound();

                    }

                }
            return RedirectToAction(nameof(InicioCatedratico));

        }
        private bool BuscaCatedratico(string id)
        {
            return _context.tbl_RegistroCatedratico.Any(e => e.CodigoCatedratico.ToString() == id);

        }
        [HttpPost]
        public async Task<IActionResult> EliminarCatedratico(String id)
        {
            int CodigoCatedratico;
            if (id == null)
            {
                return NotFound();
            }


            CodigoCatedratico = int.Parse(id);
            var Datos = await _context.tbl_RegistroCatedratico.FindAsync(CodigoCatedratico);

            if (Datos == null)
            {
                return NotFound();
            }

            return View(Datos);
        }
        [HttpPost, ActionName("EliminarCatedratico")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id, CatedraticoModel catedraticomodel)
        {
            _context.Remove(catedraticomodel);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
