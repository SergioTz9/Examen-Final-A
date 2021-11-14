using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ControlCatedratico.Models;
using ControlCatedratico.Models.DTOs;
using ControlCatedratico.Repository.iRepository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace ControlCatedratico.Controllers
{
    [Route("api/Catedratico")]
    [ApiController]
    public class CatedraticoControllerAPI : Controller
    {
        private readonly iCatedraticoRepository _ctocatedratico;
        private readonly IMapper _mapper;

        
        public CatedraticoControllerAPI(iCatedraticoRepository ctoCatedratico, IMapper mapper)
        {
            _ctocatedratico = ctoCatedratico;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ListaCatedratico()
        {
            var ListaCatedraticos = _ctocatedratico.GetCatedraticoModels();
            //Dtos
            var ListaCatedraticosDto = new List<CatedraticoDtos>();

            foreach (var Listar in ListaCatedraticos)
            {
                ListaCatedraticosDto.Add(_mapper.Map<CatedraticoDtos>(Listar));
            }
            return Ok(ListaCatedraticosDto);
        }
        [HttpGet("{CodigoCatedratico:int}", Name = "GetCatedraticoByCodigo")]
        public IActionResult GetPersonaByCodigo(int CodigoCatedratico)
        {
            var ListarCatedratico = _ctocatedratico.GetCatedraticoModels(CodigoCatedratico);
            if (ListarCatedratico == null)
            {
                NotFound();
            }
            var RegistroCatedraticoDto = _mapper.Map<CatedraticoDtos>(ListarCatedratico);
            return Ok(RegistroCatedraticoDto);
        }
        [HttpPost]
        public IActionResult CreaCatedratico([FromBody] CatedraticoSaveDtos catedraticoDto)
        {
            if (catedraticoDto == null)
            {
                return BadRequest(ModelState);
            }
            var catedratico = _mapper.Map<CatedraticoModel>(catedraticoDto);

            if (!_ctocatedratico.CrearCatedratico(catedratico))
            {
                ModelState.AddModelError("", $"Ocurrió un Error al grabar el registro { catedratico.CodigoCatedratico}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetCatedraticoByCodigo", new { CodigoCatedratico=catedraticoDto.CodigoCatedratico }, catedratico);
        }
    }
}
