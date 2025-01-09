using Eshop.RazorPage.Services.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Eshop.RazorPage.Pages.Auth
{
    [BindProperties]
    [ValidateAntiForgeryToken]
    public class LoginModel : PageModel
    {
        private readonly IAuthService _authService;
        public LoginModel(IAuthService authService)
        {
            _authService = authService;
        }

        [Display(Name = "شماره تلفن"),
        Required(ErrorMessage = "{0} را وارد کنید"),
            MaxLength(11, ErrorMessage = "شماره تلفن معتبر نیست")]
        public string PhoneNumber { get; set; }

        [Display(Name = "کلمه عبور"),
        Required(ErrorMessage = "{0} را وارد کنید"),
            MinLength(8, ErrorMessage = "{0} باید 8 کارکتر باشد"),
            DataType(DataType.Password)]
        public string Password { get; set; }

        public string RedirectTo { get; set; }
        public IActionResult OnGet(string redirectTo)
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            RedirectTo = redirectTo;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var result = await _authService.Login(new Models.Auth.LoginCommand()
            {
                PhoneNumber = PhoneNumber,
                Password = Password
            });
            if (result.IsSuccess == false)
            {
                ModelState.AddModelError(nameof(PhoneNumber), result.MetaData.Message);
                return Page();
            }
            var token = result.Data.Token;
            var refreshToken = result.Data.RefreshToken;
            HttpContext.Response.Cookies.Append("token", token);
            HttpContext.Response.Cookies.Append("refresh-token", refreshToken);

            if (string.IsNullOrWhiteSpace(RedirectTo) == false)
            {
                return LocalRedirect(RedirectTo);
            }
            return Redirect("/");
        }
    }
}
