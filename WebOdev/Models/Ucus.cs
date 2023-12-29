using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using System.Numerics;

namespace H12Auth2C.Models
{
    public class UcusKontrol
    {
        public int UcusId { get; set; }
        public string GidisNoktasi { get; set; }
        public string VarisNoktasi { get; set; }
        public DateTime KalkisTarihi { get; set; }
        public DateTime VarisTarihi { get; set; }
        public bool KontrolDurumu { get; set; }
    }

}