using System.Collections.Generic;
using WebApplication1.Data.Models; // подключили модели категорий что бы их использовать

namespace WebApplication1.Data.Interfaces
{
    // создали интерфейс ICarsCategory для получения всех категорий в нашем проекте
    // пропишим всего одну функцию котора будет возвращать нам все категории из модели Категорий

    // в интерфейсах нельзя реализовать функции, по этому запишем скилет функции
    // а реализацию этой функции мы выполним в другом классе

    // нужно написать функцию которая будет возвращать нам список IEnumerable
    // и в качестве типа данных будет Category
    public interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
