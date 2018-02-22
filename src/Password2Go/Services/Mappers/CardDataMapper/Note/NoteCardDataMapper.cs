using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Repository.PrivateCards;
using Common.Repository.PrivateCards.Note;
using Common.Helpers;
using Password2Go.Modules.PrivateCard;
using Password2Go.Modules.PrivateCardList;
using Password2Go.Data;
using Password2Go.Services.Holders;
using Password2Go.Modules.Preview;

namespace Password2Go.Services.Mappers.CardDataMapper.Note
{
    public class NoteCardDataMapper : BaseCardDataMapper<NoteEncryptedData>
    {
        public NoteCardDataMapper(KeyHolderService keyHolderService) : base(keyHolderService)
        {
        }

        public NoteCardDataType Map(NoteCardPublicViewModel publicVM, NoteCardPrivateViewModel privateVM, DateTime createdDate)
        {
            var result = new NoteCardDataType()
            {
                CategoryID = publicVM.CategoryID, // .CategoryNode?.NodeID ?? "id_all",
                CreatedDate = createdDate,
                ModifiedDate = DateTime.Now,
                Title = publicVM.Title
            };

            ApplySecret(result,
                SerializationString.SerializeToString(
                    MapToSecretData(privateVM)));

            if (publicVM.ID >= 0) result.ID = publicVM.ID;

            return result;
        }

        NoteSecretData MapToSecretData(NoteCardPrivateViewModel priv)
        {
            NoteSecretData siteSecretData = new NoteSecretData()
            {
                Note = priv.Note
            };

            return siteSecretData;
        }
    }
}
