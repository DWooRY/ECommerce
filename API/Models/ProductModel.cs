namespace API.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string PictureName { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public bool Active { get; set; }
    }
}