using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Task.Model.Dtos.Admin
{
    public class AdminGetDto : IDto
    {
        public int? AdminId { get; set; }
        public string? AdminFullName { get; set; }
        public string? Email { get; set; }

    }
}
