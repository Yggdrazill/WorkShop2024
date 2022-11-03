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


			[HttpGet]
			[Route("")]
			public IList<ItemDTO> GetAll()
			{
				return _itemService.GetItems();
			}


			[HttpPost]
			[Route("")]
			public void CreateItem(ItemDTO Item)
			{
				_itemService.CreateItem(Item);
			}

			[HttpPut]
			[Route("{id}")]
			public void UpdateItem(int id, [FromBody] ItemDTO item)
			{
				_itemService.UpdateItem(id, item);
			}


			[HttpDelete]
			[Route("{id}")]
			public void DeleteItem(int id)
			{
				_itemService.DeleteItem(id);
			}

		}


	}


}
