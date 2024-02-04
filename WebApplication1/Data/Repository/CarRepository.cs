using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Repository
{
	// класс для получения данных из базы данных
	public class CarRepository : IAllCars // - наследуют все из своих инетерфейсов.
										  // Раньше интерфейсы реализововались в Моксах, а теперь тут
	{
		private readonly AppDBContent appDBContent; // - новая переменная для работы с файликом dbsettings.json

		public CarRepository(AppDBContent appDBContent) // - конструктор для установки значения в переменную appDBContent
		{
			this.appDBContent = appDBContent;
		}

		// функции для получения данных, получают данные из файлика dbsettings.json

		// обращаемся к обекту appDBContent, дальше к функции Cars и через Include берем переменную с
		// записываем все данные которые подходят по Category
		public IEnumerable<Car> Cars => appDBContent.Cars.Include(c => c.Category);

		// то же самое только добавляем условие на isFavourite, реализуем его через метод Where 
		// условие p => p.isFavourite - если p.isFavourite = true, то возвращаем
		public IEnumerable<Car> GetFavCars => appDBContent.Cars.Where(p => p.isFavourite).Include(c => c.Category);

		// метод для получения объекта по ID, реализуем его через метод FirstOrDefault
		// условие p => p.id == carId - ЕСЛИ p.id = carId, то возвращаем
		public Car getObjectCar(int carId) => appDBContent.Cars.FirstOrDefault(p => p.id == carId);
	}
}
