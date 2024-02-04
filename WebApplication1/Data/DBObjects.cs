using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data.Models;

namespace WebApplication1.Data
{
	// класс для добавление объектов в базу данных
	public class DBObjects
	{
		public static void Initial(AppDBContent content)
		{				
			if (!content.Categories.Any()) // если нет категорий - будем добавлять категории
			{
				content.Categories.AddRange(Categories.Select(c => c.Value)); // - вызываем функцию Categories которая внизу
			}

			if (!content.Cars.Any()) // если нет машин - будем добавлять машины
			{
				// добавляем машины, берем из мок карс
				// поменяем категории машин

				// и айдишники машины не заполняем
				content.AddRange(
					 new Car
					 {
						 //id = 1,
						 name = "Tesla Pl",
						 shortDesc = "Быстрый и стильный",
						 longDesc = "Красивый и удобный",
						 img = "/images/1.jpg",
						 price = 45000,
						 isFavourite = true,
						 available = true,
						 // для того что бы добавить машину к какой то категории
						 // нужно за пределами функции создать переменную

						 // для этого нужно использовать _categoryCars, через нее
						 // обращаемся к AllCategories и обращаемся к первому обекту
						 Category = Categories["Электромобили"]
					 },
					new Car
					{
						//id = 2,
						name = "Toyota",
						shortDesc = "Надежный и экономичный",
						longDesc = "Просторный и комфортный",
						img = "/images/2.jpg",
						price = 25000,
						isFavourite = true,
						available = true,
						Category = Categories["Классические"]
					},
					new Car
					{
						//id = 3,
						name = "Ford Pickup",
						shortDesc = "Мощный и вместительный",
						longDesc = "Идеальный для работы",
						img = "/images/3.jpg",
						price = 35000,
						isFavourite = true,
						available = true,
						Category = Categories["Пикапы"]
					},
					new Car
					{
						//id = 4,
						name = "Volvo Truck",
						shortDesc = "Надежный грузовик",
						longDesc = "С большой грузоподъемностью",
						img = "/images/4.jpg",
						price = 55000,
						isFavourite = true,
						available = true,
						Category = Categories["Грузовики"]
					},
					new Car
					{
						//id = 5,
						name = "Nissan Leaf",
						shortDesc = "Экологичный и экономичный",
						longDesc = "Идеальный для города",
						img = "/images/5.jpg",
						price = 30000,
						isFavourite = true,
						available = true,
						Category = Categories["Электромобили"]
					},
					new Car
					{
						//id = 6,
						name = "Mercedes S-class",
						shortDesc = "Дорогой и стильный",
						longDesc = "Дамочки от такого в шоке",
						img = "/images/6.jpg",
						price = 30000,
						isFavourite = true,
						available = true,
						Category = Categories["Классические"]
					}
				);
			}

			content.SaveChanges(); // очень важная строка для сохранения изменений в базе данных
		}

		//=======================================================================================

		// переменная для проверки на существование
		private static Dictionary<string, Category> category;

		// функция которая будет возвращать список категорий 
		public static Dictionary<string, Category> Categories
		{
			get
			{
				// проверка, если переменная пуста - добавляем новые объекты
				if (category == null)
				{
					// создаем список через var
					var list = new Category[]
					{
						 new Category { name = "Электромобили", description = "Електрические автомобили без двигателя внутреннего сгорания"},
						 new Category { name = "Классические", description = "Автомобили с двигателем внутреннего сгорания"},
						 new Category { name = "Пикапы", description = "Огромные и очень проходимые" },
						 new Category { name = "Грузовики", description = "Автомобили с грузовыми помещениями" }
					};

					// выделяем память и внутрь переменной category добавляем новые объекты через цикл
					category = new Dictionary<string, Category>();
					foreach (var el in list)
					{
						category.Add(el.name, el);
					}
				}

				// возвращем заполненную переменную category, уже с категориями
				return category;
			}
		}  
	}
}
