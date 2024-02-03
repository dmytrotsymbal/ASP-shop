using System.Collections.Generic;
using System;


namespace WebApplication1.Data.Models
{
    // создали модель для категорий. Служит для отображения категорий
    // в себе имеет айди, название, категории, описание категории и сам список товаров
    // которые находятся в этой категории
    public class Category
    {
        public int id { set; get; }
        public string name { set; get; }
        public string description { set; get; }

        // каждый товар может иметь лишь одну категорию
        // но категория может иметь много товаров
        // укажем что у каждой категории есть большой список товаров 
        public List<Car> cars { set; get; }
    }
}
