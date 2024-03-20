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


		public List<ArtikelDTO> GetArtiklar()
		{
			return _artikelRepository.GetArtiklar();
		}
	}
}
