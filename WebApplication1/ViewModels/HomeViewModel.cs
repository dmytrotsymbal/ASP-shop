using System.Collections.Generic;
using WebApplication1.Data.Models;

namespace WebApplication1.ViewModels
{
	public class HomeViewModel
	{
		public IEnumerable<Car> favCars { get; set; }
	}
}
