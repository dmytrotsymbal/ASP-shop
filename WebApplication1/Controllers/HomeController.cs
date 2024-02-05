using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
	public class HomeController : Controller
	{
		private readonly IAllCars _carRep; // - переменная для работы с репозиторием
		private readonly ShopCart _shopCart; // - переменная для работы с корзиной


		public HomeController(IAllCars carRep, ShopCart shopCart) // - создадим конструктор с двумя параметрами
		{
			_carRep = carRep;   // - присваиваем значение переменной
			_shopCart = shopCart;
		}

		public ViewResult Index() // - создадим функцию которая будет возвращать ViewResult
		{
			var homeCars = new HomeViewModel // - создадим новый объект на основе класса HomeViewModel
			{
				favCars = _carRep.GetFavCars  // выведем все машини у которых фейворит = тру
			};
			return View(homeCars); // - вернем этот объект
		} 
	}
}
