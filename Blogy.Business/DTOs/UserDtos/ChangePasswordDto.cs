using System.ComponentModel.DataAnnotations;

namespace Blogy.Business.DTOs.UserDtos
{
    public class ChangePasswordDto
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }

        [Compare(nameof(NewPassword), ErrorMessage = "Şifreler birbiriyle uyumlu değil")]
        public string ConfirmPassword { get; set; }
    }
}
