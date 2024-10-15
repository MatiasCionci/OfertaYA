using SuperOferta.Models;

namespace SuperOferta.Data
{
    public interface ISupermercadoService
    {

       public Task<IEnumerable<Models.Supermercado>> GetAllSupermercados();
       public Task<Supermercado> GetSupermercadoById(int id);
       public Task<bool> insertSupermercado(Supermercado supermercado);
       public Task<bool> updateSupermercado(Supermercado supermercado);
       public  Task<bool> deleteSupermercadoById(int id);
        public Task<bool> SaveSupermercado(Supermercado supercado);
    }
}
