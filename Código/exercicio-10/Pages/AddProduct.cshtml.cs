using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace exercicio_10.Pages
{
    public class AddProductModel : PageModel
    {
        [BindProperty]
        public string? Nome { get; set; }  // Adicione '?' para tornar nullable

        [BindProperty]
        public decimal Preco { get; set; }

        public bool ProductAdded { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrEmpty(Nome))
            {
                ProductAdded = true;
            }
            return Page();
        }
    }
}