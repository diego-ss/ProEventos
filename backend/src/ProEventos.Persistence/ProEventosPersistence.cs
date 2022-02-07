using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public class ProEventosPersistence : IProEventosPersistence
    {
        public ProEventosContext _context { get; }

        public ProEventosPersistence(ProEventosContext context)
        {
            this._context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add<T>(entity);
        }
        
        public void Update<T>(T entity) where T : class
        {
            _context.Update<T>(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove<T>(entity);
        }

        public void DeleteRange<T>(T[] entity) where T : class
        {
            _context.RemoveRange(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await this._context.SaveChangesAsync()) > 0;
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

        public async Task<Evento[]> GetAllEventosByTemaAsync(string Tema, bool IncluirPalestrantes)
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

        public async Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool IncluirEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                                        .Include(x => x.RedesSociais);

            if(IncluirEventos)
                query = query.Include(x=>x.Eventos)
                            .ThenInclude(e => e.Evento);
            
            query = query.OrderBy(p=>p.Id).Where(p => p.Id == PalestranteId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool IncluirEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                                        .Include(x => x.RedesSociais);

            if(IncluirEventos)
                query = query.Include(x=>x.Eventos)
                            .ThenInclude(e => e.Evento);
            
            query = query.OrderBy(e=>e.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string Nome, bool IncluirEventos)
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