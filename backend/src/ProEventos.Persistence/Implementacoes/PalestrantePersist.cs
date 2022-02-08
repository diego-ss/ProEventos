using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence.Implementacoes
{
    public class PalestrantePersist : IPalestrantePersist
    {
        public ProEventosContext _context { get; }

        public PalestrantePersist(ProEventosContext context)
        {
            this._context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        
        public async Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool IncluirEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                                        .Include(x => x.RedesSociais);

            if(IncluirEventos)
                query = query.Include(x=>x.Eventos)
                            .ThenInclude(e => e.Evento);
            
            query = query.OrderBy(p=>p.Id).Where(p => p.Id == PalestranteId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool IncluirEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                                        .Include(x => x.RedesSociais);

            if(IncluirEventos)
                query = query.Include(x=>x.Eventos)
                            .ThenInclude(e => e.Evento);
            
            query = query.OrderBy(e=>e.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string Nome, bool IncluirEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                                        .Include(x => x.RedesSociais);

            if(IncluirEventos)
                query = query.Include(x=>x.Eventos)
                            .ThenInclude(e => e.Evento);
            
            query = query.OrderBy(p=>p.Id).Where(p => p.Nome.ToLower().Contains(Nome.ToLower()));
            return await query.ToArrayAsync();
        }

    }
}