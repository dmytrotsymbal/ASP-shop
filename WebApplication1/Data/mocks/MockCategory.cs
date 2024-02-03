using System.Collections.Generic;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;


namespace WebApplication1.Data.mocks
{
    // данный класс будет реализовать интерфейс ICarsCategory по этому он наследует его.
    // Должны его импортировать что бы использовать.
    // Он до сих пор может светить ошибку потому что это интерфейс в котормо есть функции
    // и они все должны быть реализованы. 
    public class MockCategory : ICarsCategory
    {
        // авто-реализация функции которая была в интерфейсе ICarsCategory
        // public IEnumerable<Category> AllCategories => throw new System.NotImplementedException();

        // нам нужно ее поменять на следующую : 

        // 1) - реализовали интерфейс в котором была всего одна функция
        // которая возвращала список всех категорий IEnumerable<Category>

        public IEnumerable<Category> AllCategories
        {
            // 2) - и указали какие именно категории будут возвращаться
            get
            {
                return new List<Category>
                {
                   // 3) - создали обекты на основе класса Category и заполнили их данными

                   new Category { name = "Электромобили", description = "Електрические автомобили без двигателя внутреннего сгорания"},
                   new Category { name = "Классические", description = "Автомобили с двигателем внутреннего сгорания"},
                   new Category { name = "Пикапы", description = "Огромные и очень проходимые" },
                   new Category { name = "Грузовики", description = "Автомобили с грузовыми помещениями" }
                };
            }
        }
    }
}
