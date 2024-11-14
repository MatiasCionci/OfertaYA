using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SuperOferta.Models;

namespace SuperOferta
{
    public class CreateModel : PageModel
    {
        private readonly SuperOferta.Models.SupermercadoContext _context;

        public CreateModel(SuperOferta.Models.SupermercadoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Supermercado Supermercado { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Supermercados.Add(Supermercado);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
