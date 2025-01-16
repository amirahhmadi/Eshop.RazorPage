using Eshop.RazorPage.Infrastructure.RazorUtils;
using Eshop.RazorPage.Services.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Eshop.RazorPage.Pages.Auth
{
    [BindProperties]
    public class RegisterModel : BaseRazorPage
    {
        private readonly IAuthService _authService;
        public RegisterModel(IAuthService authService)
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

        [Display(Name = "تکرار کلمه عبور"),
        Required(ErrorMessage = "{0} را وارد کنید"),
            MinLength(8, ErrorMessage = "{0} باید 8 کارکتر باشد"),
            Compare("Password", ErrorMessage = "کلمه عبور یکسان نیست"),
            DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public void OnGet()
        {
            //if (User.Identity.IsAuthenticated)
            //    return Redirect("/");

            //return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var result = await _authService.Register(new Models.Auth.RegisterCommand()
            {
                PhoneNumber = PhoneNumber,
                Password = Password,
                ConfirmPassword = ConfirmPassword

            });
            
            return RedirectAndShowAlert(result, RedirectToPage("Login"));
                
        }
    }
}
