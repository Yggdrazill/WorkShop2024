namespace Database.Entities
{
	public class Item
	{
		public int Id { get; set; }
		public double Cost { get; set; }
		public string? Currency { get; set; }
		public string? Name { get; set; }
		public int ImageId { get; set; }
	}
}
