using NLayer_Task.Model.Dtos.ProductDto;

namespace NLayer_Task.Model.Dtos.SpesificDto
{
    public class ProductAndPıcturePostDto
    {
        public ProductPostDto? Productpostdto { get; set; }
        public List<string>? PictureImages { get; set; }
    }
}
