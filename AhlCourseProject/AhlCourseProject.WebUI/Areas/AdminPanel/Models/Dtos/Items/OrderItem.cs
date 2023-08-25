namespace AhlCourseProject.WebUI.Areas.AdminPanel.Models.Dtos.Items
{
    public class OrderItem
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
    }
}
