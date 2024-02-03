using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.mocks
{
    // создали второй мок который будет реализововать интерфейс IAllCars.
    // В интерфейсе IAllCars есть 3 функции которые тут реализовуються
    public class MockCar : IAllCars
    {
        // переменная для присвоения машины к определенной категории   
        private readonly ICarsCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> Cars
        {
            get
           {
                return new List<Car>
                {
                    new Car
                    {
                        id = 1,
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
                        Category = _categoryCars.AllCategories.First()
                    },
                    new Car
                    {
                        id = 2,
                        name = "Toyota",
                        shortDesc = "Надежный и экономичный",
                        longDesc = "Просторный и комфортный",
                        img = "/images/2.jpg",
                        price = 25000,
                        isFavourite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.ElementAt(1)
                    },
                    new Car
                    {
                        id = 3,
                        name = "Ford Pickup",
                        shortDesc = "Мощный и вместительный",
                        longDesc = "Идеальный для работы",
						img = "/images/3.jpg",
						price = 35000,
                        isFavourite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.ElementAt(2)
                    },
                    new Car
                    {
                        id = 4,
                        name = "Volvo Truck",
                        shortDesc = "Надежный грузовик",
                        longDesc = "С большой грузоподъемностью",
						img = "/images/4.jpg",
						price = 55000,
                        isFavourite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car
                    {
                        id = 5,
                        name = "Nissan Leaf",
                        shortDesc = "Экологичный и экономичный",
                        longDesc = "Идеальный для города",
						 img = "/images/5.jpg",
						price = 30000,
                        isFavourite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.First()
                    },
                    new Car
                    {
                        id = 6,
                        name = "Mercedes S-class",
                        shortDesc = "Дорогой и стильный",
                        longDesc = "Дамочки от такого в шоке",
                        img = "/images/6.jpg",
                        price = 30000,
                        isFavourite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.ElementAt(2)
                    }
				};
            }
        }

        // для начала сделаем что бы GetFavCars возвращала нам просто get; set;
        // потому что сейчас они выбрасывают новые ошибки
        public IEnumerable<Car> GetFavCars { get; set; }

        public Car getObjectCar(int carId)
        {
            throw new System.NotImplementedException();
        }
    }
}
