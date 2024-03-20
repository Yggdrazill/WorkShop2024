using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
	[Table("Artikel")]
	public class Artikel
	{
		public int Id { get; set; }
		public string? Namn { get; set; }

		public decimal Pris { get; set; }
		public bool Borttagen { get; set; }
	}
}
