using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Task.Model.Entites
{
    public class Addres : IEntity
    {
        public int AddresID { get; set; }
        public int CustomerID { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? NeighborhoodVillage { get; set; }
        public string? Street { get; set; }
        public string? FullAddress { get; set; }
        public bool? IsActive { get; set; } = true;

        public Customer? Customer { get; set; }

    }
}
