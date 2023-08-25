using NLayer_Task.Model.Dtos.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Task.Model.Dtos.SpesificDto
{
    public class ProductAndPicturePutDto
    {
        public ProductPutDto? Productputdto { get; set; }
        public List<string>? PictureImages { get; set; }
    }
}
