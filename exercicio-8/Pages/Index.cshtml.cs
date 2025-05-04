using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Exercicio8.Pages
{
    public class IndexModel : PageModel
    {
        public List<Produto> Produtos { get; set; }

        public void OnGet()
        {
            Produtos = new List<Produto>
            {
                new Produto { Nome = "Notebook Dell", Preco = 4299.90m },
                new Produto { Nome = "Mouse Sem Fio", Preco = 89.90m },
                new Produto { Nome = "Teclado Mecânico", Preco = 249.90m }
            };
        }
    }

    public class Produto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}