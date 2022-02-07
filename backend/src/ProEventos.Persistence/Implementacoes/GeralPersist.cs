using System.Threading.Tasks;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence.Implementacoes
{
    public class GeralPersist : IGeralPersist
    {
        public ProEventosContext _context { get; }

        public GeralPersist(ProEventosContext context)
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
       
    }
}