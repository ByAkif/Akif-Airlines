using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebOdev.Models
{
    public class Koltuk
    {
        [Key]
        public int Id { get; set; }
        public int KoltukNo { get; set; }
        public bool DoluMu { get; set; }

        [ForeignKey("Ucak")]
        public int UcakId { get; set; }
        public Ucak Ucak { get; set; }
    }
}
