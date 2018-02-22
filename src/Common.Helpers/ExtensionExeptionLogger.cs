using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Interfaces;

namespace Common.Helpers
{
    public static class ExtensionExeptionLogger
    {
        public static IHelperLogger Logger;

        internal static Exception Log(this Exception ex, eLOG elog, string msg = null)
        {
            Logger?.Log(msg ?? ex.Message, elog);
            Logger?.Log(ex.StackTrace, elog);
            return ex;
        }
    }
}
