using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.Exceptions
{
    public class DecryptionCanceledByUserException : Exception
    {
        public DecryptionCanceledByUserException(string s) : base(s)
        {
        }
    }
}
