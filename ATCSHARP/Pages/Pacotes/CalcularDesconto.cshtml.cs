using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ATCSHARP.Models;

namespace ATCSHARP.Pages.Pacotes {
    public class CalcularDesconto : PageModel {

        private readonly ATCSHARP.Data.ApplicationDbContext _context;

        public CalcularDesconto(ATCSHARP.Data.ApplicationDbContext context) {
            _context = context;
        }

        public delegate double CalculateDelegate(double preco);

        public List<string> Memoria { get; set; } = new();

        private Action<string> Loggers { get; set; }

        [BindProperty]
        public double PrecoComDesconto { get; set; } = 0;

        public List<SelectListItem> TodasCidades { get; set; } = new();

        [BindProperty]
        public PacoteTuristico PacoteTuristico { get; set; } = default!;

        [BindProperty]
        public List<int> CidadesSelecionadas { get; set; } = new();

        private void InicializarLoggers() {
            if (Loggers == null) {
                Loggers = LogToConsole;
                Loggers += LogToFile;
                Loggers += LogToMemory;
            }
        }


        public void LogToConsole(string msg) {
            Console.WriteLine(msg);
        }

        public void LogToFile(string msg) {
            var pastaProjeto = Path.Combine(Directory.GetCurrentDirectory(), "txt"); // apenas para colocar os txts na minha pasta "txt" dentro da raiz do projeto mesmo
            var caminho = Path.Combine(pastaProjeto, "log.txt"); // ele acha a pasta txt e inseri o arquivo lá dentro
            System.IO.File.AppendAllText(caminho, msg + Environment.NewLine);
        }

        public void LogToMemory(string msg) {
            Memoria.Add(msg);
        }

        public List<string> Logs { get; set; } = new();

        public void OnGet() {
            TodasCidades = _context.Cidades.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Nome }).ToList();
            InicializarLoggers();
        }


        public async Task<IActionResult> OnPostAsync() {
            TodasCidades = _context.Cidades.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Nome }).ToList();
            

            if (!ModelState.IsValid) {
                return Page();
            }

            InicializarLoggers();

            CalculateDelegate aplicacaoDoDesconto = preco => preco * 0.9;
            PrecoComDesconto = aplicacaoDoDesconto(PacoteTuristico.Preco);
            Loggers?.Invoke($"Simulação de desconto: preço original {PacoteTuristico.Preco}, com desconto {PrecoComDesconto}");

            return Page();
        }

    }
}
