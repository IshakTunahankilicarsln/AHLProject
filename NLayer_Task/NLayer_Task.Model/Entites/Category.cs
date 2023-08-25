using Infrastructure.Model;
using NLayer_Task.Model.Dtos.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Task.Model.Entites
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public string? PicturePath { get; set; }
        public bool? IsActive { get; set; } = true;
        public List<Product> Product { get; set; }
    }
}
