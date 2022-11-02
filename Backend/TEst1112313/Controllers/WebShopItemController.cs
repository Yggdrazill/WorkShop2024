namespace WebShop.Controllers
{
	using global::WebShop.DataTransferObjects;
	using Microsoft.AspNetCore.Mvc;

	namespace WebShop.Controllers
	{

		[ApiController]
		[Route("[controller]")]
		public class ItemController : ControllerBase
		{

			private List<Item> _WebShopItems = new()
			{
				new Item
				{
					Id = 1, Name = "Age of Empires IV", Currency = "kr", Cost = 600, ImageId = 1
				},
				new Item
				{
					Id = 2, Name = "Stiga AXE Padel Racket", Currency = "kr", Cost = 2300, ImageId = 2
				},
				new Item
				{
					Id = 3, Name = "Bitcoin", Currency = "kr", Cost = 50000, ImageId = 3
				},
				new Item
				{
					Id = 4, Name = "GeForce RTX 3090", Currency = "kr", Cost = 20000, ImageId = 4
				},
				new Item
				{
					Id = 5, Name = "Revell RC", Currency = "Euro", Cost = 500, ImageId = 5
				},
				new Item
				{
					Id = 6, Name = "Age of Empires IV", Currency = "kr", Cost = 123, ImageId = 1
				},
				new Item
				{
					Id = 7, Name = "Inte bitcoin", Currency = "kr", Cost = 700, ImageId = 3
				}

			};

			[HttpGet]
			[Route("")]
			public IList<Item> GetAll()
			{
				return _WebShopItems;
			}


			[HttpPost]
			[Route("")]
			public void CreateItem(Item Item)
			{
				_WebShopItems.Add(Item);
			}

			[HttpPut]
			[Route("{id}")]
			public void UpdateItem(int id, [FromBody] int cost)
			{
				_WebShopItems.First(x => x.Id == id).Cost = cost;
			}


			[HttpDelete]
			[Route("{id}")]
			public void DeleteItem(int id)
			{
				var WebShopItemToREmove = _WebShopItems.Find(x => x.Id == id);
				_WebShopItems.Remove(WebShopItemToREmove);
			}

		}


	}


}
