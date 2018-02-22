using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Repository.PrivateCards;
using Common.Repository.PrivateCards.DataBase;
using Common.Helpers;
using Password2Go.Modules.PrivateCard;
using Password2Go.Modules.PrivateCardList;
using Password2Go.Data;
using Password2Go.Services.Holders;
using Password2Go.Modules.Preview;

namespace Password2Go.Services.Mappers.CardDataMapper.DataBase
{
    public class DatabaseCardDataMapper : BaseCardDataMapper<DatabaseEncryptedData>
    {
        public DatabaseCardDataMapper(KeyHolderService keyHolderService) : base(keyHolderService)
        {
        }

        public DatabaseCardDataType Map(DatabaseCardPublicViewModel publicVM, DatabaseCardPrivateViewModel privateVM, DateTime createdDate)
        {
            var result = new DatabaseCardDataType()
            {
                CategoryID = publicVM.CategoryID, 
                CreatedDate = createdDate,
                ModifiedDate = DateTime.Now,
                Login = publicVM.Login,
                PublicComment = publicVM.CommentPublic,
                Address = publicVM.Address,
                Port = publicVM.Port,
                Title = publicVM.Title,
                DatabaseName = publicVM.DatabaseName
            };

            ApplySecret(result, 
                SerializationString.SerializeToString(
                    MapToSecretData(privateVM)));

            if (publicVM.ID >= 0) result.ID = publicVM.ID;

            return result;
        }

        DatabaseSecretData MapToSecretData(DatabaseCardPrivateViewModel priv)
        {
            DatabaseSecretData cardSecretData = new DatabaseSecretData()
            {
                Password = priv.Password,
                Comment = priv.CommentProtected
            };

            return cardSecretData;
        }
    }




}
