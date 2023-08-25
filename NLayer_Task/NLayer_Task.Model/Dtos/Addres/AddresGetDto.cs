using Infrastructure.Model;

namespace NLayer_Task.Model.Dtos.Addres
{
    public class AddresGetDto : IDto
    {
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? NeighborhoodVillage { get; set; }
        public string? Street { get; set; }
        public string? FullAddress { get; set; }
        public bool? IsActive { get; set; }
        public string? CustomerName { get; set; }

    }
}
