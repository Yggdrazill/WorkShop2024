using WebShop.DataTransferObjects;
using WebShop.Repositories;
using static WebShop.Controllers.CartController;

namespace WebShop.Services
{
	public class OrderService
	{
		private readonly OrderRepository _orderRepository;

		public OrderService()
		{
			_orderRepository = new OrderRepository();
		}

		public List<OrderItemDTO> GetOrders()
		{
			return _orderRepository.GetOrders();
		}

		public ShoppingCartDTO GetShoppingCart()
		{
			return _orderRepository.GetShoppingCart();
		}

		public int AddOrder(ItemData order)
		{
			return _orderRepository.AddOrder(order);
		}


		public void UpdateOrder(int id, ItemData order)
		{
			_orderRepository.UpdateOrder(id, order);
		}

		public void DeleteOrder(int id)
		{
			_orderRepository.DeleteOrder(id);
		}

		public void ClearShoppingCart()
		{
			_orderRepository.ClearShoppingCart();
		}

	}
}
