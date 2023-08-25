using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Task.Model.Dtos.ProductDto
{
    public class ProductGetDto :IDto
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
        public List<ProductPicturePath.ProductPicturePathGetDto>? ProductPicturePath { get; set; }
    }
}
