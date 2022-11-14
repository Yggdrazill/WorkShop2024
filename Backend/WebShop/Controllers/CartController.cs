using Microsoft.AspNetCore.Mvc;
using WebShop.DataTransferObjects;
using WebShop.Services;

namespace WebShop.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CartController : ControllerBase
	{
		private OrderService _orderService;

		public CartController()
		{
			_orderService = new OrderService();
		}

		[HttpGet]
		[Route("")]
		public ShoppingCartDTO GetShoppingCart()
		{
			return _orderService.GetShoppingCart();
		}

		[HttpDelete]
		[Route("")]
		public void ClearCart()
		{
			_orderService.ClearShoppingCart();
		}


		public class ItemData
		{
			public int ItemId { get; set; }
			public int Quantity { get; set; }
		}


	}
}