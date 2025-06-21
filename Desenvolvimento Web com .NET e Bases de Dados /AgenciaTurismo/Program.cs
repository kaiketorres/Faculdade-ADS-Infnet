using Microsoft.EntityFrameworkCore;
using AgenciaTurismo.Data;
using Microsoft.AspNetCore.Authentication.Cookies; 


namespace AgenciaTurismo;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        
        builder.Services.AddDbContext<AgenciaTurismoContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

      
        builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                options.LoginPath = "/Account/Login"; 
                options.AccessDeniedPath = "/Account/AccessDenied"; 
            });

        builder.Services.AddAuthorization(options =>
        {
            
        });

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

        app.UseAuthentication();
        app.UseAuthorization();
        

        app.MapRazorPages();

        app.Run();
    }
}
