using System.ComponentModel.DataAnnotations;

namespace SmartEvent.Core.DTO
{
    public class OrganisationRegisterModel
    {
        [Required, StringLength(100)]
        public string Nom { get; set; }

        [Required, StringLength(100)]
        public string Email { get; set; }

        [Required, StringLength(100)]
        public string Password { get; set; }

    }
}