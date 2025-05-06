using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoAliLeo.Data;
using ProjetoAliLeo.Models;

namespace ProjetoAliLeo.Controllers
{
        [ApiController]
        [Route("api/[controller]")]

    public class EventosController : ControllerBase
{
    private readonly IEventoRepository _eventoRepository;
     public EventosController(IEventoRepository eventoRepository)
    {
        _eventoRepository = eventoRepository;
    }

    
        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromBody] Evento evento)
        {
            _eventoRepository.Cadastrar(evento);
            return Created("", evento);
        }

        [HttpGet("listar")]
        [Authorize]
        public IActionResult Listar()
        {
            var eventos = _eventoRepository.Listar();
            return Ok(eventos);
        }
    }
}