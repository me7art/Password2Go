using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CryptoLibrary.BountyCastleFacade;
using Common.Repository.PrivateCards;
using Common.Repository.PrivateCards.Site;
using Common.Helpers;
using Password2Go.Services.Holders;

namespace Password2Go.Services.Mappers.CardDataMapper
{
    abstract public class BaseCardDataMapper<T>
        where T : BaseEncryptedData, new()
    {
        KeyHolderService _keyHolderService;

        public BaseCardDataMapper(KeyHolderService keyHolderService)
        {
            _keyHolderService = keyHolderService;
        }

        protected void ApplySecret(IBaseCardData baseCard, string secretString)
        {
            EncryptFacade encrypt = new EncryptFacade(_keyHolderService.GetPublicKey());
            encrypt.Init();

            var siteSecret = new T() /*SiteEncryptedData()*/
            {
                SecretBytes = System.Text.Encoding.UTF8.GetString(encrypt.Encrypt(Encoding.UTF8.GetBytes(secretString))),
                KeyID = encrypt.PublicKeyID
            };

            baseCard.CardSecret = SerializationString.SerializeToString(siteSecret);
        }
    }
}
