namespace GeekShopping.ProductAPI.Data.DTO
{
	public class ProductDTO
	{

		public long id {  get; set; }

		public string name { get; set; }

		public decimal price { get; set; }

		public string description { get; set; }

		public string CategoryName { get; set; }

		public string ImageUrl { get; set; }	
	}
}
