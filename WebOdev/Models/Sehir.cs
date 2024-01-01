using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Web12412412.Models
{
    public class Sehir
    {
        [Key]
        public int SehirId { get; set; }

        [Display(Name = "Şehir Adı")]
        public string SehirAdi { get; set; }
        public ICollection<Bilet> Biletler { get; set; }

        public ICollection<Ucus> Ucus { get; set; }

    }
}
