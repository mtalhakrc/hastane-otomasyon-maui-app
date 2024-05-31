
using System.ComponentModel.DataAnnotations;

namespace hastane_otomasyon_maui_app.Models
{
    public class LoginModel
    {
        
        [Display(Name ="Email",Prompt ="example@mail.com")]
        [EmailAddress(ErrorMessage ="Mailinizi giriniz")]
        public string? Email { get; set; }
        
        
        [Display(Name ="Parola",Prompt ="Parolanızı giriniz")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Parola zorunludur")]
        [DataType(DataType.Password)]
        [MinLength(8,ErrorMessage ="Parola en az 8 karakter olabilir")]
        public string? Password { get; set; }
    }
}

