using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ATCSHARP.Data;
using ATCSHARP.Models;

namespace ATCSHARP.Pages.Cidades
{
    public class DeleteModel : PageModel
    {
        private readonly ATCSHARP.Data.ApplicationDbContext _context;

        public DeleteModel(ATCSHARP.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CidadeDestino CidadeDestino { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidadedestino = await _context.Cidades.Include(p => p.PaisDestino).FirstOrDefaultAsync(m => m.Id == id);

            if (cidadedestino == null)
            {
                return NotFound();
            }
            else
            {
                CidadeDestino = cidadedestino;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidadedestino = await _context.Cidades.FindAsync(id);
            if (cidadedestino != null)
            {
                CidadeDestino = cidadedestino;
                _context.Cidades.Remove(CidadeDestino);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
