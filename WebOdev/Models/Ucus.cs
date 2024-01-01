using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web12412412.Models
{
    [Table("Ucuslar")]
    public class Ucus
    {
        [Key]
        public int UcusId { get; set; }

        [Required(ErrorMessage = "Lütfen nereden uçacağınızı giriniz.")]
        [Display(Name = "Nereden")]
        public String Nereden { get; set; }

        [Required(ErrorMessage = "Lütfen nereye uçacağınızı giriniz.")]
        [Display(Name = "Nereye")]
        public String Nereye { get; set; }

        [Required(ErrorMessage = "Gidiş tarihi giriniz.")]
        [Display(Name = "Gidiş Tarihi")]
        [DataType(DataType.Date)]
        public DateTime GidisTarihi { get; set; }

        [Required(ErrorMessage = "Dönüş tarihi giriniz.")]
        [Display(Name = "Dönüş Tarihi")]
        [DataType(DataType.Date)]
        public DateTime DonusTarihi { get; set; }

        [Required(ErrorMessage = "Kalkış saati giriniz.")]
        [Display(Name = "Kalkış Saati")]
        [DataType(DataType.Time)]

        public String KalkisSaat { get; set; }

        [Required(ErrorMessage = "Varış saati giriniz.")]
        [Display(Name = "Varış Saati")]
        [DataType(DataType.Time)]

        public String VarisSaat { get; set; }

        public int doluKoltukSayisi { get; set; } = 0;
        public int UcakId { get; set; }
        public Ucak Ucak { get; set; }
        public Koltuk koltuk { get; set; }
        public int SehirId { get; set; }
        public Sehir Sehir { get; set; }
    }
}
