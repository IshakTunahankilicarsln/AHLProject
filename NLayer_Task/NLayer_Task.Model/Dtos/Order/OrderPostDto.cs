using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Task.Model.Dtos.Order
{
    public class OrderPostDto
    {
        public int CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? PostedDate { get; set; }
        public byte? ShippingCompanyID { get; set; }
        public decimal? Freight { get; set; }
        public int? CostumerShippingAdresID { get; set; }

    }
}
