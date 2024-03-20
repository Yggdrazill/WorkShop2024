namespace WebShop.Controllers
{
	using global::WebShop.DataTransferObjects;
	using global::WebShop.Services;
	using Microsoft.AspNetCore.Mvc;

	namespace WebShop.Controllers
	{
		[ApiController]
		[Route("[controller]")]
		public class ArtikelController : ControllerBase
		{

			private ArtikelService _artikelService;

			public ArtikelController()
			{
				_artikelService = new ArtikelService();
			}


			[HttpGet]
			[Route("")]
			public IList<ArtikelDTO> GetArtiklar()
			{
				return _artikelService.GetArtiklar();
			}


		}
	}
}
