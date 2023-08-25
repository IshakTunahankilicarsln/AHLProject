using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Task.Business.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Aradığınız Sonuçlar listelenemedi")
        {

        }
        public NotFoundException(string message) : base(message)
        {
          
        }
    }
}
