using Eshop.RazorPage.Infrastructure.RazorUtils;
using Eshop.RazorPage.Models.Roles;
using Eshop.RazorPage.Services.Roles;

namespace Eshop.RazorPage.Pages.Admin.Roles
{
    public class IndexModel : BaseRazorPage
    {
        private IRoleService _roleService;

        public IndexModel(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public List<RoleDto> Roles { get; set; }
        public async Task OnGet()
        {
            Roles = await _roleService.GetRoles();
        }
    }
}
