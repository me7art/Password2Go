using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Interfaces.Exceptions;
using Common.Helpers;
using Common.Repository.PrivateCards;
using Password2Go.Services.Holders;

namespace Password2Go.Services.Decrypt
{
    public static class DecryptService
    {
        public static TSecretData DecryptData<TEncryptedData, TSecretData>(IBaseCardData noteCardData, KeyHolderService keyHolderService, PassphraseHolderService passphraseHolderService)
            where TEncryptedData : BaseEncryptedData
        {
            var encryptedData = SerializationString.DeSerializeObject<TEncryptedData>(noteCardData.CardSecret);

            var pswd = passphraseHolderService.GetPassword(encryptedData.KeyID);
            if (pswd == null)
            {
                throw new DecryptionCanceledByUserException("Passphrase input canceled");
            }

            var decryptFacade = new CryptoLibrary.BountyCastleFacade.DecryptFacade(
                keyHolderService.GetPrivateKey(encryptedData.KeyID), //  Encoding.UTF8.GetBytes(_privateKey),
                pswd);

            decryptFacade.Init();

            var decryptedString = decryptFacade.Decrypt(Encoding.UTF8.GetBytes(encryptedData.SecretBytes));
            var siteSecretData = SerializationString.DeSerializeObject<TSecretData>(System.Text.Encoding.UTF8.GetString(decryptedString));

            // tell passphrase that all is OK and holder service may store this passphrase for later decryption if needed 
            passphraseHolderService.Ok(encryptedData.KeyID);

            return siteSecretData;
        }
    }
}
