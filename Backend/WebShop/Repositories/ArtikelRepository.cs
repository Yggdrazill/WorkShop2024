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

		public List<ArtikelDTO> GetArtiklar()
		{
			var artiklar = _dbContext.Artiklar.Select(x => new ArtikelDTO
			{
				Id = x.Id,
				Namn = x.Namn,
				Pris = x.Pris,
				Borttagen = x.Borttagen
			}).ToList();

			return artiklar;
		}
	}
}
