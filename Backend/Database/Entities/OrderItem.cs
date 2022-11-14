using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
	[Table("OrderItem")]
	public class OrderItem
	{
		public int Id { get; set; }
		public int ItemId { get; set; }
		public int Quantity { get; set; }

		public Item Item { get; set; }

	}
}
