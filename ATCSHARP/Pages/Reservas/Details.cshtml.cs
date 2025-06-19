using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ATCSHARP.Data;
using ATCSHARP.Models;

namespace ATCSHARP.Pages.Reservas
{
    public class DetailsModel : PageModel
    {
        private readonly ATCSHARP.Data.ApplicationDbContext _context;

        public DetailsModel(ATCSHARP.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Reserva Reserva { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null) {
                return NotFound();
            }

            Reserva = await _context.Reservas.Include(r => r.Cliente).Include(r => r.PacoteTuristico).FirstOrDefaultAsync(m => m.Id == id);

            if (Reserva == null) {
                return NotFound();
            }

            return Page();
        }
    }
}
