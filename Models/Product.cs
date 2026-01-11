namespace WebApplication43.Models
{
    public class Product:BaseModel
    {
        public int? CategoryId { get; set; }    
        public Category Category { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
    }
}
