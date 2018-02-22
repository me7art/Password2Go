using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Password2Go.Modules
{
    public class ShowHideHelper : INotifyPropertyChanged
    {
        public bool IsShowWhatever { get; private set; }
        public bool IsHideWhatever => !IsShowWhatever;
        public string Text => IsShowWhatever ? _showName : _hideName;
        public Telerik.WinControls.ElementVisibility ShowVisibility => IsShowWhatever ? Telerik.WinControls.ElementVisibility.Visible
            : Telerik.WinControls.ElementVisibility.Collapsed;
        public Telerik.WinControls.ElementVisibility HideVisibility => !IsShowWhatever ? Telerik.WinControls.ElementVisibility.Visible
            : Telerik.WinControls.ElementVisibility.Collapsed;

        string _showName;
        string _hideName;

        bool _startReversed;



        public ShowHideHelper(string showName, string hideName, bool startReversed = false)
        {
            _startReversed = startReversed;
            IsShowWhatever = !startReversed;     // (true by default)

            _showName = showName;
            _hideName = hideName;
        }

        public void Reset()
        {
            IsShowWhatever = !_startReversed;
            RaiseChangedEvent();
        }

        public void Reverse()
        {
            IsShowWhatever = !IsShowWhatever;

            RaiseChangedEvent();
        }

        void RaiseChangedEvent()
        {
            OnPropertyChanged(nameof(IsShowWhatever));
            OnPropertyChanged(nameof(IsHideWhatever));
            OnPropertyChanged(nameof(Text));
            OnPropertyChanged(nameof(ShowVisibility));
            OnPropertyChanged(nameof(HideVisibility));
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion INotifyPropertyChanged Members
    }
}
