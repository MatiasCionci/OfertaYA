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
    public class DetailsModel : PageModel
    {
        private readonly SuperOferta.Models.SupermercadoContext _context;

        public DetailsModel(SuperOferta.Models.SupermercadoContext context)
        {
            _context = context;
        }

        public Supermercado Supermercado { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Supermercado = await _context.Supermercados.FirstOrDefaultAsync(m => m.Id == id);

            if (Supermercado == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
