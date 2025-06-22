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
    public class IndexModel : PageModel
    {
        private readonly ATCSHARP.Data.ApplicationDbContext _context;

        public IndexModel(ATCSHARP.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CidadeDestino> CidadeDestino { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CidadeDestino = await _context.Cidades.Include(c => c.PaisDestino).ToListAsync();
        }
    }
}
