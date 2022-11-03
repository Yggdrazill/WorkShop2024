using Database.Entities;

namespace WebShop.DataTransferObjects
{
	public class OrderItemDTO
	{
		public int Id { get; set; }
		public int ItemId { get; set; }
		public int Quantity { get; set; }

		public ItemDTO Item { get; set; }
	}
}
