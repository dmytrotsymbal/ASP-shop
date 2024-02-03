using System.Collections;
using System.Collections.Generic;
using WebApplication1.Data.Models;

namespace WebApplication1.ViewModels
{
	public class CarsListViewModel
	{
		// функция которая будет получать все товары, по этому тип IEnumerable 
		public IEnumerable<Car> allCars { get; set; }

		// переменная для категории с которой мы сейчас работаем
		public string currCategory { get; set; }
	}
}
