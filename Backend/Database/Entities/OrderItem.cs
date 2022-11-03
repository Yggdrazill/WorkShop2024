namespace Database.Entities
{
	public class OrderItem
	{
		public int Id { get; set; }
		public int ItemId { get; set; }
		public int Quantity { get; set; }

		public Item Item { get; set; }

	}
}
