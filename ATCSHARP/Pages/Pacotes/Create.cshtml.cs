using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ATCSHARP.Data;
using ATCSHARP.Models;

namespace ATCSHARP.Pages.Pacotes
{
    public class CreateModel : PageModel
    {
        private readonly ATCSHARP.Data.ApplicationDbContext _context;

        public CreateModel(ATCSHARP.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public List<SelectListItem> TodasCidades { get; set; } = new();

        [BindProperty]
        public PacoteTuristico PacoteTuristico { get; set; } = default!;

        [BindProperty]
        public List<int> CidadesSelecionadas { get; set; } = new();

        public void OnGet()
        {
            TodasCidades = _context.Cidades
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Nome })
                .ToList();
        }

       
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                TodasCidades = _context.Cidades.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Nome }).ToList();
                return Page();
            }

            
            _context.Pacotes.Add(PacoteTuristico);
            await _context.SaveChangesAsync();

            
            foreach (var cidadeId in CidadesSelecionadas)
            {
                var destino = new Destino
                {
                    PacoteTuristicoId = PacoteTuristico.Id,
                    CidadeDestinoId = cidadeId
                };
                _context.Destinos.Add(destino);
            }
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
