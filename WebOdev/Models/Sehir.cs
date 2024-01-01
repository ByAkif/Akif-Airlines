using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Web12412412.Models
{
    public class Sehir
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Şehir Adı")]
        public string SehirAdi { get; set; }

        public Ucus Ucus { get; set; } 

    }
}
