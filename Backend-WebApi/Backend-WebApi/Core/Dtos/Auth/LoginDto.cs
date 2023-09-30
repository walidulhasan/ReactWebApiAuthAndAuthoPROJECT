using System.ComponentModel.DataAnnotations;

namespace Backend_WebApi.Core.Dtos.Auth;

public class LoginDto
{
    [Required(ErrorMessage ="User Name is reauired")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "Password is reauired")]
    public string Password { get; set; }
}
