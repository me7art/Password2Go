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
    public partial class NoteCardUI : UserControl, ICardUI, IBindableUI<NoteCardPublicViewModel, NoteCardPrivateViewModel>
    {
        public bool IsDecrypted => _privateModel != null;
        public UserControl ThisUserControl => this;

        NoteCardPublicViewModel _publicModel;
        NoteCardPrivateViewModel _privateModel;

        public NoteCardPublicViewModel PublicViewModel => _publicModel;
        public NoteCardPrivateViewModel PrivateViewModel => _privateModel;

        public NoteCardUI()
        {
            InitializeComponent();

            tbNotePriv.Text = "*** Encrypted Note ***";
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
                tbNotePriv.IsReadOnly = _isReadOnly;
            }
        }

        public void Bind(NoteCardPublicViewModel publicModel)
        {
            _publicModel = publicModel;

            tbTitle.AddBindingToText(_publicModel, nameof(_publicModel.Title));
        }

        public void Bind(NoteCardPrivateViewModel privateModel)
        {
            _privateModel = privateModel;

            tbNotePriv.AddBindingToText(_privateModel, nameof(_privateModel.Note));
        }
    }

    public class NoteCardPublicViewModel : ICategorized
    {
        // Public part
        public int ID { get; set; } = -1;
        public PrivateCardList.PrivateCardTypeEnum CardType { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }

        public string CategoryID { get; set; }
    }

    public class NoteCardPrivateViewModel
    {
        // Protected part
        public string Note { get; set; }
    }
}
