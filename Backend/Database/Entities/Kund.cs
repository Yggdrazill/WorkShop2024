using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
	[Table("Kund")]
	public class Kund
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Mejl { get; set; }
		public string Adress { get; set; }

	}
}
