using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Telerik.WinControls;
using Telerik.WinControls.UI;

using Password2Go.Modules;

namespace Password2Go.Forms
{
    public partial class BeforeWeStartForm : RadForm
    {
        Func<Task> _generateKeys;
        Action _selectKeys;
        Action _selectDatabaseDirectory;

        public BeforeWeStartForm()
        {
            InitializeComponent();
        }

        public void Init(Func<Task> generateKeys, Action selectKeys, Action selectDatabaseDirectory)
        {
            _generateKeys = generateKeys;
            _selectKeys = selectKeys;
            _selectDatabaseDirectory = selectDatabaseDirectory;

        }

        public void SetDoneEnabled(bool isDone)
        {
            rbDone.Enabled = isDone;
        }

        private async void rbGenerateKeys_Click(object sender, EventArgs e)
        {
            try
            {
                await _generateKeys();
            } catch (Exception ex)
            {
                ex.Display();
            }
        }

        private void rbSelectKeys_Click(object sender, EventArgs e)
        {
            try
            {
                _selectKeys?.Invoke();
            } catch (Exception ex)
            {
                ex.Display();
            }
        }

        private void rbSelectDirectory_Click(object sender, EventArgs e)
        {
            try
            {
                _selectDatabaseDirectory?.Invoke();
            }
            catch (Exception ex)
            {
                ex.Display();
            }
        }


        private bool _isGeneratingLabelVisible;
        public bool IsGeneratingLabelVisible
        {
            get { return labelGenerating.Visible; }
            set
            {
                _isGeneratingLabelVisible = value;
                labelGenerating.Visible = _isGeneratingLabelVisible;
            }
        }

        private bool _isWeDodeLabelVisible;
        public bool IsWeDonaLabelVisible
        {
            get { return _isWeDodeLabelVisible; }
            set
            {
                _isWeDodeLabelVisible = value;
                labelWeDone.Visible = _isWeDodeLabelVisible;
            }
        }

        public void DisableStep1(bool disable)
        {
            radLabel3.Enabled = !disable;
            rbGenerateKeys.Enabled = !disable;
            radLabel1.Enabled = !disable;
            rbSelectKeys.Enabled = !disable;
        }

        public void DisableStep2(bool disable)
        {
            radLabel4.Enabled = !disable;
            rbSelectDirectory.Enabled = !disable;
        }
    }
}
