using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password2Go.Modules.PrivateCard
{
    public partial class CreditCardUI : UserControl, ICardUI, IBindableUI<CreditCardPublicViewModel,CreditCardPrivateViewModel>
    {
        public bool IsDecrypted => _privateModel != null;
        public UserControl ThisUserControl => this;

        CreditCardPublicViewModel _publicModel;
        CreditCardPrivateViewModel _privateModel;
        public CreditCardPublicViewModel PublicViewModel => _publicModel;
        public CreditCardPrivateViewModel PrivateViewModel => _privateModel;

        public CreditCardUI()
        {
            InitializeComponent();

            tbCreditCardNumber.Text = LocalStringResource.ENCRYPTED_PASSWORD_STRING;
            tbComment.Text = LocalStringResource.ENCRYPTED_COMMENT_STRING;
        }

        bool _isReadOnly = false;
        public bool IsReadOnly
        {
            get
            {
                return _isReadOnly;
            }
            set
            {
                _isReadOnly = value;
                tbTitle.IsReadOnly = _isReadOnly;
                tbBank.IsReadOnly = _isReadOnly;
                tbComment.IsReadOnly = _isReadOnly;

                tbCreditCardNumber.IsReadOnly = _isReadOnly;
                tbCreditCardHolder.IsReadOnly = _isReadOnly;
                tbCreditCardValidTill.IsReadOnly = _isReadOnly;
                tbCreditCardCVV.IsReadOnly = _isReadOnly;
                tbCreditCardPin.IsReadOnly = _isReadOnly;
            }
        }

        public void Bind(CreditCardPublicViewModel publicModel)
        {
            _publicModel = publicModel;
            tbTitle.AddBindingToText(publicModel, nameof(publicModel.Title));
            tbBank.AddBindingToText(publicModel, nameof(publicModel.Bank));
            tbComment.AddBindingToText(publicModel, nameof(publicModel.CommentPublic));
            tbLast4Digit.AddBindingToText(publicModel, nameof(publicModel.Last4Digit));
        }

        public void Bind(CreditCardPrivateViewModel privateModel)
        {
            _privateModel = privateModel;
            tbCreditCardNumber.AddBindingToText(privateModel, nameof(privateModel.Number));
            tbCreditCardHolder.AddBindingToText(privateModel, nameof(privateModel.Holder));
            tbCreditCardValidTill.AddBindingToText(privateModel, nameof(privateModel.ValidTill));
            tbCreditCardCVV.AddBindingToText(privateModel, nameof(privateModel.CVV));
            tbCreditCardPin.AddBindingToText(privateModel, nameof(privateModel.Pin));
        }
    }

    public class CreditCardPublicViewModel : ICategorized
    {
        // Public part
        public int ID { get; set; } = -1;
        public PrivateCardList.PrivateCardTypeEnum CardType { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CategoryID { get; set; }

        public string Title { get; set; }
        public string Bank { get; set; }
        public string CommentPublic { get; set; }
        public string Last4Digit { get; set; }
    }

    public class CreditCardPrivateViewModel
    {
        // Protected part
        public string Number { get; set; }
        public string Holder { get; set; }
        public string ValidTill { get; set; }
        public string CVV { get; set; }
        public string Pin { get; set; }
    }

}
