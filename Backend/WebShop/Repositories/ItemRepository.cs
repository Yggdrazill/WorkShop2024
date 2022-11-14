using Database;
using Database.Entities;
using WebShop.DataTransferObjects;

namespace WebShop.Repositories
{
	public class ItemRepository
	{

		private Context _dbContext;

		public ItemRepository()
		{
			_dbContext = new Context();
		}

		public List<ItemDTO> GetItems()
		{
			var items = _dbContext.Items.Select(x => new ItemDTO
			{
				Id = x.Id,
				Cost = x.Cost,
				Name = x.Name,
				ImageId = x.ImageId
			}).ToList();

			return items;
		}

		public ItemDTO GetItem(int id)
		{
			var entity = _dbContext.Items.First(x => x.Id == id);
			return new ItemDTO
			{
				Id = entity.Id,
				Cost = entity.Cost,
				Name = entity.Name,
				ImageId = entity.ImageId
			};
		}
		public void CreateItem(ItemDTO dto)
		{
			var entity = new Item
			{
				Id = dto.Id,
				Name = dto.Name,
				Cost = dto.Cost,
				ImageId = dto.ImageId,
			};

			_dbContext.Items.Add(entity);
			_dbContext.SaveChanges();
		}


		public void UpdateItem(int id, ItemDTO dto)
		{
			var entity = _dbContext.Items.FirstOrDefault(x => x.Id == id);

			if (entity == null)
			{
				throw new Exception($"No item exists with id: {id}");
			}


			entity.Name = dto.Name;
			entity.Cost = dto.Cost;
			entity.ImageId = dto.ImageId;

			_dbContext.SaveChanges();
		}


		public void DeleteItem(int id)
		{
			var entity = _dbContext.Items.FirstOrDefault(x => x.Id == id);
			_dbContext.Remove(entity);
			_dbContext.SaveChanges();
		}




	}
}
