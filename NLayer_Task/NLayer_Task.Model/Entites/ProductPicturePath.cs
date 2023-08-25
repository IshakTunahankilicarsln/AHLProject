using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Task.Model.Entites
{
    public class ProductPicturePath : IEntity
    {
        public int ID { get; set; }
        public int? ProductID { get; set; }
        public string? PicturePath { get; set; }
        public bool? IsActive { get; set; } = true;
    }
}
