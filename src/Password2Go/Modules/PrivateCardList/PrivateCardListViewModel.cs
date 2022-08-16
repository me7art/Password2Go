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


namespace Password2Go.Modules.PrivateCardList
{
    public enum PrivateCardTypeEnum
    {
        None, Site, Note, Device, Database, CreditCard
    }

    public class SiteCardListViewModel : PrivateCardListViewModel
    {
        public override void Accept(IPrivateCardListViewVisitor visitor) => visitor.Visit(this);
    }

    public class NoteCardListViewModel : PrivateCardListViewModel
    {
        public override void Accept(IPrivateCardListViewVisitor visitor) => visitor.Visit(this);
    }

    public class DeviceCardListViewModel : PrivateCardListViewModel
    {
        public override void Accept(IPrivateCardListViewVisitor visitor) => visitor.Visit(this);
    }

    public class DatabaseCardListViewModel : PrivateCardListViewModel
    {
        public override void Accept(IPrivateCardListViewVisitor visitor) => visitor.Visit(this);
    }

    public class CreditCardListViewModel : PrivateCardListViewModel
    {
        public override void Accept(IPrivateCardListViewVisitor visitor) => visitor.Visit(this);
    }

    public interface IPrivateCardListViewVisitor
    {
        void Visit(SiteCardListViewModel siteCardListViewModel);
        void Visit(NoteCardListViewModel noteCardListViewModel);
        void Visit(DeviceCardListViewModel deviceCardListViewModel);
        void Visit(DatabaseCardListViewModel databaseCardListViewModel);
        void Visit(CreditCardListViewModel creditCardListViewModel);
    }

    public abstract class PrivateCardListViewModel : INotifyPropertyChanged
    {
        public PrivateCardTypeEnum CardType { get; set; }
        public int ID { get; set; }

        public string CardName { get; set; }
        public Image CardImage { get; set; }

        public string Title { get; set; }

        public bool IsSSHTerminalEnabled { get; set; }

        public string CategoryID { get; set; }

        //public string CategoryName { get; set; }

        public void UpdateView(PrivateCardListViewModel newView)
        {
            CardName = newView.CardName;
            CardImage = newView.CardImage;
            IsSSHTerminalEnabled = newView.IsSSHTerminalEnabled;
            OnPropertyChanged(nameof(CardName));
            OnPropertyChanged(nameof(CardImage));
        }

        public abstract void Accept(IPrivateCardListViewVisitor visitor);
        
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion INotifyPropertyChanged Members
    }
}
