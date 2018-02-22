using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

using Telerik.WinControls.Layouts;
using Telerik.WinControls.UI;

using System.Drawing;
using System.Windows.Forms;

namespace Password2Go.Modules
{
    public static class RadTextBoxControlExtension
    {
        public static void AddBindingToText(this RadTextBoxControl control, object vm, string propertyName)
        {
            control.DataBindings.Add("Text", vm, propertyName);
        }

        public static LightVisualButtonElement CreateInButton(Image btnImage, EventHandler clickEvent)
        {
            LightVisualButtonElement newButton = new LightVisualButtonElement() { EnableImageTransparency = true };
            newButton.Click += new EventHandler(clickEvent);

            newButton.Margin = new Padding(0, 0, 1, 0);
            newButton.Image = btnImage; //Properties.Resources.paste_plain1;
            //newButton.DisplayStyle = DisplayStyle.Image;
            newButton.ImageAlignment = ContentAlignment.MiddleCenter;
            return newButton;
        }

        public static LightVisualButtonElement AddElementToTextBox(this RadTextBoxControl t, Image image, EventHandler clickEvent)
        {
            var button = CreateInButton(image, clickEvent);
            var stackPanel = t.TextBoxElement.Children.FirstOrDefault(x => x is StackLayoutPanel);
            if (stackPanel != null) stackPanel.Children.Add(button);

            return button;
        }

        public static void Blink(this RadTextBoxControl t, Color blinkColor, int blinkTime)
        {
            var oldColor = t.TextBoxElement.BackColor;
            t.TextBoxElement.BackColor = blinkColor;

            Task.Run(() => {
                Thread.Sleep(blinkTime);
                if (t.InvokeRequired)
                {
                    t.Invoke(new Action(() => { t.TextBoxElement.BackColor = oldColor; }));
                } else
                {
                    t.TextBoxElement.BackColor = oldColor;
                }
            });
        }
    }

    public static class RadTextBoxExtension
    {
        public static void AddBindingToText(this RadTextBox control, object vm, string propertyName)
        {
            control.DataBindings.Add("Text", vm, propertyName);
        }
    }
}
