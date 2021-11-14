using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlCatedratico.Connection;
using ControlCatedratico.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ControlCatedratico.Connection;
using ControlCatedratico.Models;

namespace ControlCatedratico.Controllers
{
    public class ReporteController : Controller
    {
        private readonly ILogger<ReporteController> _logger;
        private readonly Conn _context;

        public ReporteController(Conn context)

        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Reporte()
        {
            return View();
        }
        public IActionResult Consultas()
        {
            return View();
        }
        public async Task<IActionResult> ConsultaEstadoActivo()
        {
            return View(await _context.tbl_RegistroCatedratico.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> ConsultaEstadoActivo1(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(await _context.tbl_RegistroCatedratico.FirstOrDefaultAsync(e => e.EstadoCatedratico == id));

            

        }
    }

}