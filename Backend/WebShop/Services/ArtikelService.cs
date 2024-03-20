using Database.Entities;
using WebShop.DataTransferObjects;
using WebShop.Repositories;

namespace WebShop.Services
{
	public class ArtikelService
	{
		private readonly ArtikelRepository _artikelRepository;

		public ArtikelService()
		{
			_artikelRepository = new ArtikelRepository();
		}

	}
}
