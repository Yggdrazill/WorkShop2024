namespace WebShop.Controllers
{
	using global::WebShop.DataTransferObjects;
	using global::WebShop.Services;
	using Microsoft.AspNetCore.Mvc;

	namespace WebShop.Controllers
	{
		[ApiController]
		[Route("[controller]")]
		public class ItemController : ControllerBase
		{

			private ItemService _itemService;

			public ItemController()
			{
				_itemService = new ItemService();
			}


		}


	}


}
