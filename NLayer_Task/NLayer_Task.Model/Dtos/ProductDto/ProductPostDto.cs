using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Task.Model.Dtos.ProductDto
{
    public class ProductPostDto
    {
        public string ProductName { get; set; }
        public string ProductMaterial { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int CategoryID { get; set; }


    }
}
