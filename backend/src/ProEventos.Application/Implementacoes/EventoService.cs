using System;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        public IEventoPersist _eventoPersist { get; }
        public IGeralPersist _geralPersist{ get; }

        public EventoService(IEventoPersist eventoPersist, IGeralPersist geralPersist)
        {
            this._eventoPersist = eventoPersist;
            this._geralPersist = geralPersist;
        }

        public async Task<Evento> AddEvento(Evento evento)
        {
            try{
                _geralPersist.Add<Evento>(evento);

                if(await _geralPersist.SaveChangesAsync()) {
                    return evento;
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

        public async Task<Evento> UpdateEvento(int eventoId, Evento evento)
        {
             try{
                 var oldEvento = await _eventoPersist.GetEventoByIdAsync(eventoId);

                 if(oldEvento == null)
                    return null;
                
                evento.Id = oldEvento.Id;
                _geralPersist.Update<Evento>(evento);

                if(await _geralPersist.SaveChangesAsync()) {
                    return evento;
                } else {
                    return null;
                }
            } 
            catch (Exception ex) {    
                throw new Exception("Failed to update evento instance.\n" + ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool IncluirPalestrantes = false)
        {
            try {
                return await _eventoPersist.GetAllEventosAsync(IncluirPalestrantes);
            }
            catch(Exception ex) {
                throw new Exception("Failed to retrieve all eventos.\n" + ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string Tema, bool IncluirPalestrantes = false)
        {
            try {
                return await _eventoPersist.GetAllEventosByTemaAsync(Tema, IncluirPalestrantes);
            }
            catch(Exception ex) {
                throw new Exception("Failed to retrieve eventos by tema.\n" + ex.Message);
            }        
        }

        public async Task<Evento> GetEventoByIdAsync(int EventoId, bool IncluirPalestrantes = false)
        {
            try {
                return await _eventoPersist.GetEventoByIdAsync(EventoId, IncluirPalestrantes);
            }
            catch(Exception ex) {
                throw new Exception("Failed to retrieve eventos by id.\n" + ex.Message);
            }  
        }
    }
}