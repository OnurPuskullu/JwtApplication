using System.ComponentModel.DataAnnotations;

namespace JwtApplication.Front.Models
{
    public class CreateCategoryModel
    {
        [Required(ErrorMessage ="Kategori adı gereklidir.")]
        public string Definition { get; set; } = null!;
    }
}
