using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Password2Go.Services.PasswordGenerator;

namespace Password2Go.Modules.PasswordGenerator
{
    public partial class PasswordGeneratorUI : UserControl
    {
        PasswordGeneratorService _passwordGeneratorService = new PasswordGeneratorService();

        public string PasswordInput
        {
            get
            {
                return rtbPassword.Text;
            }
            set
            {
                rtbPassword.Text = value;
            }
        }

        public PasswordGeneratorUI()
        {
            InitializeComponent();

            rseLowercaseCount.DataBindings.Add(nameof(rseLowercaseCount.Enabled), rtsLowercaseSwitch, nameof(rtsLowercaseSwitch.Value));
            rseUppercaseCount.DataBindings.Add(nameof(rseUppercaseCount.Enabled), rtsUppercaseSwitch, nameof(rtsUppercaseSwitch.Value));
            rseNumbersCount.DataBindings.Add(nameof(rseNumbersCount.Enabled), rtsNumbersSwitch, nameof(rtsNumbersSwitch.Value));
            rseSpecialCount.DataBindings.Add(nameof(rseSpecialCount.Enabled), rtsSpecialSwitch, nameof(rtsSpecialSwitch.Value));

            GeneratePassword();
        }

        private void GeneratePassword()
        {
            int lowercaseCount = rseLowercaseCount.Enabled ? (int)rseLowercaseCount.Value : 0;
            int uppercaseCount = rseUppercaseCount.Enabled ? (int)rseUppercaseCount.Value : 0;
            int numbersCount = rseNumbersCount.Enabled ? (int)rseNumbersCount.Value : 0;
            int specialsCount = rseSpecialCount.Enabled ? (int)rseSpecialCount.Value : 0;

            PasswordInput = _passwordGeneratorService.GeneratePassword(lowercaseCount, uppercaseCount, numbersCount, specialsCount);
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            GeneratePassword();
        }
        
    }
}
