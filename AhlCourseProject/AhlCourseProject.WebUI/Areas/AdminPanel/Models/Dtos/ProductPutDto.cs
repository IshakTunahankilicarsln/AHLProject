namespace AhlCourseProject.WebUI.Areas.AdminPanel.Models.Dtos
{
    public class ProductPutDto
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductMaterial { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public int? CategoryID { get; set; } 
    }
}
