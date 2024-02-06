using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Models;
using WebApplication1.Data;
using WebApplication1.Data.Interfaces;

namespace WebApplication1.Controllers
{
	public class OrderController : Controller
	{
		private readonly IAllOrders allOrders; // переменная интерфейса IAllOrders
		private readonly ShopCart shopCart;

		public OrderController(IAllOrders allOrders, ShopCart shopCart)
		{
			this.allOrders = allOrders;
			this.shopCart = shopCart;
		}


		// создадим функцию которая будет возвращать IActionResult -
		// это специальный тип данных который возвращает View но при этом над шаблоном
		// будут какие то действия - заполнения полей ввода

		public IActionResult Checkout() // - создадим функцию которая будет возвращать IActionResult
		{
			return View();
		}

		
		[HttpPost] // - создадим функцию которая будет срабатывать только при HttpPost
		public IActionResult Checkout(Order order) // - принимаем параметр с заказа
		{
			shopCart.listShopItems = shopCart.getShopItems(); // - берем переменную shopCart и у нее берем все товары и
															  // внутрь них записываем все товары

			if (shopCart.listShopItems.Count == 0) // - если список пуст
			{
				ModelState.AddModelError("", "Нечего оформлять"); // - то выведем сообщение об ошибке
			}

			if (ModelState.IsValid) // - если модель валидна, все инпуты прошли проверку
			{
				allOrders.CreateOrder(order); // - создадим новый заказ
				return RedirectToAction("Complete"); // - переадресуем на страницу завершения,
													 // будем отправлять юзера на кастомную страницу
			} 
			return View();
		}


		public IActionResult Complete()
		{
			ViewBag.Message = "Заказ успешно оформлен!";
			return View();
		}
	}
}
