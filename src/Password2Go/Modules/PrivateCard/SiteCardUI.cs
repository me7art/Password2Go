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
    public partial class SiteCardUI : UserControl, ICardUI, IBindableUI<SiteCardPublicViewModel, SiteCardPrivateViewModel>
    {
        public bool IsDecrypted => _privateModel != null;
        public UserControl ThisUserControl => this;

        SiteCardPrivateViewModel _privateModel;
        SiteCardPublicViewModel _publicModel;
        public SiteCardPublicViewModel PublicViewModel => _publicModel;
        public SiteCardPrivateViewModel PrivateViewModel => _privateModel;

        public SiteCardUI()
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
                tbSite.IsReadOnly = _isReadOnly;
                tbLogin.IsReadOnly = _isReadOnly;
                tbComment.IsReadOnly = _isReadOnly;
                tbPasswordPriv.IsReadOnly = _isReadOnly;
                tbCommentPriv.IsReadOnly = _isReadOnly;
            }
        }

        public void Bind(SiteCardPublicViewModel publicModel)
        {
            _publicModel = publicModel;
            tbTitle.AddBindingToText(publicModel, nameof(publicModel.Title));
            tbSite.AddBindingToText(publicModel, nameof(publicModel.Site));
            tbLogin.AddBindingToText(publicModel, nameof(publicModel.Login));
            tbComment.AddBindingToText(publicModel, nameof(publicModel.CommentPublic));
        }

        public void Bind(SiteCardPrivateViewModel privateModel)
        {
            _privateModel = privateModel;
            tbPasswordPriv.AddBindingToText(privateModel, nameof(privateModel.Password));
            tbCommentPriv.AddBindingToText(privateModel, nameof(privateModel.CommentProtected));
        }
    }



    public class SiteCardPublicViewModel : ICategorized
    {
        // Public part
        public int ID { get; set; } = -1;
        public PrivateCardList.PrivateCardTypeEnum CardType { get; set; }
        public string Title { get; set; }
        public string Site { get; set; }
        public string Login { get; set; }
        public string CommentPublic { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CategoryID { get; set; }
    }

    public class SiteCardPrivateViewModel
    {
        // Protected part
        public string Password { get; set; }
        public string CommentProtected { get; set; }
    }
}
