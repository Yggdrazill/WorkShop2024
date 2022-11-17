using Database.Entities;
using WebShop.DataTransferObjects;
using WebShop.Repositories;

namespace WebShop.Services
{
	public class ItemService
	{
		private readonly ItemRepository _itemRepository;

		public ItemService()
		{
			_itemRepository = new ItemRepository();
		}

	}
}
