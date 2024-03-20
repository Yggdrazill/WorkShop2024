using Database.Entities;
using WebShop.DataTransferObjects;
using WebShop.Repositories;

namespace WebShop.Services
{
	public class ItemService
	{
		private readonly ArtikelRepository _itemRepository;

		public ItemService()
		{
			_itemRepository = new ArtikelRepository();
		}

	}
}
