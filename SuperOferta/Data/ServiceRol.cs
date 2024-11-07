using SuperOferta.Models;

namespace SuperOferta.Data
{
    public class ServiceRol
    {
        private readonly SupermercadoContext _context;

        public ServiceRol(SupermercadoContext context)
        {
            _context = context;
        }
        public async Task<bool> insertRol(Roles rol)
        {
            _context.Roless.Add(rol);
            return await _context.SaveChangesAsync() > 0;

        }
    }
}
