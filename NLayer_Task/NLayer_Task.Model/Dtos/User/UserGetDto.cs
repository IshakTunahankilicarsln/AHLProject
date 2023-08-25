using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Task.Model.Dtos.User
{
    public class UserGetDto
    {
        public int CustomerID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
