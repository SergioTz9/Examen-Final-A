using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlCatedratico.Connection;
using ControlCatedratico.Models;
using Microsoft.Extensions.Logging;

namespace ControlCatedratico.Controllers
{
    public class CursoController : Controller
    {
        private readonly ILogger<CursoController> _logger;
        private readonly Conn _context;

        public CursoController(Conn context)

        {
            _context = context;
        }


        public IActionResult Curso()
        {
            return View();
        }
        public async Task<IActionResult> InicioCurso()
        {
            return View(await _context.tbl_RegistroCursos.ToListAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Curso([Bind("CodigoCurso, NombreCurso, FechaInicio, FechaFinaliza, EstadoCurso, CodigoCatedratico")] CursosModel cursomodel)
        {

            if (ModelState.IsValid)
            {
                _context.Add(cursomodel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(InicioCurso));
            }
            return View(cursomodel);

        }
        [HttpGet]
        public ActionResult curso()
        {
            ViewBag.CodigoCatedratico = new SelectList(_context.tbl_RegistroCatedratico, "CodigoCatedratico", "NombreCatedratico");
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> ConsultaCurso(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Datos = await _context.tbl_RegistroCursos
                .FirstOrDefaultAsync(a => a.CodigoCurso== int.Parse(id));

            return View(Datos);
        }
        public async Task<IActionResult> EditarCurso(string id)
        {
            int CodigoCurso;
            if (id == null)
            {
                return NotFound();
            }

            CodigoCurso = int.Parse(id);
            var Datos = await _context.tbl_RegistroCursos.FindAsync(CodigoCurso);
            ViewBag.CodigoCatedratico = new SelectList(_context.tbl_RegistroCatedratico, "CodigoCatedratico", "NombreCatedratico");
            
            if (Datos == null)
            {
                return NotFound();
            }
            return View(Datos);

        }

        [HttpPost]
        public async Task<IActionResult> EditarCurso(string id, [Bind("CodigoCurso, NombreCurso, FechaInicio, FechaFinaliza, EstadoCurso, CodigoCatedratico")] CursosModel cursomodel)
        {

            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
                try
                {

                    _context.Update(cursomodel);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuscaCurso(cursomodel.CodigoCurso.ToString()))
                    {
                        return NotFound();

                    }

                }

            return RedirectToAction(nameof(InicioCurso));

        }
        private bool BuscaCurso(string id)
        {

            return _context.tbl_RegistroCursos.Any(e => e.CodigoCurso.ToString() == id);

        }
    }
}
