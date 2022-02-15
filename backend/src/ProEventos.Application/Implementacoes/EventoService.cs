using System;
using System.Threading.Tasks;
using AutoMapper;
using ProEventos.Application.Contratos;
using ProEventos.Application.DTOs;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        public IEventoPersist _eventoPersist { get; }
        public IGeralPersist _geralPersist{ get; }
        public IMapper _mapper{ get; }

        public EventoService(IEventoPersist eventoPersist, 
                             IGeralPersist geralPersist, 
                             IMapper mapper)
        {
            this._eventoPersist = eventoPersist;
            this._geralPersist = geralPersist;
            this._mapper = mapper;
        }

        public async Task<EventoDTO> AddEvento(EventoDTO evento)
        {
            try{

                var model = _mapper.Map<Evento>(evento);
                _geralPersist.Add<Evento>(model);

                if(await _geralPersist.SaveChangesAsync()) {
                return _mapper.Map<EventoDTO>(model);
                } else {
                    return null;
                }
            } catch (Exception ex) {    
                throw new Exception("Failed to add new Evento.\n" + ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try{
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId);

                if(evento == null)
                    throw new Exception("Evento instance was not found.");

                _geralPersist.Delete<Evento>(evento);
                return await _geralPersist.SaveChangesAsync();            
            } 
            catch (Exception ex) {    
                throw new Exception("Failed to delete evento instance.\n" + ex.Message);
            }
        }

        public async Task<EventoDTO> UpdateEvento(int eventoId, EventoDTO evento)
        {
             try{
                 var oldEvento = await _eventoPersist.GetEventoByIdAsync(eventoId);

                 if(oldEvento == null)
                    return null;
                
                evento.Id = oldEvento.Id;

                var model = _mapper.Map<Evento>(evento);
                _geralPersist.Update<Evento>(model);

                if(await _geralPersist.SaveChangesAsync()) {
                return _mapper.Map<EventoDTO>(model);
                } else {
                    return null;
                }
            } 
            catch (Exception ex) {    
                throw new Exception("Failed to update evento instance.\n" + ex.Message);
            }
        }

        public async Task<EventoDTO[]> GetAllEventosAsync(bool IncluirPalestrantes = false)
        {
            try {
                return _mapper.Map<EventoDTO[]>(await _eventoPersist.GetAllEventosAsync(IncluirPalestrantes));
            }
            catch(Exception ex) {
                throw new Exception("Failed to retrieve all eventos.\n" + ex.Message);
            }
        }

        public async Task<EventoDTO[]> GetAllEventosByTemaAsync(string Tema, bool IncluirPalestrantes = false)
        {
            try {
                return _mapper.Map<EventoDTO[]>(await _eventoPersist.GetAllEventosByTemaAsync(Tema, IncluirPalestrantes));
            }
            catch(Exception ex) {
                throw new Exception("Failed to retrieve eventos by tema.\n" + ex.Message);
            }        
        }

        public async Task<EventoDTO> GetEventoByIdAsync(int EventoId, bool IncluirPalestrantes = false)
        {
            try {
                return _mapper.Map<EventoDTO>(await _eventoPersist.GetEventoByIdAsync(EventoId, IncluirPalestrantes));
            }
            catch(Exception ex) {
                throw new Exception("Failed to retrieve eventos by id.\n" + ex.Message);
            }  
        }
    }
}