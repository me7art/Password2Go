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
        //readonly Bitmap GENERATE_PASSWORD_IMAGE = Password2Go.Properties.Resources.if_dice_64067_16x16;

        public bool IsDecrypted => _privateModel != null;
        public UserControl ThisUserControl => this;
        public SiteCardPublicViewModel PublicViewModel => _publicModel;
        public SiteCardPrivateViewModel PrivateViewModel => _privateModel;

        private SiteCardPrivateViewModel _privateModel;
        private SiteCardPublicViewModel _publicModel;

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

        public SiteCardUI()
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
                tbSite.IsReadOnly = _isReadOnly;
                tbLogin.IsReadOnly = _isReadOnly;
                tbComment.IsReadOnly = _isReadOnly;
                tbPasswordPriv.IsReadOnly = _isReadOnly;
                tbCommentPriv.IsReadOnly = _isReadOnly;
                _passwordHelper.SetVisibility(!_isReadOnly);
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

        //private void rbGeneratePassword_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string generatedPassword = GeneratePasswordAction();
        //        if (!string.IsNullOrWhiteSpace(generatedPassword))
        //        {
        //            tbPasswordPriv.Text = generatedPassword;
        //        }
        //    } catch (Exception ex)
        //    {
        //        ex.Display();
        //    }
        //}
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
