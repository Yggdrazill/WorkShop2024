using WebShop.DataTransferObjects;
using WebShop.Repositories;

namespace WebShop.Services
{
	public class ItemService
	{
		private readonly ItemRepository _itemRepository;

		public ItemService()
		{
			
		}

		public void CreateItem(Item Item)
		{
			_itemRepository.CreateItem(Item);
		}


		public void UpdateItem()
		{

		}


		public void DeleteItem()
		{

		}

	}
}
