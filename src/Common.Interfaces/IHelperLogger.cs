using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{

    public enum eLOG
    {
        E_LOGMESSAGE,
        E_ERROR,
        E_CRITICAL_ERROR
    }

    public interface IHelperLogger
    {
        void Log(string message, eLOG a);
    }
}
