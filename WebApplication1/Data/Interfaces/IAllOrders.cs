using WebApplication1.Data.Models;

namespace WebApplication1.Data.Interfaces
{

	public interface IAllOrders
	{
		// будет всего одна функция которая будет создавать заказ
		void CreateOrder(Order order);
	}
}
