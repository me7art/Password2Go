using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Telerik.WinControls.UI;

namespace Password2Go.Forms
{
    public partial class OkCancelUIContainerForm : RadForm
    {
        //new
        //public Icon Icon
        //{
        //    get
        //    {
        //        return base.Icon;
        //    }
        //    set
        //    {
        //        base.Icon = value;
        //    }
        //}

        public OkCancelUIContainerForm(string title, UserControl control, Size formSize, DockStyle dockStyle = DockStyle.Fill)
        {
            InitializeComponent();

            panel2.Controls.Add(control);
            control.Dock = dockStyle;

            this.Size = formSize;
            this.MinimumSize = formSize;

            this.Text = title;
        }
    }
}
