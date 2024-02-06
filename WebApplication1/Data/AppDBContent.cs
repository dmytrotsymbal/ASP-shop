using Microsoft.EntityFrameworkCore; // !!!
using WebApplication1.Data.Models;

// внутри этого файла мы регестрируем какие таблички у нас будут в самой базе данных
namespace WebApplication1.Data
{
	public class AppDBContent : DbContext // всегда наследует DbContext
	{
		// создаем конструктор по умолчанию                           передаем данные в базовый конструктор
		public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
		{
		}

		// два екземпляра функций
		// 1) - функция получения и установки всех товаров в магазине
		public DbSet<Car> Cars { get; set; } // DbSet - специалный класс, который принимает Модель

		// 2) - функция получения и установки всех категорий
		public DbSet<Category> Categories { get; set; }


		// 3) - функция получения и установки всех покупок, корзины
		public DbSet<ShopCartItem> ShopCartItem { get; set; }


		// 4) - функция получения и установки всех заказов
		public DbSet<Order> Order { get; set; }
		public DbSet<OrderDetail> OrderDetail { get; set; }
	}
}
