using System.ComponentModel.DataAnnotations;

namespace WebOdev.Models
{
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
        public string GidisTarihi { get; set; }

        [Required(ErrorMessage = "Dönüş tarihi giriniz.")]
        [Display(Name = "Dönüş Tarihi")]
        [DataType(DataType.Date)]
        public string DonusTarihi { get; set; }

        [Required(ErrorMessage = "Kalkış saati giriniz.")]
        [Display(Name = "Kalkış Saati")]
        public string KalkisSaat { get; set; }

        public int UcakId { get; set; }

        public virtual Ucak Ucak { get; set; }

        [Required(ErrorMessage = "Koltuk numarası seciniz.")]
        [Display(Name = "Koltuk Numarası")]
        public int koltukNo { get; set; }


    }
}
