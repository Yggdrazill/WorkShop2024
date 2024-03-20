using Database;
using Database.Entities;
using WebShop.DataTransferObjects;

namespace WebShop.Repositories
{
	public class ArtikelRepository
	{

		private Context _dbContext;

		public ArtikelRepository()
		{
			_dbContext = new Context();
		}


	}
}
