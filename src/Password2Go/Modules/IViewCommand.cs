using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password2Go.Modules
{
    public interface IViewCommand
    {
        void Execute();
        bool CanExecute();
    }
}
