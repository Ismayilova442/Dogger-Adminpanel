namespace WebApplication43.Models
{
    public class ProductImage:BaseModel
    {
        public string ImageUrl { get; set; }
        public int ProductId { get; set; }  
        public Product Product { get; set; }    
        
    }
}
