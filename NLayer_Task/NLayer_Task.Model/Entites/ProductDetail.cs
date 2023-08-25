using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Task.Model.Entites
{
    public class ProductDetail : IEntity
    {
        public int ProductID { get; set; }
        public string ProductVendor { get; set; }
        public DateTime ProductionDate { get; set; }
        public string ProductionPlace { get; set; }
        public string MakingMethod { get; set; }
        public string BuildingMaterialList { get; set; }
        public Int16 Weight { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }


    }
}
