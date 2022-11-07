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

		[HttpGet]
		[Route("order")]
		public List<OrderItemDTO> GetOrders()
		{
			return _orderService.GetOrders();
		}

		[HttpPost]
		[Route("order")]
		public void AddOrder(ItemData order)
		{
			_orderService.AddOrder(order);
		}

		[HttpPut]
		[Route("order/{id}")]
		public void UpdateOrder(int id, ItemData order)
		{
			_orderService.UpdateOrder(id, order);
		}

		[HttpDelete]
		[Route("order/{id}")]
		public void DeleteOrder(int id)
		{
			_orderService.DeleteOrder(id);
		}

		public class ItemData
		{
			public int ItemId { get; set; }
			public int Quantity { get; set; }
		}


	}
}