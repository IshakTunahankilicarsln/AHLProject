using Infrastructure.Model;


namespace NLayer_Task.Model.Dtos.Order
{
    public class OrderGetDto : IDto
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? PostedDate { get; set; }
        public byte? ShippingCompanyID { get; set; }
        public decimal? Freight { get; set; }
        public int? CostumerShippingAdresID { get; set; }
        public bool? IsActive { get; set; }

        public Customer.CustomerGetDto? Customer { get; set; }
    }
}
