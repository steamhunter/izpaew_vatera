using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izpaew_vatera
{

    public class KeyCollisionException : Exception
    {
        public KeyCollisionException(string message) : base(message) { }
       
    }
   
}
