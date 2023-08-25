using Infrastructure.Model;

namespace NLayer_Task.Model.Entites
{
    public class OrderDetail : IEntity
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal TotalPrice { get; set; }
        public int Amount { get; set; }
        public byte Discount { get; set; }
        public bool IsActive { get; set; }
    }
}
