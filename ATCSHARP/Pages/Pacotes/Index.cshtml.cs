using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ATCSHARP.Data;
using ATCSHARP.Models;

namespace ATCSHARP.Pages.Pacotes {
    public class IndexModel : PageModel {
        private readonly ATCSHARP.Data.ApplicationDbContext _context;

        public IndexModel(ATCSHARP.Data.ApplicationDbContext context) {
            _context = context;
        }

        public IList<PacoteTuristico> PacoteTuristico { get; set; } = default!;

        public async Task OnGetAsync() {
            PacoteTuristico = await _context.Pacotes.Where(p => p.DeleteAt == null)
                .Where(p => p.DataInicio >= DateTime.Now)
                .Include(p => p.Destinos)
                .ThenInclude(d => d.CidadeDestino).ToListAsync();
        }
    }
}
