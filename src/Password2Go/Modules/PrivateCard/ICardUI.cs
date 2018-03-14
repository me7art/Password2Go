using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Password2Go.Modules.PrivateCard
{
    public interface ICardUI
    {
        bool IsDecrypted { get; }
        bool IsReadOnly { get; set; }
        UserControl ThisUserControl { get; }

        Func<string> GeneratePasswordAction { get; set; }
    }

    public interface IBindableUI<TModelPublic, TModelPrivate>
    {
        void Bind(TModelPublic publicModel);
        void Bind(TModelPrivate privateModel);

        TModelPublic PublicViewModel { get; }
        TModelPrivate PrivateViewModel { get; }
    }

    public interface ICategorized
    {
        int ID { get; }
        string CategoryID { get; set; }
        DateTime CreatedDate { get; set; }
        PrivateCardList.PrivateCardTypeEnum CardType { get; set; }
    }
}
