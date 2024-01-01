namespace Web12412412.Models
{
    public class Koltuk
    {
        public int Id { get; set; }
        public int KoltukNo { get; set; }
        public bool Dolumu { get; set; }

        public int UcakId { get; set; }
        public Ucak Ucak { get; set; }
    }
}
