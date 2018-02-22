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
    public partial class DatabaseCardUI : UserControl, ICardUI, IBindableUI<DatabaseCardPublicViewModel, DatabaseCardPrivateViewModel>
    {
        public bool IsDecrypted => _privateModel != null;
        public UserControl ThisUserControl => this;

        DatabaseCardPrivateViewModel _privateModel;
        DatabaseCardPublicViewModel _publicModel;
        public DatabaseCardPublicViewModel PublicViewModel => _publicModel;
        public DatabaseCardPrivateViewModel PrivateViewModel => _privateModel;

        public DatabaseCardUI()
        {
            InitializeComponent();
            tbPasswordPriv.Text = LocalStringResource.ENCRYPTED_PASSWORD_STRING;
            tbCommentPriv.Text = LocalStringResource.ENCRYPTED_COMMENT_STRING;
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
                tbDatabase.IsReadOnly = _isReadOnly;
            }
        }

        public void Bind(DatabaseCardPublicViewModel publicModel)
        {
            _publicModel = publicModel;
            tbTitle.AddBindingToText(publicModel, nameof(publicModel.Title));
            tbAddress.AddBindingToText(publicModel, nameof(publicModel.Address));
            tbPort.AddBindingToText(publicModel, nameof(publicModel.Port));
            tbLogin.AddBindingToText(publicModel, nameof(publicModel.Login));
            tbComment.AddBindingToText(publicModel, nameof(publicModel.CommentPublic));
            tbDatabase.AddBindingToText(publicModel, nameof(publicModel.DatabaseName));
        }

        public void Bind(DatabaseCardPrivateViewModel privateModel)
        {
            _privateModel = privateModel;
            tbPasswordPriv.AddBindingToText(privateModel, nameof(privateModel.Password));
            tbCommentPriv.AddBindingToText(privateModel, nameof(privateModel.CommentProtected));
        }
    }

    public class DatabaseCardPublicViewModel : ICategorized
    {
        // Public part
        public int ID { get; set; } = -1;
        public PrivateCardList.PrivateCardTypeEnum CardType { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Port { get; set; }
        public string Login { get; set; }
        public string DatabaseName { get; set; }
        public string CommentPublic { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CategoryID { get; set; }
    }

    public class DatabaseCardPrivateViewModel
    {
        public string Password { get; set; }
        public string CommentProtected { get; set; }
    }
}
