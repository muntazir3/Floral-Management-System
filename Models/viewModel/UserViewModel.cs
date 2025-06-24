using System.ComponentModel.DataAnnotations;

namespace Floral_Shop.Models.viewModel
{
    public class UserViewModel
    {

        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        
        [Required]
        [StringLength(8, MinimumLength =6, ErrorMessage ="password lenght must be 6 to 8")]
        public string Password { get; set; } = null!;

        public string Role { get; set; } = null!;

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? Phone { get; set; }

    } 
}
