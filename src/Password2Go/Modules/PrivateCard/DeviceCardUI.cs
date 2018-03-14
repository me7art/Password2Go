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
    public partial class DeviceCardUI : UserControl, ICardUI, IBindableUI<DeviceCardPublicViewModel, DeviceCardPrivateViewModel>
    {
        public bool IsDecrypted => _privateModel != null;
        public UserControl ThisUserControl => this;

        DeviceCardPrivateViewModel _privateModel;
        DeviceCardPublicViewModel _publicModel;
        public DeviceCardPublicViewModel PublicViewModel => _publicModel;
        public DeviceCardPrivateViewModel PrivateViewModel => _privateModel;

        private GeneratePasswordHelper _passwordHelper;
        public Func<string> GeneratePasswordAction
        {
            get
            {
                return _passwordHelper.GeneratePasswordAction;
            }
            set
            {
                _passwordHelper.GeneratePasswordAction = value;
            }
        }

        public DeviceCardUI()
        {
            InitializeComponent();
            tbPasswordPriv.Text = LocalStringResource.ENCRYPTED_PASSWORD_STRING;
            tbCommentPriv.Text = LocalStringResource.ENCRYPTED_COMMENT_STRING;

            _passwordHelper = new GeneratePasswordHelper(tbPasswordPriv);
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
                tbAddress.IsReadOnly = _isReadOnly;
                tbLogin.IsReadOnly = _isReadOnly;
                tbComment.IsReadOnly = _isReadOnly;
                tbPasswordPriv.IsReadOnly = _isReadOnly;
                tbCommentPriv.IsReadOnly = _isReadOnly;
                tbPort.IsReadOnly = _isReadOnly;
                _passwordHelper.SetVisibility(!_isReadOnly);
            }
        }

        public void Bind(DeviceCardPublicViewModel publicModel)
        {
            _publicModel = publicModel;
            tbTitle.AddBindingToText(publicModel, nameof(publicModel.Title));
            tbAddress.AddBindingToText(publicModel, nameof(publicModel.Address));
            tbPort.AddBindingToText(publicModel, nameof(publicModel.Port));
            tbLogin.AddBindingToText(publicModel, nameof(publicModel.Login));
            tbComment.AddBindingToText(publicModel, nameof(publicModel.CommentPublic));
        }

        public void Bind(DeviceCardPrivateViewModel privateModel)
        {
            _privateModel = privateModel;
            tbPasswordPriv.AddBindingToText(privateModel, nameof(privateModel.Password));
            tbCommentPriv.AddBindingToText(privateModel, nameof(privateModel.CommentProtected));
        }
    }

    public class DeviceCardPublicViewModel : ICategorized
    {
        // Public part
        public int ID { get; set; } = -1;
        public PrivateCardList.PrivateCardTypeEnum CardType { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Port { get; set; }
        public string Login { get; set; }
        public string CommentPublic { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CategoryID { get; set; }
    }

    public class DeviceCardPrivateViewModel
    {
        public string Password { get; set; }
        public string CommentProtected { get; set; }
    }
}
