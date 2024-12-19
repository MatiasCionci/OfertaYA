namespace SuperOferta.Components.Pages.Account.Pages.Manage
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SuperOferta.Models;
    using System.Text.Encodings.Web;
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly EmailService _emailService;
        private readonly UrlEncoder _urlEncoder;

        public AccountController(UserManager<IdentityUser> userManager, EmailService emailService, UrlEncoder urlEncoder)
        {
            _userManager = userManager;
            _emailService = emailService;
            _urlEncoder = urlEncoder;
        }

        [HttpPost]
        public async Task<IActionResult> Register(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                // Generar token de confirmación
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var encodedToken = _urlEncoder.Encode(token);

                // Crear enlace de confirmación
                var confirmationLink = Url.Action("ConfirmEmail", "Account",
                    new { userId = user.Id, token = encodedToken }, Request.Scheme);

                // Enviar correo
                var subject = "Confirma tu cuenta";
                var body = $"Por favor confirma tu cuenta haciendo clic en este enlace: <a href='{confirmationLink}'>Confirmar</a>";
                await _emailService.SendEmailAsync(email, subject, body);

                return Ok("Registro exitoso. Revisa tu correo para confirmar la cuenta.");
            }

            return BadRequest(result.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound("Usuario no encontrado.");

            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
                return Ok("Correo confirmado con éxito. Ya puedes iniciar sesión.");

            return BadRequest("Error al confirmar el correo.");
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                return BadRequest("Correo no encontrado o no confirmado.");

            // Generar token de restablecimiento de contraseña
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = _urlEncoder.Encode(token);

            // Crear enlace de restablecimiento
            var resetLink = Url.Action("ResetPassword", "Account",
                new { token = encodedToken, email = user.Email }, Request.Scheme);

            // Enviar correo
            var subject = "Restablece tu contraseña";
            var body = $"Haz clic en este enlace para restablecer tu contraseña: <a href='{resetLink}'>Restablecer</a>";
            await _emailService.SendEmailAsync(email, subject, body);

            return Ok("Revisa tu correo para restablecer la contraseña.");
        }

        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            ViewData["Token"] = token;
            ViewData["Email"] = email;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(string email, string token, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return NotFound("Usuario no encontrado.");

            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

            if (result.Succeeded)
                return Ok("Contraseña restablecida con éxito.");

            return BadRequest("Error al restablecer la contraseña.");
        }
    }
}
