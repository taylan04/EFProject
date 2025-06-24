using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ATCSHARP.Data;
using ATCSHARP.Models;
using Microsoft.EntityFrameworkCore;

namespace ATCSHARP.Pages.Reservas {
    public class CreateModel : PageModel {
        private readonly ATCSHARP.Data.ApplicationDbContext _context;

        public CreateModel(ATCSHARP.Data.ApplicationDbContext context) {
            _context = context;

        }

        public IActionResult OnGet() {
            IniciarSelects();
            return Page();
        }


        [BindProperty]
        public Reserva Reserva { get; set; } = default!;


        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync() {

            IniciarSelects();

            if (!ModelState.IsValid) {

                return Page();
            }

            //bool reservaExistente = await _context.Reservas.AnyAsync(r => r.ClienteId == Reserva.ClienteId && r.PacoteTuristicoId == Reserva.PacoteTuristicoId && r.DataReserva.Date == Reserva.DataReserva.Date);
            bool reservaExistente = await _context.Reservas.AnyAsync(r => r.ClienteId == Reserva.ClienteId && r.PacoteTuristicoId == Reserva.PacoteTuristicoId);

            if (reservaExistente) {
                ModelState.AddModelError(string.Empty, "Você já possui uma reserva para este pacote.");
                return Page();
            }

            var pacote = await _context.Pacotes.Include(p => p.Reservas).FirstOrDefaultAsync(p => p.Id == Reserva.PacoteTuristicoId);



            bool capacityReached = false;

            pacote.CapacityReached += (msg) => {
                Console.WriteLine($"{msg}");
                ModelState.AddModelError(string.Empty, msg);
                capacityReached = true;
            };

            pacote.AdicionarReserva(Reserva);

            if (capacityReached) {
                //esses views data é para popular de novo os meus selects no formulário quando o meu event de erro disparar
                IniciarSelects();
                return Page();
            }

            Reserva.PacoteTuristico = pacote;
            _context.Reservas.Add(Reserva);
            await _context.SaveChangesAsync();


            return RedirectToPage("./Index");
        }

        public void IniciarSelects() {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome");
            ViewData["PacoteTuristicoId"] = new SelectList(_context.Pacotes.Where(p => p.DeleteAt == null).Where(p => p.DataInicio >= DateTime.Now), "Id", "Titulo");
        }

    }
}
