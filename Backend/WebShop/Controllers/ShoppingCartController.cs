using Microsoft.AspNetCore.Mvc;
using WebShop.DataTransferObjects;

namespace WebShop.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ShoppingCartController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<ShoppingCartController> _logger;

		public ShoppingCartController(ILogger<ShoppingCartController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public IEnumerable<ShoppingCart> GetAll()
		{
			return null;
		}
	}
}