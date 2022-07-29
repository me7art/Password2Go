using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls.Layouts;


namespace Password2Go.Modules.PrivateCardList
{
    // +-------+  Title
    // | IMAGE |  Login
    // +-------+  at Site

    public class PrivateCardListVisualItem : IconListViewVisualItem
    {
        GridLayout _layout = new GridLayout() { Padding = new Padding(1), StretchHorizontally = false, StretchVertically = false };
        LightVisualElement _imgElement = new LightVisualElement();
        RadLabelElement _titleElement = new RadLabelElement();

        RadButtonElement _terminalSSHButton = new RadButtonElement()
        {
            StretchHorizontally = false,
            StretchVertically = false,
            Alignment = ContentAlignment.BottomRight,
            Padding = new Padding(left: 0, top: 0, right: 0, bottom: 0),
            Margin = new Padding(left: 0, top: 0, right: 1, bottom: 0),
            Image = Password2Go.Properties.Resources._35659_osx_application_terminal_icon,
            Size = new Size(16, 16),
            DisplayStyle = Telerik.WinControls.DisplayStyle.Image,
            ShowBorder = false,
            ToolTipText = "Putty"
        };

        //RadButtonElement winSCPButton = new RadButtonElement()
        //{
        //    StretchHorizontally = false,
        //    StretchVertically = false,
        //    Alignment = ContentAlignment.BottomRight,
        //    Padding = new Padding(left: 0, top: 0, right: 0, bottom: 0),
        //    Margin = new Padding(left: 0, top: 0, right: 20, bottom: 0),
        //    Image = Password2Go.Properties.Resources._36059_folder_open_yellow_icon,
        //    Size = new Size(16, 16),
        //    DisplayStyle = Telerik.WinControls.DisplayStyle.Image,
        //    ShowBorder = false,
        //    ToolTipText = "WinSCP"
        //};



        private Action<PrivateCardListViewModel> _terminalButtonAction;

        public PrivateCardListVisualItem(Action<PrivateCardListViewModel> terminalButtonAction) : base()
        {
            _terminalButtonAction = terminalButtonAction;
        }

        protected override Type ThemeEffectiveType
        {
            get
            {
                return typeof(IconListViewVisualItem);
            }
        }

        protected override void CreateChildElements()
        {
            base.CreateChildElements();

            _terminalSSHButton.Click += TerminalButton_Click;

            //layout.StretchHorizontally = layout.StretchVertically = false;
            _layout.Rows.Clear();
            _layout.Columns.Clear();

            _layout.Rows.Add(new GridLayoutRow() { SizingType = GridLayoutSizingType.Fixed, FixedHeight = 16 });
            _layout.Rows.Add(new GridLayoutRow() { SizingType = GridLayoutSizingType.Fixed, FixedHeight = 16 });
            _layout.Rows.Add(new GridLayoutRow() { SizingType = GridLayoutSizingType.Fixed, FixedHeight = 16 });

            _layout.Columns.Add(new GridLayoutColumn() { SizingType = GridLayoutSizingType.Fixed, FixedWidth = 32 });
            _layout.Columns.Add(new GridLayoutColumn() { SizingType = GridLayoutSizingType.Fixed, FixedWidth = 126 });


            //imgElement.Click += ButtonElement_Click;
            _imgElement.SetValue(GridLayout.RowIndexProperty, 0);
            _imgElement.SetValue(GridLayout.ColumnIndexProperty, 0);
            _imgElement.SetValue(GridLayout.RowSpanProperty, 2);
            _layout.Children.Add(_imgElement);


            _titleElement.SetValue(GridLayout.RowIndexProperty, 0);
            _titleElement.SetValue(GridLayout.ColumnIndexProperty, 1);
            _titleElement.SetValue(GridLayout.RowSpanProperty, 3);

            //titleElement.Children.Add(winSCPButton);
            _titleElement.Children.Add(_terminalSSHButton);
            _layout.Children.Add(_titleElement);


            _imgElement.ShouldHandleMouseInput = false;
            _imgElement.NotifyParentOnMouseInput = true;

            _titleElement.ShouldHandleMouseInput = false;
            _titleElement.NotifyParentOnMouseInput = true;

            this.Children.Add(_layout);
        }

        private void TerminalButton_Click(object sender, EventArgs e)
        {
            try
            {
                _terminalButtonAction?.Invoke(this.Data.DataBoundItem as PrivateCardListViewModel);
            } catch (Exception ex)
            {
                ex.Display();
            }
        }

        protected override void SynchronizeProperties()
        {
            base.SynchronizeProperties();

            var o = this.Data.DataBoundItem as PrivateCardListViewModel;

            this.Text = string.Empty;
            this._imgElement.Image = o.CardImage;
            this._titleElement.Text = o.CardName;

            if (Selected)
            {
                if (o.IsSSHTerminalEnabled == true)
                {
                    _imgElement.ShouldHandleMouseInput = true;
                    _terminalSSHButton.Visibility = Telerik.WinControls.ElementVisibility.Visible;
                    //winSCPButton.Visibility = Telerik.WinControls.ElementVisibility.Visible;
                }

            }
            else
            {
                _imgElement.ShouldHandleMouseInput = false;
                _terminalSSHButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
                //winSCPButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            }

        }

    }
}
