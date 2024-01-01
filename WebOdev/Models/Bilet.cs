using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web12412412.Models
{
    [Table("BiletTbl")]
    public class Bilet
    {
        [Key]
        public int BiletId { get; set; }

        [Required(ErrorMessage = "Kalkış yeri giriniz.")]
        [Display(Name = "Kalkış Yeri")]

        public string KalkisYeri { get; set; }

        [Required(ErrorMessage = "Varış yeri giriniz.")]
        [Display(Name = "Varış Yeri")]
        public string VarisYeri { get; set; }

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
        public string KalkisSaat { get; set; }
        public int UcakId { get; set; }

        public virtual Ucak Ucak { get; set; }

        [Required(ErrorMessage = "Koltuk numarası seciniz.")]
        [Display(Name = "Koltuk Numarası")]
        [Range(1, 100, ErrorMessage = "Koltuk numarası 1 ile 500 arasında olmalıdır.")]
        public int KoltukNumarasi { get; set; }
        public ICollection<Koltuk> Koltuklar { get; set; }
    }
}
