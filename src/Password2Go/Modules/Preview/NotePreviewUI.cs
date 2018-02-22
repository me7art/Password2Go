using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Password2Go.Modules;
using Common.Interfaces.Exceptions;

namespace Password2Go.Modules.Preview
{
    public partial class NotePreviewUI : UserControl, IPreviewUI
    {
        public UserControl ThisUserControl => this;

        const string HEADER_TEXT = "Selected Item";

        NotePreviewViewModel _model;
        public Action<BasePreviewViewModel> DecryptAction;

        public NotePreviewUI()
        {
            InitializeComponent();

            radGroupBox1.Text = HEADER_TEXT;
            Bind(null);
        }

        public void Bind(object previewModel, bool updateView = true)
        {
            NotePreviewViewModel model = previewModel as NotePreviewViewModel;

            _model = model;

            if (model == null)
            {
                radGroupBox1.Text = HEADER_TEXT;
                return;
            }

            if (updateView)
                UpdateView(model);
        }

        private void UpdateView(NotePreviewViewModel model)
        {
            radGroupBox1.Text = $"{HEADER_TEXT}: {model.Title}";

            if (!model.IsDecrypted)
            {
                rtbNote.Text = "*** Encrypted note ***";
            }
            else
            {
                rtbNote.Text = model.PrivateNote;
            }
        }

        private void rbDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                DecryptAction?.Invoke(_model);
                UpdateView(_model);
            }
            catch (DecryptionCanceledByUserException)
            {
                // do nothing
            }
            catch (Exception ex)
            {
                ex.Display();
            }
        }
    }

    public class NotePreviewViewModel : BasePreviewViewModel
    {
        public bool IsDecrypted;
        public int ID;
        public string Title;

        public string PrivateNote;

        public override void Accept(IPreviewViewVisitor visitor) => visitor.Visit(this);
    }
}
