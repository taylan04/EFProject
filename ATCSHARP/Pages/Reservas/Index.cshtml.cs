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
    public class IndexModel : PageModel
    {
        private readonly ATCSHARP.Data.ApplicationDbContext _context;

        public IndexModel(ATCSHARP.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Reserva> Reserva { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Reserva = await _context.Reservas.Include(r => r.Cliente).Include(r => r.PacoteTuristico).ToListAsync();
        }
    }
}
