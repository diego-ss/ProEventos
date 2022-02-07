using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Contratos
{
    public interface IEventoService
    {
        Task<Evento> AddEvento(Evento evento);
        Task<Evento> UpdateEvento(int eventoId, Evento evento);
        Task<bool> DeleteEvento(int eventoId);

        Task<Evento[]> GetAllEventosByTemaAsync(string Tema, bool IncluirPalestrantes = false);
        Task<Evento[]> GetAllEventosAsync(bool IncluirPalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int EventoId, bool IncluirPalestrantes = false);
    }
}