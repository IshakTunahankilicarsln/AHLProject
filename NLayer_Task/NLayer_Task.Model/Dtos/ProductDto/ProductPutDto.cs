using Infrastructure.Model;

namespace NLayer_Task.Model.Dtos.ProductDto
{
    public class ProductPutDto : IDto
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductMaterial { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public int? CategoryID { get; set; }
    }
}
