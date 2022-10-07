using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Model :Entity
    {
        public Model()
        {

        }
        public Model(int id ,int brandId, string name, decimal dailyPrice, string imageUrl):this()
        {
            BrandId = brandId;
            Name = name;
            DailyPrice = dailyPrice;
            ImageUrl = imageUrl;
            Id = id;
        }
        public int BrandId { get; set; }
        public string Name { get; set; }
        public decimal DailyPrice { get; set; }
        public string ImageUrl { get; set; }
        public virtual Brand? Brand { get; set; }
    }
}
