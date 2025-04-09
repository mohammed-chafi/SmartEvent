using System.ComponentModel.DataAnnotations;

namespace SmartEvent.Core.DTO
{
    public class TokenRequestModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}