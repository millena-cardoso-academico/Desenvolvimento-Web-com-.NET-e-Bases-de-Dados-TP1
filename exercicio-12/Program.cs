using exercicio_12.Models;
using exercicio_12.Pages;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

// Configuração do delegate
AddEventModel.OnEventoCadastrado = evento =>
{
    Console.WriteLine($"EVENTO CADASTRADO:");
    Console.WriteLine($"Título: {evento.Titulo}");
    Console.WriteLine($"Data: {evento.Data}");
    Console.WriteLine($"Local: {evento.Local}");
    Console.WriteLine(new string('-', 30));
};

var app = builder.Build();

app.UseStaticFiles();
app.MapRazorPages();
app.Run();