using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ATCSHARP.Data;
using ATCSHARP.Models;

namespace ATCSHARP.Pages.Reservas
{
    public class CalcularTotalModel : PageModel
    {
        private readonly ATCSHARP.Data.ApplicationDbContext _context;

        public CalcularTotalModel(ATCSHARP.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public double ValorDiaria { get; set; }

        [BindProperty]
        public int Dias {  get; set; }

        public double ValorTotal { get; set; }

        public string Mensagem { get; set; }

        public IActionResult OnGet()
        {
            PopularForm();
            return Page();
        }

        [BindProperty]
        public Reserva Reserva { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                PopularForm();
                return Page();
            }

            Func<double, int, double> calcularTotal = (valorDiaria, dias) => valorDiaria * dias;
            double totalCalculado = calcularTotal(ValorDiaria, Dias);
            ValorTotal = totalCalculado; 
            Mensagem = $"Preço total: {ValorTotal}";

            PopularForm();
            return Page();
        }

        public void PopularForm() {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome");
            ViewData["PacoteTuristicoId"] = new SelectList(_context.Pacotes.Where(p => p.DeleteAt == null), "Id", "Titulo");
        }
    }
}
