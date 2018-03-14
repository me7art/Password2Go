using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using Common.Repository;
using Common.Repository.PrivateCards.CreditCard;
using Common.Repository.PrivateCards.DataBase;
using Common.Repository.PrivateCards.Device;
using Common.Repository.PrivateCards.Note;
using Common.Repository.PrivateCards.Site;
using Common.Helpers;
using PetaPoco;

namespace Password2Go.CommandHandlers
{
    public class TaskBarMenuCommandHandler
    {
        private ContextMenuStrip _menu;
        private CardsTableChain _cardsTableChain;

        public TaskBarMenuCommandHandler(ContextMenuStrip menu, Database db, ICommonXML<Data.Configs.CategoryTreeConfig> categoryXmlAdapter)
        {
            _menu = menu;
            var _siteCardsTable = new SiteCardsTableAdapter(db);
            var _noteCardsTable = new NoteCardsTableAdapter(db);
            var _deviceCardsTable = new DeviceCardsTableAdapter(db);
            var _databaseCardsTable = new DatabaseCardsTableAdapter(db);
            var _creditCardsTable = new CreditCardsTableAdapter(db);

            _cardsTableChain = new CardsTableChain(_siteCardsTable, _noteCardsTable, _deviceCardsTable, _databaseCardsTable, _creditCardsTable);

            var category = categoryXmlAdapter.Read();

            ToolStripMenuItem categoryMenu;

            foreach (ToolStripMenuItem item in _menu.Items)
            {
                if ("tsmiSelectPAssword" == item.Name)
                {
                    categoryMenu = item;
                    break;
                }
            }

            foreach (var item in category.Nodes)
            {
                
            }
        }
    }
}
