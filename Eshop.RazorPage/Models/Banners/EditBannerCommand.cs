using System.ComponentModel.DataAnnotations;
namespace Eshop.RazorPage.Models.Banners;

public class EditBannerCommand
{
    public long Id { get; set; }
    [Display(Name = "لینک")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [DataType(DataType.Url)]
    public string Link { get; set; }
    public BannerPosition Position { get; set; }

    [Display(Name = "عکس")]
    public IFormFile? ImageFile { get; set; }
}