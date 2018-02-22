using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Password2Go.Data;
using Common.Repository.PrivateCards;
using Password2Go.Services.Holders;
using Password2Go.Modules.Preview;
using Password2Go.Services.Decrypt;

namespace Password2Go.CommandHandlers.Visitors.PreviewItem
{
    public class CopyPasswordPreviewActionVisitor : IPreviewViewVisitor
    {
        CardsTableChain _cardsTableChain;
        PassphraseHolderService _passphraseHolderService;
        KeyHolderService _keyHolderService;
        PasswordTypeEnum _passwordType;

        public CopyPasswordPreviewActionVisitor(
            CardsTableChain cardsTableChain,
            PassphraseHolderService passphraseHolderService,
            KeyHolderService keyHolderService,
            PasswordTypeEnum passwordType)
        {
            _cardsTableChain = cardsTableChain;
            _passphraseHolderService = passphraseHolderService;
            _keyHolderService = keyHolderService;
            _passwordType = passwordType;
        }

        public void Visit(SitePreviewViewModel sitePreviewViewModel)
        {
            if (sitePreviewViewModel.IsDecrypted)
            {
                System.Windows.Forms.Clipboard.SetText(sitePreviewViewModel.Password);
            }
            else
            {
                var data = _cardsTableChain.SiteCardsTable.Select(sitePreviewViewModel.ID);
                var secretData = DecryptService.DecryptData<SiteEncryptedData, SiteSecretData>(data, _keyHolderService, _passphraseHolderService);

                if (secretData == null)
                    return;

                System.Windows.Forms.Clipboard.SetText(secretData.Password);
            }
        }

        public void Visit(NotePreviewViewModel notePreviewViewModel)
        {
            throw new NotImplementedException(); // there is no password fot Note
        }

        public void Visit(DevicePreviewViewModel devicePreviewViewModel)
        {
            if (devicePreviewViewModel.IsDecrypted)
            {
                System.Windows.Forms.Clipboard.SetText(devicePreviewViewModel.Password);
            }
            else
            {
                var data = _cardsTableChain.DeviceCardsTable.Select(devicePreviewViewModel.ID);
                var secretData = DecryptService.DecryptData<DeviceEncryptedData, DeviceSecretData>(data, _keyHolderService, _passphraseHolderService);
                System.Windows.Forms.Clipboard.SetText(secretData.Password);
            }
        }

        public void Visit(DatabasePreviewViewModel previewViewModel)
        {
            if (previewViewModel.IsDecrypted)
            {
                System.Windows.Forms.Clipboard.SetText(previewViewModel.Password);
            }
            else
            {
                var data = _cardsTableChain.DatabaseCardsTable.Select(previewViewModel.ID);
                var secretData = DecryptService.DecryptData<DatabaseEncryptedData, DatabaseSecretData>(data, _keyHolderService, _passphraseHolderService);
                System.Windows.Forms.Clipboard.SetText(secretData.Password);
            }
        }

        public void Visit(CreditCardPreviewViewModel previewViewModel)
        {
            if (previewViewModel.IsDecrypted)
            {
                System.Windows.Forms.Clipboard.SetText(previewViewModel.CVV);
            }
            else
            {
                var data = _cardsTableChain.CreditCardsTable.Select(previewViewModel.ID);
                var secretData = DecryptService.DecryptData<CreditCardEncryptedData, CreditCardSecretData>(data, _keyHolderService, _passphraseHolderService);
                System.Windows.Forms.Clipboard.SetText(secretData.CVV);
            }
        }
    }
}
