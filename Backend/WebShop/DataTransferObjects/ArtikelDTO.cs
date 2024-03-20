namespace WebShop.DataTransferObjects
{
	public class ArtikelDTO
	{
		public int Id { get; set; }
		public string? Namn { get; set; }
		public decimal Pris { get; set; }
		public bool Borttagen { get; set; }
	}
}
