using System.Threading.Tasks;
using ProEventos.Application.DTOs;

namespace ProEventos.Application.Contratos
{
    public interface IEventoService
    {
        Task<EventoDTO> AddEvento(EventoDTO evento);
        Task<EventoDTO> UpdateEvento(int eventoId, EventoDTO evento);
        Task<bool> DeleteEvento(int eventoId);

        Task<EventoDTO[]> GetAllEventosByTemaAsync(string Tema, bool IncluirPalestrantes = false);
        Task<EventoDTO[]> GetAllEventosAsync(bool IncluirPalestrantes = false);
        Task<EventoDTO> GetEventoByIdAsync(int EventoId, bool IncluirPalestrantes = false);
    }
}