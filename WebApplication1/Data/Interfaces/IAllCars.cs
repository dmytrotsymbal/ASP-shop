using System.Collections.Generic;
using WebApplication1.Data.Models; // подключаем для использования модели Кар

namespace WebApplication1.Data.Interfaces
{
    // интерфейс для получения всех машин
    // тут будут функции которая возвращает все товары
    // функция которая возвращает лишь избранные товары - которые фейворит
    // функция которая будет возвращать отвар по его айди
    public interface IAllCars
    {
        // две первые функции будут возвращать список всех машин и список избранных машин
        IEnumerable<Car> Cars { get; }
        IEnumerable<Car> GetFavCars { get; }

        // последняя не будет возвращать список по этому не нужно использовать перечисление IEnumerable
        // функция возвращает обект на основе класса Car и эта функция будет принимать айди машины
        Car getObjectCar(int carId);
    }
}
