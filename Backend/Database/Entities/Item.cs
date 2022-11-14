using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
	[Table("Item")]
	public class Item
	{
		public int Id { get; set; }
		public double Cost { get; set; }
		public string? Name { get; set; }
		public int ImageId { get; set; }
	}
}
