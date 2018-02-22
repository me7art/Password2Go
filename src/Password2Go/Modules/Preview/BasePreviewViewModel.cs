using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password2Go.Modules.Preview
{
    public interface IPreviewViewVisitor
    {
        void Visit(SitePreviewViewModel sitePreviewViewModel);
        void Visit(NotePreviewViewModel notePreviewViewModel);
        void Visit(DevicePreviewViewModel devicePreviewViewModel);
        void Visit(DatabasePreviewViewModel databasePreviewViewModel);
        void Visit(CreditCardPreviewViewModel creditCardPreviewViewModel);
    }

    public abstract class BasePreviewViewModel
    {
        public abstract void Accept(IPreviewViewVisitor visitor);
    }

    public enum PasswordTypeEnum
    {
        None, Password, Number, CVV
    }
}
