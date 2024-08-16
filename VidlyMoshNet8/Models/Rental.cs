namespace VidlyMoshNet8.Models
{
	public class Rental
	{
		public int Id { get; set; }
		public Customers Customer { get; set; }
		public Movie Movie { get; set; }
		public DateTime DateRented { get; set; }
		public DateTime? DateReturned { get; set; }
	}
}
