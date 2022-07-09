namespace Lesson28.EF.DataAccess.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Title { get; set; }

        public float Price { get; set; }

        public virtual Category Category { get; set; }
    }
}