using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private IEnumerable<Evento> _eventos = new Evento[]{
                new Evento(){
                    EventoId = 1,
                    Tema = "Angular 11 e .Net 5",
                    Local = "Belo Horizonte",
                    Lote = "1º Lote",
                    QtdPessoas = 250,
                    DataEvento = DateTime.Now.AddDays(4).ToShortDateString(),
                    ImgUrl = "photo.png"
                },
                new Evento(){
                    EventoId = 2,
                    Tema = "NodeJS para Iniciantes",
                    Local = "São Paulo",
                    Lote = "1º Lote",
                    QtdPessoas = 100,
                    DataEvento = DateTime.Now.AddDays(2).ToShortDateString(),
                    ImgUrl = "nodejs.png"
                },
            };

        public EventoController()
        {
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return this._eventos;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> Get(int id)
        {
            return this._eventos.Where(e=>e.EventoId== id);
        }
    }
}
