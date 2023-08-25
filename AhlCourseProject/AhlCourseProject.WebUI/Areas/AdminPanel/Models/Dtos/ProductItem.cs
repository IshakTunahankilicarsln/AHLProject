using AhlCourseProject.WebUI.Areas.AdminPanel.Models.Dtos.Items;

namespace AhlCourseProject.WebUI.Areas.AdminPanel.Models.Dtos
{
    public class ProductItem
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductMaterial { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public int? CategoryID { get; set; } 
        public string? ProductDetails { get; set; }
        public string? CategoryName { get; set; }
        public bool? IsActive { get; set; }
        public List<ProductPicturePath>? ProductPicturePath { get; set; }
    }
}
