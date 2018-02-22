using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Password2Go.Modules;
using Telerik.WinControls.UI;

namespace Password2Go.Forms
{
    public partial class KeysPathForm : RadForm
    {
        KeyPathViewModel _keys;

        public KeysPathForm()
        {
            InitializeComponent();
        }

        public void Bind(KeyPathViewModel vm)
        {
            _keys = vm;
            rtbPublicKeyPath.AddBindingToText(_keys, nameof(_keys.PublicKeyPath));
            rtbPrivateKeyPath.AddBindingToText(_keys, nameof(_keys.PrivateKeyPath));
        }

        private void rbSelectPublicFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog() { Filter = "Public key (*.2go-public)|*.2go-public|All files (*.*)|*.*" })
            {
                var dialogResult = dialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    rtbPublicKeyPath.Text = dialog.FileName;
                    _keys.PublicKeyPath = dialog.FileName;
                }
            }
        }

        private void rbSelectPrivateFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog() { Filter = "Private key (*.2go-private)|*.2go-private|All files (*.*)|*.*" })
            {
                var dialogResult = dialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    rtbPrivateKeyPath.Text = dialog.FileName;
                    _keys.PrivateKeyPath = dialog.FileName;
                }
            }
        }
    }

    public class KeyPathViewModel
    {
        public string PublicKeyPath { get; set; }
        public string PrivateKeyPath { get; set; }
    }
}
