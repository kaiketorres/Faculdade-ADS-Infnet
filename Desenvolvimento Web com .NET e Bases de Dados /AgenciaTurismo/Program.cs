using Microsoft.EntityFrameworkCore;
using AgenciaTurismo.Data;
using AgenciaTurismo.Models;
using Microsoft.AspNetCore.Authentication.Cookies; // Para autenticação por cookies
using Microsoft.AspNetCore.Authorization; // Adicione este using para o atributo Authorize

namespace AgenciaTurismo;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Adiciona o DbContext ao contêiner de serviços
        builder.Services.AddDbContext<AgenciaTurismoContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

        // --- INÍCIO DA ADIÇÃO DA AUTENTICAÇÃO (CORRIGIDA) ---
        // Define o esquema de autenticação padrão para "Cookies"
        builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                options.LoginPath = "/Account/Login"; // Página de login
                options.AccessDeniedPath = "/Account/AccessDenied"; // Página para acesso negado
            });

        builder.Services.AddAuthorization(options =>
        {
            // Opcional: Definir políticas de autorização, se precisar de papéis mais complexos
            // options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
        });
        // --- FIM DA ADIÇÃO DA AUTENTICAÇÃO ---


        // Add services to the container.
        builder.Services.AddRazorPages();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        // --- Middleware de Autenticação e Autorização ---
        // DEVE VIR ANTES de app.MapRazorPages()
        app.UseAuthentication();
        app.UseAuthorization();
        // --- FIM Middleware de Autenticação e Autorização ---

        app.MapRazorPages();

        app.Run();
    }
}
