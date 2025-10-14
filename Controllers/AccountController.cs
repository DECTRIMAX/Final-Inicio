using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Final_Inicio.Models;

namespace Final_Inicio.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Validar credenciales
                var user = ValidateUser(model.Usuario, model.Password);
                if (user != null)
                {
                    // DEBUG: Ver qué usuario se autenticó
                    Console.WriteLine($"Usuario autenticado: {user.Nombre}, Rol: {user.Rol}");

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Nombre),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Role, user.Rol),
                        new Claim("Area", user.Area ?? "")
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = model.RecordarMe,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(2)
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity), authProperties);

                    // DEBUG: Confirmar redirección
                    Console.WriteLine("Redirigiendo a Dashboard");
                    return RedirectToAction("Dashboard", "Home");
                }
                else
                {
                    Console.WriteLine($"Login fallido para usuario: {model.Usuario}");
                    ModelState.AddModelError("", "Usuario o contraseña incorrectos.");
                }
            }
            else
            {
                Console.WriteLine("ModelState no válido");
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Error: {error.ErrorMessage}");
                }
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        // Usuarios de ejemplo
        private UserModel? ValidateUser(string usuario, string password)
        {
            var usuarios = new List<UserModel>
            {
                new UserModel { Id = 1, Usuario = "admin", Password = "admin123", Nombre = "Administrador General", Rol = "Administrador", Area = "Administración" },
                new UserModel { Id = 2, Usuario = "ciudadano", Password = "ciudadano123", Nombre = "Ciudadano", Rol = "Ciudadano", Area = null },
                new UserModel { Id = 3, Usuario = "obras", Password = "obras123", Nombre = "Director de Obras Públicas", Rol = "Empleado", Area = "Obras Públicas" },
                new UserModel { Id = 4, Usuario = "seguridad", Password = "seguridad123", Nombre = "Jefe de Seguridad Pública", Rol = "Empleado", Area = "Seguridad Pública" },
                new UserModel { Id = 5, Usuario = "tesoreria", Password = "tesoreria123", Nombre = "Tesorero Municipal", Rol = "Empleado", Area = "Tesorería" }
            };
            return usuarios.FirstOrDefault(u => u.Usuario == usuario && u.Password == password);
        }
    }
}