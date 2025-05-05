using exercicio_12.Models;
using exercicio_12.Pages;

var builder = WebApplication.CreateBuilder(args);

AddEventModel.OnEventoCadastrado = evento =>
{
    Console.WriteLine("\n--- NOVO EVENTO CADASTRADO ---");
    Console.WriteLine($"Título: {evento.Titulo}");
    Console.WriteLine($"Data: {evento.Data:dd/MM/yyyy HH:mm}");
    Console.WriteLine($"Local: {evento.Local}");
    Console.WriteLine("-----------------------------\n");
};

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();