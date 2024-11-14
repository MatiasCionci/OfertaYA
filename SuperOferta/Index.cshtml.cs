using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SuperOferta.Models;

namespace SuperOferta
{
    public class IndexModel : PageModel
    {
        private readonly SuperOferta.Models.SupermercadoContext _context;

        public IndexModel(SuperOferta.Models.SupermercadoContext context)
        {
            _context = context;
        }

        public IList<Supermercado> Supermercado { get;set; }

        public async Task OnGetAsync()
        {
            Supermercado = await _context.Supermercados.ToListAsync();
        }
    }
}
