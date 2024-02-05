using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
	public class ShopCartController : Controller
	{
		private readonly IAllCars _carRep; // - переменная для работы с репозиторием
		private readonly ShopCart _shopCart; // - переменная для работы с корзиной

		
		public ShopCartController(IAllCars carRep, ShopCart shopCart) // - создадим конструктор с двумя параметрами
		{
			_carRep = carRep;   // - присваиваем значение переменной
			_shopCart = shopCart;
		}

		public ViewResult Index() // необходимо создать функцию которая будет возвращать ViewResult,
								  // с помощью нее будем вызывать поределенный ШТМЛ шаблон
		{
			var items = _shopCart.getShopItems(); // - создадим новый список в который получаем все данные из корзины
			_shopCart.listShopItems = items; // - поместим в него данные

			var obj = new ShopCartViewModel // - создадим новый объект на основе класса ShopCartViewModel
			{
				shopCart = _shopCart // - поместим в него данные
			};

			return View(obj); // - вернем этот объект 
		}

		public RedirectToActionResult addToCart(int id) // - создадим новую функцию которая будет переадресововать нас на другую страничку
		{
			var item = _carRep.Cars.FirstOrDefault(i => i.id == id); // - создадим переменную которая выберет нужный автомобиль из списка всех товаров
			if (item != null) // - проверка на наличие этого автомобиля
			{
				_shopCart.AddToCart(item); // - добавим автомобиль в корзину
			}
			return RedirectToAction("Index"); // - переадресуем на страничку карзины
											  // в скобочках указываем функцию которая будет возвращать ViewResult
		}
	}
}
