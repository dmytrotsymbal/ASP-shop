using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data.Models
{
	// модель для описания корзины
	public class ShopCart
	{

		private readonly AppDBContent appDBContent;

		public ShopCart(AppDBContent appDBContent)
		{
			this.appDBContent = appDBContent;
		}
		public string ShopCartId { get; set; }

		// список товаров в корзине
		public List<ShopCartItem> listShopItems { get; set; }

		// создаем функции

		
		public static ShopCart GetCart(IServiceProvider service) // - функция получения корзины, для понимания добавлял ли юзер товар в корзину
		{
			ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session; // создали объект при помощи которого сможем работать с сессиями
			var context = service.GetService<AppDBContent>(); // получили контекст, получаем таблички из базы данных
			string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString(); // получили или создали корзину

			session.SetString("CartId", shopCartId); // записали в сессию, в качестве ключа CartId - значение shopCartId

			return new ShopCart(context) { ShopCartId = shopCartId }; // возвращаем обект на основе ShopCart


			// 1) создали новую переменную shopCartId
			// 2) в нее устанавливаем значение из сессии
			// 3) но если значения нет - то мы создаем новый идентификатор корзины
			// 4) после того как мы взяди АЙДИ или Сгенерироровали новый АЙДИ - мы устанавливаем его в сессию
		}

		// функция для добавления товаров в корзину
		public void AddToCart(Car car)
		{
			this.appDBContent.ShopCartItem.Add(new ShopCartItem // добавляем новый элемент в таблицу
			{
				ShopCartId = ShopCartId,
				car = car,
				price = car.price,
			});

			appDBContent.SaveChanges(); // сохраняем изменения
		}

		// функция для отображения содержимого корзины
		public List<ShopCartItem> getShopItems() // - функция возвращает список товаров
		{
			return appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.car).ToList();

			// 1) возвращаем список товаров по условию
			// 2) все елементы у котором ShopCartId = ShopCartId
			// 3) выбераем лишь те елементы у которых айди корзины = айди карзины
			// которое у нас сейчас устновлино в сессии
			// 4) прописываем в Include(s => s.car) - чтобы получить елементы car
			// 5) поскольку вызвращаем список - должны привести к List
		}
	}
}
