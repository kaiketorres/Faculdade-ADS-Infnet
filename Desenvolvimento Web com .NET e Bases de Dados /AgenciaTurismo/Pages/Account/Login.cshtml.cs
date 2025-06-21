using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations; // Para validação

namespace AgenciaTurismo.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(ILogger<LoginModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public string? ReturnUrl { get; set; }

        [TempData] // Usado para mensagens temporárias, ex: erro de login
        public string? ErrorMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
            [Display(Name = "Nome de Usuário")]
            public string Username { get; set; } = string.Empty;

            [Required(ErrorMessage = "A senha é obrigatória.")]
            [DataType(DataType.Password)]
            [Display(Name = "Senha")]
            public string Password { get; set; } = string.Empty;
        }

        public async Task OnGetAsync(string? returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            // Garante que o usuário não esteja autenticado ao acessar a página de login
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            ReturnUrl = returnUrl;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Lógica de autenticação simples (usuário/senha fixos)
            // EM UM SISTEMA REAL, ISSO SERIA VERIFICADO CONTRA UM BANCO DE DADOS
            if (Input.Username == "admin" && Input.Password == "password")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Input.Username),
                    new Claim(ClaimTypes.Role, "Admin") // Exemplo de papel
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true, // Mantém o cookie após fechar o navegador
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30) // Expira em 30 minutos
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                _logger.LogInformation("User '{Username}' logged in successfully.", Input.Username);

                // Redireciona para a URL original que o usuário tentou acessar, ou para a Home
                return LocalRedirect(returnUrl ?? Url.Content("~/"));
            }
            else
            {
                ErrorMessage = "Nome de usuário ou senha inválidos.";
                ModelState.AddModelError(string.Empty, ErrorMessage);
                _logger.LogWarning("Failed login attempt for user '{Username}'.", Input.Username);
                return Page();
            }
        }
    }
}
