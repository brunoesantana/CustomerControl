using System.ComponentModel.DataAnnotations;

namespace CustomerControl.CrossCutting.Dto.User
{
    public class UserInsertDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Senha e confirmação de senha devem ser iguais.")]
        public string PasswordCheck { get; set; }
    }
}