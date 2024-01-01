using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web12412412.Models
{
    [Table("KullaniciTbl")]
    public class Kullanici

    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Lütfen adınızı giriniz.")]
        [Display(Name = "Adınız")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lütfen soyadınızı giriniz.")]
        [Display(Name = "Soyadınız")]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "E-mail adresiniz")]
        [Required(ErrorMessage = "Lütfen e-mail adresinizi giriniz.")]
        [DataType(DataType.EmailAddress)] // E-mail adresi formatında olmalı
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Şifre Onay")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreleriniz uyuşmuyor.")]
        public string CPassword { get; set; }

        [Required(ErrorMessage = "Lütfen telefon numaranızı giriniz.")]
        [Display(Name = "Telefon Numaranız")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lütfen Yaşınızı Giriniz")]
        [Display(Name = "Yaşınız")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Lütfen Kimlik Numaranızı"), RegularExpression(@"^([0-9]{11})$", ErrorMessage = "Geçersiz Kimlik No")] // Kimlik numarası formatında olmalı
        [Display(Name = "Kimlik Numaranız")]
        [StringLength(11, ErrorMessage = "Kimlik Numaranız 11 haneli olmalıdır.")]
        public string IdentityNumber { get; set; } = string.Empty;
    }
}
