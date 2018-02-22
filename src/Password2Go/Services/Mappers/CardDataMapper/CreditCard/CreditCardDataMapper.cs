using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Repository.PrivateCards;
using Common.Repository.PrivateCards.CreditCard;
using Common.Helpers;
using Password2Go.Modules.PrivateCard;
using Password2Go.Data;
using Password2Go.Services.Holders;

namespace Password2Go.Services.Mappers.CardDataMapper.CreditCard
{
    public class CreditCardDataMapper : BaseCardDataMapper<CreditCardEncryptedData>
    {
        public CreditCardDataMapper(KeyHolderService keyHolderService) : base(keyHolderService)
        {
        }

        public CreditCardDataType Map(CreditCardPublicViewModel publicVM, CreditCardPrivateViewModel privateVM, DateTime createdDate)
        {
            var result = new CreditCardDataType()
            {
                CategoryID = publicVM.CategoryID, 
                CreatedDate = createdDate,
                ModifiedDate = DateTime.Now,

                Title = publicVM.Title,
                PublicComment = publicVM.CommentPublic,
                Bank = publicVM.Bank
            };

            if (privateVM.Number.Count() > 4)
            {
                result.Last4Digit = privateVM.Number.Substring(privateVM.Number.Count() - 4);
            }

            ApplySecret(result, 
                SerializationString.SerializeToString(
                    MapToSecretData(privateVM)));

            if (publicVM.ID >= 0) result.ID = publicVM.ID;

            return result;
        }

        CreditCardSecretData MapToSecretData(CreditCardPrivateViewModel priv)
        {
            CreditCardSecretData cardSecretData = new CreditCardSecretData()
            {
                 CVV = priv.CVV,
                 Holder = priv.Holder,
                 Number = priv.Number,
                 ValidTill = priv.ValidTill,
                 Pin = priv.Pin
            };

            return cardSecretData;
        }
    }




}
