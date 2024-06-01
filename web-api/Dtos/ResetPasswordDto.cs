using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace web_api.Dtos;

public class ResetPasswordDto
{
    public string Email { get; set; }
    public string OldPassword{ get; set; }
    
    public string Password{ get; set; }
    
}