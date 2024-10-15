using Microsoft.EntityFrameworkCore;
using SuperOferta.Models;

namespace SuperOferta.Data
{
    public class SupermercadoService : ISupermercadoService
    {
        private readonly SupermercadoContext _context;

        public SupermercadoService(SupermercadoContext context)
        {
            _context = context;
        }

        public async Task<bool> deleteSupermercadoById(int id)
        {
            var supermercad = await _context.Supermercados.FindAsync(id);
            _context.Supermercados.Remove(supermercad);
            //solo porque estoy devolviendo tipo bool mayor a 0
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Supermercado>> GetAllSupermercados()
        {
            return await _context.Supermercados.ToListAsync();


        }



        public async Task<bool> insertSupermercado(Supermercado supermercado)
        {
            _context.Supermercados.Add(supermercado);
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<bool> SaveSupermercado(Supermercado supercado)
        {
            if (supercado.Id > 0)
            {
                return await updateSupermercado(supercado);
            }
            else
            {
                return await insertSupermercado(supercado);
            }
        }

        public async Task<bool> updateSupermercado(Supermercado supermercado)
        {
            _context.Entry(supermercado).State=EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        async Task<Supermercado> ISupermercadoService.GetSupermercadoById(int id)
        {
            return await _context.Supermercados.FindAsync(id);
        }
    }
}
