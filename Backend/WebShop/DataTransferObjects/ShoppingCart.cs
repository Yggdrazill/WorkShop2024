namespace WebShop.DataTransferObjects
{
	public class ShoppingCartDTO
	{
		public double TotalPrice { get; set; }
		public List<CartItem> CartItems { get; set; }
	}

	public class CartItem
	{
		public string Name { get; set; }
		public int Quantity { get; set; }
	}
}
