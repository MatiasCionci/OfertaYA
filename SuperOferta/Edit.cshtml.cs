using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperOferta.Models;

namespace SuperOferta
{
    public class EditModel : PageModel
    {
        private readonly SuperOferta.Models.SupermercadoContext _context;

        public EditModel(SuperOferta.Models.SupermercadoContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Supermercado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupermercadoExists(Supermercado.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SupermercadoExists(int id)
        {
            return _context.Supermercados.Any(e => e.Id == id);
        }
    }
}
