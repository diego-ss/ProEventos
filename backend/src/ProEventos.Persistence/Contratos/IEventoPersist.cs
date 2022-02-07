using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IEventoPersist
    {

         Task<Evento[]> GetAllEventosByTemaAsync(string Tema, bool IncluirPalestrantes);
         Task<Evento[]> GetAllEventosAsync(bool IncluirPalestrantes);
         Task<Evento> GetEventoByIdAsync(int EventoId, bool IncluirPalestrantes);
    }
}