using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ATCSHARP.Data;
using ATCSHARP.Models;

namespace ATCSHARP.Pages.Cidades
{
    public class CreateModel : PageModel
    {
        private readonly ATCSHARP.Data.ApplicationDbContext _context;

        public CreateModel(ATCSHARP.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PaisDestinoId"] = new SelectList(_context.Paises, "Id", "Nome");
            return Page();
        }

        [BindProperty]
        public CidadeDestino CidadeDestino { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cidades.Add(CidadeDestino);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
