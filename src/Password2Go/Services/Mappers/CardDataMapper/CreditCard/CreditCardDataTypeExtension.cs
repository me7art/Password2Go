using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Repository.PrivateCards.CreditCard;
using Password2Go.Data;
using Password2Go.Modules.PrivateCard;
using Password2Go.Modules.PrivateCardList;
using Password2Go.Modules.Preview;

namespace Password2Go.Services.Mappers.CardDataMapper.CreditCard
{
    public static class CreditCardDataTypeExtension
    {
        public static PrivateCardListViewModel MapToListItem(this CreditCardDataType data)
        {
            return new CreditCardListViewModel()
            {
                CardType = PrivateCardTypeEnum.CreditCard,
                ID = data.ID, //.ToString(),
                CardName = $"<html><b> {data.Title}</b>\n<size=7>  {data.Bank}\n<size=7>  **** **** **** {data.Last4Digit}",
                CardImage = Password2Go.Properties.Resources.if_credit_card_49367_32x32, // .if_database_35948_32x32, // .if_gnome_fs_server_21123,
                Title = data.Title,
                IsSSHTerminalEnabled = false
            };
        }

        public static CreditCardPublicViewModel MapToPublicItem(this CreditCardDataType data /*, TreeViewModel treeViewModel*/)
        {
            return new CreditCardPublicViewModel()
            {
                ID = data.ID,
                CardType = PrivateCardTypeEnum.CreditCard,
                CategoryID = data.CategoryID,
                Title = data.Title,
                CommentPublic = data.PublicComment,
                CreatedDate = data.CreatedDate,
                Bank = data.Bank,
                Last4Digit = data.Last4Digit
            };
        }

        public static CreditCardPreviewViewModel MapToPreview(this CreditCardDataType data)
        {
            return MapToPreview(data, null);
        }


        public static CreditCardPreviewViewModel MapToPreview(this CreditCardDataType data, CreditCardSecretData secretData)
        {
            var viewModel = new CreditCardPreviewViewModel()
            {
                IsDecrypted = false,
                ID = data.ID,
                Title = data.Title,
                Bank = data.Bank,
                Last4Digits = data.Last4Digit
            };

            if (secretData != null)
            {
                viewModel.IsDecrypted = true;
                viewModel.CVV = secretData.CVV;
                viewModel.Holder = secretData.Holder;
                viewModel.Number = secretData.Number;
                viewModel.ValidTill = secretData.ValidTill;
                viewModel.Pin = secretData.Pin;
            }

            return viewModel;
        }
    }
}
