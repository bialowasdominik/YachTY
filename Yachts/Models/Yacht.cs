namespace Yachts.Models
{
    public class Yacht
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Decimal PricePerDay { get; set; }
        public string PhotoUrl { get; set; }
        public string Description { get; set; }
        public virtual List<Reservation> Reservations { get; set; }
    }
}
