using Infrastructure.Model;
using NLayer_Task.Model.Dtos.ProductDto;

namespace NLayer_Task.Model.Dtos.Categories
{
    public class CategoryGetDto : IDto
    {
        public int CategoryId { get; set; } 
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public string? PicturePath { get; set; }
        public List<ProductGetDto> Product { get; set; }
    }
}
