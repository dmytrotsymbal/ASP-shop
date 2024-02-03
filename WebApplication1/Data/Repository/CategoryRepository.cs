using System.Collections.Generic;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Repository
{
	public class CategoryRepository : ICarsCategory // - наследуем другой интерфейс
	{
		private readonly AppDBContent appDBContent;

		public CategoryRepository(AppDBContent appDBContent)
		{
			this.appDBContent = appDBContent;
		}

		// всего одна функция
		// функция для вывода всех категорий
		public IEnumerable<Category> AllCategories => appDBContent.Categories; 
	}
}
