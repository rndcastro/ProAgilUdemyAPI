using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProAgil.API.Model;
using ProAgil.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ProAgil.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {
        public EventoController(DataContext context)
        {
            Context = context;
        }
        //private readonly ILogger<EventoController> _logger;

        public DataContext Context { get; }

        /*public EventoController(ILogger<EventoController> logger)
        {
            _logger = logger;
        }*/
        /*
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var results = Context.Eventos.ToList();
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Bando de Dados Falhou");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var results = Context.Eventos.FirstOrDefault( evento => evento.EventoId == id);
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Bando de Dados Falhou");
            }
        }*/

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var results = await Context.Eventos.ToListAsync();
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Bando de Dados Falhou");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var results = await Context.Eventos.FirstOrDefaultAsync( evento => evento.EventoId == id);
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Bando de Dados Falhou");
            }
        }
    }
}
