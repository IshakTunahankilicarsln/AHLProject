
namespace NLayer_Task.Model.Dtos.Customer
{
    public class CustomerGetDto
    {
        public int CustomerID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Mail { get; set; }
        public string? Password { get; set; }
        public string? PicturePath { get; set; }

        public List<Addres.AddresGetDto> addres { get; set; }          
        
    }
}
