
namespace WebApplication1.Data.Models
{
    // модель для автомобиля, на основе этого класса будем создавать объекты которые будут товарами на сайте
    // 10 обектов - 10 автомобилей товаров
    // содержит описание и принадлежность к определенной категории 
    // каждая машина будет принадлижать определенной категории
    public class Car
    {
        public int id { get; set; }
        public string name { get; set; }
        public string shortDesc { get; set; }
        public string longDesc { get; set; }
        public string img { get; set; }
        public ushort price { get; set; }
        public bool isFavourite { get; set; }
        public bool available { get; set; }

        // присваиваеют каждый автомобиль к определенной категории
        public int categoryID { get; set; }

        // на основе этого - создаем обект со всеми значениями класса Categories
        public virtual Category Category { get; set; }

    }
}
