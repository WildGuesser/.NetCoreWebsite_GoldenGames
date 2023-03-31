using System.ComponentModel.DataAnnotations;

namespace GoldenGames.Areas.Admin.ViewModels
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Campo obrigatório"), StringLength(40, ErrorMessage = "Limite Máximo é 40 carateres")]
        [Display(Name = "Nome")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar password")]
        [Compare("Password", ErrorMessage = "As passwords devem ser iguais")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.PhoneNumber, ErrorMessage = ("O número de telefone introduzido não é valido"))]
        public string? Telefone { get; set; }
    }
}
