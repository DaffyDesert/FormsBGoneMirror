using System.ComponentModel.DataAnnotations;

namespace FormsBGone.DTOs
{
    public class RegisterDTO : LoginDTO
    {
        [Required, DataType(DataType.Text)]
        public string Email { get; set; } = string.Empty;

		[Required, DataType(DataType.Password)]
		public string ConfirmPassword { get; set; } = string.Empty;
    }
}
