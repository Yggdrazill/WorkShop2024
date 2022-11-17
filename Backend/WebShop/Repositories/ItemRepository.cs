using Database;
using Database.Entities;
using WebShop.DataTransferObjects;

namespace WebShop.Repositories
{
	public class ItemRepository
	{

		private Context _dbContext;

		public ItemRepository()
		{
			_dbContext = new Context();
		}


	}
}
