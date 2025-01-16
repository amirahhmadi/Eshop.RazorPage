

namespace Eshop.RazorPage.Models.Users;

public class UserFilterResult : BaseFilter<UserFilterData, UserFilterParams>
{
    public List<UserDto> Users { get; internal set; }

    public static implicit operator UserFilterResult(List<UserDto> v)
    {
        throw new NotImplementedException();
    }
}