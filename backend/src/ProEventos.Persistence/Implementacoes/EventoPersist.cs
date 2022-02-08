using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence.Implementacoes
{
    public class EventoPersist : IEventoPersist
    {
        public ProEventosContext _context { get; }

        public EventoPersist(ProEventosContext context)
        {
            this._context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Evento> GetEventoByIdAsync(int EventoId, bool IncluirPalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                                        .Include(x => x.RedesSociais)
                                        .Include(x => x.Lotes);

            if(IncluirPalestrantes)
                query = query.Include(x=>x.Palestrantes)
                            .ThenInclude(p=>p.Palestrante);

            query = query.OrderBy(e=>e.Id).Where(e => e.Id == EventoId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventosAsync(bool IncluirPalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                                        .Include(x => x.RedesSociais)
                                        .Include(x => x.Lotes);

            if(IncluirPalestrantes)
                query = query.Include(x=>x.Palestrantes)
                            .ThenInclude(p=>p.Palestrante);

            query = query.OrderBy(e=>e.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string Tema, bool IncluirPalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                                        .Include(x => x.RedesSociais)
                                        .Include(x => x.Lotes);

            if(IncluirPalestrantes)
                query = query.Include(x=>x.Palestrantes)
                            .ThenInclude(p=>p.Palestrante);

            query = query.OrderBy(e=>e.Id).Where(e => e.Tema.ToLower().Contains(Tema.ToLower()));
            return await query.ToArrayAsync();
        }

    }
}