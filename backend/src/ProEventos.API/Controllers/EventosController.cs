using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Contratos;
using Microsoft.AspNetCore.Http;
using ProEventos.Domain;
using System.Collections.Generic;
using ProEventos.Application.DTOs;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventosController(IEventoService eventoService)
        {
            this._eventoService = eventoService;
        }

        [HttpGet]
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get()
        {
            try{
                var eventosList = await this._eventoService.GetAllEventosAsync(true);

                if(eventosList == null)
                    return NotFound("Nenhum evento encontrado.");

                return Ok(eventosList);
            } 
            catch (Exception ex){
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            try{
                var evento = await this._eventoService.GetEventoByIdAsync(id, true);

                if(evento == null)
                    return NotFound("Nenhum evento encontrado.");
                
                return Ok(evento);
            } 
            catch (Exception ex){
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }        
        }

        [HttpGet("tema/{tema}")]
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try{
                var evento = await this._eventoService.GetAllEventosByTemaAsync(tema, true);

                if(evento == null)
                    return NotFound("Nenhum evento encontrado.");
                
                return Ok(evento);
            } 
            catch (Exception ex){
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }        
        }

        [HttpPost]
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Post(EventoDTO model){
            try{
                var evento = await this._eventoService.AddEvento(model);
                
                if (evento == null)
                    return BadRequest("Falha ao tentar adicionar evento.");

                return Ok(evento);
            } 
            catch (Exception ex){
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }      
        }

        [HttpPut("{id}")]
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put(int id, EventoDTO model){
            try{
                var evento = await this._eventoService.UpdateEvento(id, model);

                if(evento == null)
                    return BadRequest("Erro ao atualizar evento.");

                return Ok(evento);
            } 
            catch (Exception ex){
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }     
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id){
             try{
                if (await this._eventoService.DeleteEvento(id))
                    return Ok();
                else 
                    return BadRequest("Erro ao deletar evento.");
            } 
            catch (Exception ex){
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }     
        }
    }
}
