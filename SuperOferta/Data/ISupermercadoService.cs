using SuperOferta.Models;

namespace SuperOferta.Data
{
    public interface ISupermercadoService
    {

        Task<IEnumerable<Models.Supermercado>> GetAllSupermercados();
        Task<Supermercado> GetSupermercadoById(int id);
        Task<bool> insertSupermercado(Supermercado supermercado);
        Task<bool> updateSupermercado(Supermercado supermercado);
        Task<bool> deleteSupermercadoById(int id);
    }
}
