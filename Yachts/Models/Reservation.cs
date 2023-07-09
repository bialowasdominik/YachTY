namespace Yachts.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int YachtId { get; set; }
        public int CustomerId { get; set; }
        public virtual Yacht Yacht { get; set; }
        public virtual Customer Customer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
