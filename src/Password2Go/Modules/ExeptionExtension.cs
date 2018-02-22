using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using Telerik.WinControls;


namespace Password2Go.Modules
{
    static public class ExeptionExtension
    {
        static public Exception Display(this Exception ex)
        {
            RadMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            return ex;
        }
    }
}
