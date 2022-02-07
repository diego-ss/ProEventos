using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public interface IProEventosPersistence
    {
        //Métodos gerais
         void Add<T>(T entity) where T: class;
         void Update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         void DeleteRange<T>(T[] entity) where T: class;
         Task<bool> SaveChangesAsync();

         //Eventos
         Task<Evento[]> GetAllEventosByTemaAsync(string Tema, bool IncluirPalestrantes);
         Task<Evento[]> GetAllEventosByAsync(bool IncluirPalestrantes);
         Task<Evento> GetAllEventoByIdAsync(int EventoId, bool IncluirPalestrantes);

         //Palestrantes
         Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string Nome, bool IncluirEventos);
         Task<Palestrante[]> GetAllPalestrantesByAsync(bool IncluirEventos);
         Task<Palestrante> GetAllPalestranteByIdAsync(int PalestranteId, bool IncluirEventos);
    }
}