using Infrastructure.Model;

namespace NLayer_Task.Model.Entites
{
    public class Product : IEntity
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductMaterial { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public int? CategoryID { get; set; }
        public bool? IsActive { get; set; } = true;

        public Category? Category { get; set; }
        public List<ProductPicturePath>? ProductPicturePath { get; set; }

    }
}
