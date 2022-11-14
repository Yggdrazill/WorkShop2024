using Microsoft.AspNetCore.Mvc;
using WebShop.DataTransferObjects;
using WebShop.Services;
using static WebShop.Controllers.CartController;

namespace WebShop.Controllers
{

	[ApiController]
	[Route("[controller]")]
	public class OrderController
	{

		private OrderService _orderService;

		public OrderController()
		{
			_orderService = new OrderService();
		}

		[HttpGet]
		[Route("")]
		public List<OrderItemDTO> GetOrders()
		{
			return _orderService.GetOrders();
		}

		[HttpPost]
		[Route("")]
		public void AddOrder(ItemData order)
		{
			_orderService.AddOrder(order);
		}

		[HttpPut]
		[Route("{id}")]
		public void UpdateOrder(int id, ItemData order)
		{
			_orderService.UpdateOrder(id, order);
		}

		[HttpDelete]
		[Route("{id}")]
		public void DeleteOrder(int id)
		{
			_orderService.DeleteOrder(id);
		}
	}
}
