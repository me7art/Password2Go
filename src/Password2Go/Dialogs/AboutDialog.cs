﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Telerik.WinControls.UI;

namespace Password2Go.Dialogs
{
    public partial class AboutDialog : RadForm
    {
        public AboutDialog(string version, string copyright)
        {
            InitializeComponent();

            labelVersion.Text = version;
            labelCopyright.Text = copyright;
        }
    }
}
