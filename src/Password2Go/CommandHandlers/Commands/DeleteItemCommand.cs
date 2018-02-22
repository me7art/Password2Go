using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Interfaces;
using Password2Go.Modules.PrivateCardList;

namespace Password2Go.CommandHandlers.Commands
{
    public class DeleteItemCommand : ICommand
    {
        MainFormCommandHandler _mainFormCommandHandler;
        PrivateCardListViewModel _item;

        public DeleteItemCommand(MainFormCommandHandler mainFormCommandHandler, PrivateCardListViewModel item)
        {
            _mainFormCommandHandler = mainFormCommandHandler;
            _item = item;
        }

        public void Execute()
        {
            _mainFormCommandHandler.DeleteItemAction(_item);
        }

        public bool CanExecute()
        {
            return _mainFormCommandHandler.CurrentCategory.NodeID
                != Password2Go.Data.Configs.CategoryTreeConfig.ID_RECYCLEBIN;
        }
    }
}
