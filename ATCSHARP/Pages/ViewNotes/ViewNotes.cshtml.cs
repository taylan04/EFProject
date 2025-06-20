using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ATCSHARP.Pages.ViewNotes
{
    public class ViewNotesModel : PageModel
    {
        public class InputModel {

            [Required]
            public string Content { get; set; }
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();
        public string Caminho { get; set; }
        public List<string> Arquivos { get; set; } = new();
        public string ConteudoLido { get; set; }
        public string NomeSelecionado { get; set; }

        public void OnGet(string file = null) {
            string pasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");

            if (!Directory.Exists(pasta))
                Directory.CreateDirectory(pasta);

            Arquivos = Directory.GetFiles(pasta, "*.txt").Select(Path.GetFileName).ToList();

            if (!string.IsNullOrEmpty(file)) {
                string caminhoArquivo = Path.Combine(pasta, file);

                if (System.IO.File.Exists(caminhoArquivo)) {
                    NomeSelecionado = file;
                    ConteudoLido = System.IO.File.ReadAllText(caminhoArquivo);
                }
            }
        }


        public void OnPost() {
            
            if (!ModelState.IsValid)
                return;

            string data = DateTime.Now.ToString("yyyyMMdd-HHmmss");
            string nomeArquivo = $"note-{data}.txt";

            string pasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");

            if (!Directory.Exists(pasta))
                Directory.CreateDirectory(pasta);

            string caminhoCompleto = Path.Combine(pasta, nomeArquivo);

            using (StreamWriter escrever = new StreamWriter(caminhoCompleto)) {
                escrever.WriteLine(Input.Content);
            }

            Caminho = $"/files/{nomeArquivo}";

            Arquivos = Directory.GetFiles(pasta, "*.txt").Select(Path.GetFileName).ToList();
        }
    }
}
