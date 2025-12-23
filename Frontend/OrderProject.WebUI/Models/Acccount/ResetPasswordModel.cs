using System.ComponentModel.DataAnnotations;

namespace OrderProject.WebUI.Models.Acccount
{
    public class ResetPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty; 



        [Required]

        public string Token { get; set; } = string.Empty;


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;    

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Parola eşleşmiyor.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
