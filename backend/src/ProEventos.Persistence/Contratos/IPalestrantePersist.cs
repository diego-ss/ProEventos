using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IPalestrantePersist
    {
         Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string Nome, bool IncluirEventos);
         Task<Palestrante[]> GetAllPalestrantesAsync(bool IncluirEventos);
         Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool IncluirEventos);
    }
}