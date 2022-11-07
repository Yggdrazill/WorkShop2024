using Microsoft.AspNetCore.Mvc;
using WebShop.DataTransferObjects;

namespace WebShop.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ShoppingCartController : ControllerBase
	{
		private readonly ILogger<ShoppingCartController> _logger;

		public ShoppingCartController(ILogger<ShoppingCartController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public IEnumerable<OrderItemDTO> GetAll()
		{
			return null;
		}
	}
}