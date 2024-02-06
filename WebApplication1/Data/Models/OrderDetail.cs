namespace WebApplication1.Data.Models
{
	public class OrderDetail
	{
		public int id { get; set; }

		public int orderId { get; set; } 

		public int carId { get; set; } 

		public uint price { get; set; } // total price

		public virtual Car car { get; set; } // объект товара

		public virtual Order order { get; set; } // объект заказа
	}
}
