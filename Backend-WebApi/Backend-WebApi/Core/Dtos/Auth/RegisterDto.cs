using System.ComponentModel.DataAnnotations;

namespace Backend_WebApi.Core.Dtos.Auth;

public class RegisterDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Required(ErrorMessage = "UserName is reauired")]
    public string UserName { get; set; }
    public string Email { get; set; }
    [Required(ErrorMessage = "Password is reauired")]
    public string Password { get; set; }
    public string Address { get; set; }

}

