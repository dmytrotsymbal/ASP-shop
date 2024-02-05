using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    // здесь будут различные функции которые будут возвращать такой тип данных как ViewResult
    // ViewResult - спец тип данных это результат в виде штмл страницы
    // тут будем выводить список автомобилей

    // тут нужно создать функцию которая будет возвращать ViewResult
    // в эту штмл страничку нам нужно передавать объект со всем товарами на сайте
    // что бы получить все товары на сайте - создадим контсруктор который будет
    // устанавливать данные по нашим интерфейсам 
    public class CarsController : Controller // - !!!!!!!!!!! название контроллера где слово Controller в ЮРЛ отбрасываеться !!!!!!!!!!!
	{
        // переменные на интерфейсы
        private readonly IAllCars _allCars;     // - две переменные в которые мы потом запишем данные 
        private readonly ICarsCategory _allCategories;

        // эти данные мы будем записывать через конструктор, создаем конструктор
        public CarsController(IAllCars IAllCars, ICarsCategory IAllCategories) // - передаем два параметра 
        {
            _allCars = IAllCars;
            _allCategories = IAllCategories; // - устанавливаем наши параметры в эти переменные 
        }

		// метод который будет возвращать ViewResult - полноценную ШТМЛ страничку
		// public ViewResult List() // - !!!!!!!!!!! название функции которую мы вызываем в контроллере и которая фигурирует в ЮРЛ !!!!!!!!!!!
		// {

		// ЕСТЬ второй способ передачи данных в ШТМЛ - ViewBag
		// ViewBag.Название_переменной = "Значение переменной";
		// ViewBag.Category = "Some new";
		// =================================================================================
		// var cars = _allCars.Cars; // - получаем все автомобили в перемунную cars с типом данных VAR
		// return View(cars);

		// теперь когда мы будем вызывать эту функцию мы
		// получим полноценную ШТМЛ страничку с товарами

		// var cars = _allCars.Cars - обращение к конкретному интерфейсу и
		// через переменную обращаемся к функции Cars -   IEnumerable<Car> Cars { get; }
		// }

		[Route("Cars/List")]
		[Route("Cars/List/{category}")]
		public ViewResult List(string category) // параметр для работы с категориями
        {
			string _category = category; // - присваиваем переменной значение
			IEnumerable<Car> cars = null; // - список автомобилей которые нужно отобразить
			string currCategory = ""; // - текущая категория

			if (string.IsNullOrEmpty(category)) // - если категория пустая
			{
				cars = _allCars.Cars.OrderBy(i => i.id); // - отсортируем автомобили по id - выведем все автомобили
														 // просто в порядке айдишек
			}
			else
			{
				if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase)) // - если строка(категория) = electro
				{
					cars = _allCars.Cars.Where(i => i.Category.name.Equals("Электромобили")).OrderBy(i => i.id);
					// выводим все автомобили у которых name категории = электромобили и отсортируем по айдишках
				} 
				else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
				{
					cars = _allCars.Cars.Where(i => i.Category.name.Equals("Классические")).OrderBy(i => i.id);
					// выводим все автомобили у которых name категории = Классические и отсортируем по айдишках
				} 
				else if (string.Equals("pickups", category, StringComparison.OrdinalIgnoreCase))
				{
					cars = _allCars.Cars.Where(i => i.Category.name.Equals("Пикапы")).OrderBy(i => i.id);
				}
				else 
				{
					cars = _allCars.Cars.Where(i => i.Category.name.Equals("Грузовики")).OrderBy(i => i.id);
				}

				currCategory = _category;
			}

			var carObj = new CarsListViewModel // - создаем новый объект на основе класса CarsListViewModel
			{
				allCars = cars,
				currCategory = currCategory
			};
			ViewBag.Title = "AUTOmibiles";

			return View(carObj);
		}
	}
}
