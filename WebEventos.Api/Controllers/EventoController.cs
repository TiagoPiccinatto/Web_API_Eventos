using Application.Interface;
using Domain.Modesl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repositorio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventoController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await _eventoService.GetAllEventosAsync(true);
                return Ok(eventos);

            }
            catch (Exception erro)
            {

                throw new Exception(erro.Message);
            }
             

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var evento = await _eventoService.GetEventoByIdAsync(id, true);
                return Ok(evento);

            }
            catch (Exception erro)
            {

                throw new Exception(erro.Message);
            }
        }


        [HttpGet("tema/{tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
                var evento = await _eventoService.GetEventosByTemaAsync(tema, true);
                return Ok(evento);

            }
            catch (Exception erro)
            {

                throw new Exception(erro.Message);
            }
        }



        [HttpPost]
        public async Task<IActionResult> Post(EventoModel model)
        {
            try
            {
                var evento = await _eventoService.AddEventos(model);
                if (evento == null) return BadRequest("Evento não cadastrado");                             
                
                return Ok(evento);

            }
            catch (Exception erro)
            {

                throw new Exception(erro.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EventoModel model)
        {
            try
            {
                var evento = await _eventoService.UpdateEventos(id, model);
                if (evento == null) return BadRequest("Evento não cadastrado");                             
                
                return Ok(evento);

            }
            catch (Exception erro)
            {

                throw new Exception(erro.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await _eventoService.DeletarEvento(id))
                return Ok("Evento excluido com sucesso");
                
                else               
                return BadRequest("Evento não deletado");

            }
            catch (Exception erro)
            {

                throw new Exception(erro.Message);
            }
        }
        

    }
}




