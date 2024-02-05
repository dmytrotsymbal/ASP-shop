namespace WebApplication1.Data.Models
{
	public class ShopCartItem
	{
		// ПОЛЯ для товара в корзине
		public int id { get; set; } // - > id в базе данных

		// сам обьект
		public Car car { get; set; }

		public int price { get; set; }

		public string ShopCartId { get; set; } // - > id товара в корзине
	}
}
