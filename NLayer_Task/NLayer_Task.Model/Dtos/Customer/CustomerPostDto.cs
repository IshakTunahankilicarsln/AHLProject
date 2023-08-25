using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Task.Model.Dtos.Customer
{
    public class CustomerPostDto : IDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Mail { get; set; }
        public string? Password { get; set; }
        public string? PicturePath { get; set; }

    }
}
