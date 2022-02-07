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
                throw new Exception("Failed to add new Evento. " + ex.Message);
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
                throw new Exception("Failed to delete evento instance. " + ex.Message);
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
                throw new Exception("Failed to update evento instance. " + ex.Message);
            }
        }

        public Task<Evento[]> GetAllEventosAsync(bool IncluirPalestrantes = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<Evento[]> GetAllEventosByTemaAsync(string Tema, bool IncluirPalestrantes = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<Evento> GetEventoByIdAsync(int EventoId, bool IncluirPalestrantes = false)
        {
            throw new System.NotImplementedException();
        }
    }
}