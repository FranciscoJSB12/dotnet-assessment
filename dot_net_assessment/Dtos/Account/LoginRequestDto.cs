using System.ComponentModel.DataAnnotations;

namespace dot_net_assessment.Dtos.Account
{
    public class LoginRequestDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
