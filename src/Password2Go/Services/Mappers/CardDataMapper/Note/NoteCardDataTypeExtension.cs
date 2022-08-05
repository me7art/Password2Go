using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Repository.PrivateCards.Note;
using Password2Go.Data;
using Password2Go.Modules.PrivateCard;
using Password2Go.Modules.PrivateCardList;
using Password2Go.Modules.Preview;

namespace Password2Go.Services.Mappers.CardDataMapper.Note
{
    public static class NoteCardDataTypeExtension
    {
        public static PrivateCardListViewModel MapToListItem(this NoteCardDataType data)
        {
            return new NoteCardListViewModel()
            {
                CardType = PrivateCardTypeEnum.Note,
                ID = data.ID,
                CardName = $"<html><b>{data.Title}</b>\n<size=7>note",
                CardImage = Password2Go.Properties.Resources.if_page_white_text_36305_32x32, // if_white_note_49638,
                Title = data.Title,
                IsSSHTerminalEnabled = false,
                CategoryID = data.CategoryID
            };
        }

        public static NoteCardPublicViewModel MapToPublicItem(this NoteCardDataType data)
        {
            return new NoteCardPublicViewModel()
            {
                ID = data.ID,
                CardType = PrivateCardTypeEnum.None,
                Title = data.Title,
                CreatedDate = data.CreatedDate,
                CategoryID = data.CategoryID
            };
        }

        public static NotePreviewViewModel MapToPreview(this NoteCardDataType data)
        {
            return MapToPreview(data, null);
        }

        public static NotePreviewViewModel MapToPreview(this NoteCardDataType data, NoteSecretData secretData)
        {
            var viewModel = new NotePreviewViewModel()
            {
                IsDecrypted = false,
                ID = data.ID,
                Title = data.Title,
            };

            if (secretData != null)
            {
                viewModel.IsDecrypted = true;
                viewModel.PrivateNote = secretData.Note;
            }

            return viewModel;
        }
    }
}
