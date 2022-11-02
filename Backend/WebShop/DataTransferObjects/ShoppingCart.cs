namespace WebShop.DataTransferObjects
{
	public class ShoppingCart
	{
		public int TotalPrice { get; set; }
		public List<Item> Items { get; set; }
	}
}
