using Database;
using Database.Entities;
using WebShop.DataTransferObjects;

namespace WebShop.Repositories
{
	public class OrderRepository
	{

		private Context _dbContext;

		public OrderRepository()
		{
			_dbContext = new Context();
		}

		public List<OrderItemDTO> GetOrders()
		{
			var orders = _dbContext.OrderItems.Select(x =>
				new OrderItemDTO
				{
					Id = x.Id,
					Quantity = x.Quantity,
					Item = new ItemDTO
					{
						Id = x.ItemId,
						Name = x.Item.Name,
						Cost = x.Item.Cost,
						Currency = x.Item.Currency,
						ImageId = x.Item.ImageId
					}
				}).ToList();

			return orders;
		}


		public ShoppingCartDTO GetShoppingCart()
		{
			var orders = GetOrders();

			var shoppingCart = new ShoppingCartDTO
			{
				TotalPrice = orders.Sum(x => x.Item.Cost * x.Quantity),
				CartItems = orders.Select(x => new CartItem
				{
					Name = x.Item.Name!,
					Quantity = x.Quantity
				}).ToList()

			};

			return shoppingCart;

		}

		public int AddOrder(OrderItemDTO order)
		{
			var entity = new OrderItem
			{
				ItemId = order.ItemId,
				Quantity = order.Quantity
			};

			_dbContext.OrderItems.Add(entity);
			_dbContext.SaveChanges();

			return entity.Id;
		}


		public void UpdateItem(int id, OrderItemDTO order)
		{
			var entity = _dbContext.OrderItems.First(x => x.Id == id);

			entity.Quantity = order.Quantity;
			_dbContext.SaveChanges();
		}


		public void DeleteItem(int id)
		{
			var entity = _dbContext.OrderItems.First(x => x.Id == id);
			_dbContext.OrderItems.Remove(entity);
			_dbContext.SaveChanges();
		}


	}
}
