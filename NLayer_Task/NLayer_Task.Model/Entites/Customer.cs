using Infrastructure.Model;

namespace NLayer_Task.Model.Entites
{
    public class Customer : IEntity
    {
        public int CustomerID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Mail { get; set; }
        public string? PicturePath { get; set; }
        public string? Password { get; set; }
        public bool? IsActive { get; set; } = true;

        public List<Addres> Addres { get; set; }
        
    }
}
