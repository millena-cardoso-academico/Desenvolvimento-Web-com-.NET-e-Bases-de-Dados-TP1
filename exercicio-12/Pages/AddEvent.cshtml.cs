using exercicio_12.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace exercicio_12.Pages;

public class AddEventModel : PageModel
{
    [BindProperty]
    public Event NovoEvento { get; set; } = new();

    public string? MensagemSucesso { get; private set; }

    public static Action<Event>? OnEventoCadastrado;

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        OnEventoCadastrado?.Invoke(NovoEvento);
        
        MensagemSucesso = $"Evento '{NovoEvento.Titulo}' cadastrado com sucesso para {NovoEvento.Data:d} em {NovoEvento.Local}";
        
        NovoEvento = new Event();
        
        return Page();
    }
}