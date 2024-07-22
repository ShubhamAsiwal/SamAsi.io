using System.ComponentModel.DataAnnotations;

namespace Techcronus_Test.Models
{
    public class ApiKeyModel
    {
        [Required(ErrorMessage = "API key is required.")]
        [StringLength(50, ErrorMessage = "API key cannot be longer than 100 characters.")]
        public string ApiKey { get; set; }
    }
}
