using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Password2Go.Data;
using Common.Repository.PrivateCards;
using Password2Go.Services.Mappers.CardDataMapper.Site;
using Password2Go.Services.Mappers.CardDataMapper.Note;
using Password2Go.Services.Mappers.CardDataMapper.Device;
using Password2Go.Services.Mappers.CardDataMapper.DataBase;
using Password2Go.Services.Mappers.CardDataMapper.CreditCard;
using Password2Go.Modules.PrivateCardList;
using Password2Go.Services.Holders;
using Password2Go.Modules.Preview;
using Password2Go.Services.Decrypt;

namespace Password2Go.CommandHandlers.Visitors.PreviewItem
{
    public class DecryptPreviewActionVisitor : IPreviewViewVisitor
    {
        CardsTableChain _cardsTableChain;
        Dictionary<PrivateCardTypeEnum, IPreviewUI> _previewUIs;
        PassphraseHolderService _passphraseHolderService;
        KeyHolderService _keyHolderService;

        public DecryptPreviewActionVisitor(
            CardsTableChain cardsTableChain,
            Dictionary<PrivateCardTypeEnum, IPreviewUI> previewUIs,
            PassphraseHolderService passphraseHolderService,
            KeyHolderService keyHolderService)
        {
            _cardsTableChain = cardsTableChain;

            _previewUIs = previewUIs;
            _passphraseHolderService = passphraseHolderService;
            _keyHolderService = keyHolderService;
        }

        public void Visit(DevicePreviewViewModel devicePreviewViewModel)
        {
            var data = _cardsTableChain.DeviceCardsTable.Select(devicePreviewViewModel.ID);
            var secretData = DecryptService.DecryptData<DeviceEncryptedData, DeviceSecretData>(data, _keyHolderService, _passphraseHolderService);
            var newModel = data.MapToPreview(secretData);
            _previewUIs[PrivateCardTypeEnum.Device].Bind(newModel, updateView: false);
        }

        public void Visit(NotePreviewViewModel notePreviewViewModel)
        {
            var data = _cardsTableChain.NoteCardsTable.Select(notePreviewViewModel.ID);
            var secretData = DecryptService.DecryptData<NoteEncryptedData, NoteSecretData>(data, _keyHolderService, _passphraseHolderService);
            var newModel = data.MapToPreview(secretData);
            _previewUIs[PrivateCardTypeEnum.Note].Bind(newModel, updateView: false);
        }

        public void Visit(SitePreviewViewModel sitePreviewViewModel)
        {
            var data = _cardsTableChain.SiteCardsTable.Select(sitePreviewViewModel.ID);
            var secretData = DecryptService.DecryptData<SiteEncryptedData, SiteSecretData>(data, _keyHolderService, _passphraseHolderService);
            var newModel = data.MapToPreview(secretData);
            _previewUIs[PrivateCardTypeEnum.Site].Bind(newModel, updateView: false);
        }

        public void Visit(DatabasePreviewViewModel previewViewModel)
        {
            var data = _cardsTableChain.DatabaseCardsTable.Select(previewViewModel.ID);
            var secretData = DecryptService.DecryptData<DatabaseEncryptedData, DatabaseSecretData>(data, _keyHolderService, _passphraseHolderService);
            var newModel = data.MapToPreview(secretData);
            _previewUIs[PrivateCardTypeEnum.Database].Bind(newModel, updateView: false);
        }

        public void Visit(CreditCardPreviewViewModel previewViewModel)
        {
            var data = _cardsTableChain.CreditCardsTable.Select(previewViewModel.ID);
            var secretData = DecryptService.DecryptData<CreditCardEncryptedData, CreditCardSecretData>(data, _keyHolderService, _passphraseHolderService);
            var newModel = data.MapToPreview(secretData);
            _previewUIs[PrivateCardTypeEnum .CreditCard].Bind(newModel, updateView: false);
        }
    }
}
