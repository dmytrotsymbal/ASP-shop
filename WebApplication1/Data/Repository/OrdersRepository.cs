using System;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Repository
{
	public class OrdersRepository : IAllOrders
	{
		private readonly AppDBContent appDBContent;
		private readonly ShopCart shopCart;

		public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
		{
			this.appDBContent = appDBContent;
			this.shopCart = shopCart;
		}


		public void CreateOrder(Order order)
		{
			// Устанавливаем текущее время и дату
			order.orderTime = DateTime.Now;

			// Добавляем заказ в базу данных
			appDBContent.Order.Add(order);

			// Сохраняем изменения, чтобы получить сгенерированный id для заказа
			appDBContent.SaveChanges();

			// Создаем переменную для хранения списка товаров, которые покупает пользователь
			var items = shopCart.listShopItems;

			// Перебираем все элементы
			foreach (var el in items)
			{
				var orderDetail = new OrderDetail()
				{
					carId = el.car.id,
					orderId = order.id, // Теперь здесь будет правильный id, так как он был сгенерирован выше
					price = el.car.price
				};

				// Добавляем orderDetail в базу данных
				appDBContent.OrderDetail.Add(orderDetail);
			}

			// Сохраняем изменения в базе данных
			appDBContent.SaveChanges();
		}

	}
}
