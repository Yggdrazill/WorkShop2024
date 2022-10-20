using Microsoft.AspNetCore.Mvc;

namespace StudentWorkshop.Controllers
{

	[ApiController]
	[Route("[controller]")]
	public class ItemController : ControllerBase
	{

		private List<Item> _items = new()
		{
			new Item
			{
				Id = 1, Name = "Age of Empires IV", Currency = "kr", Price = 600
			},
			new Item
			{
				Id = 2, Name = "Stiga AXE Padel Racket", Currency = "kr", Price = 2300
			},
			new Item
			{
				Id = 3, Name = "Bitcoin", Currency = "kr", Price = 50000
			},
			new Item
			{
				Id = 4, Name = "GeForce RTX 3090", Currency = "kr", Price = 20000
			},
			new Item
			{
				Id = 5, Name = "Revell RC", Currency = "Euro", Price = 50
			},

		};

		[AcceptVerbs("GET")]
		[Route("")]
		public IList<Item> GetAll()
		{
			return _items;
		}

	}


	public class Item
	{
		public int Id { get; set; }
		public int Price { get; set; }
		public string Currency { get; set; }
		public string Name { get; set; }
	}
}
