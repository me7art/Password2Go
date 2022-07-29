using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Repository.PrivateCards.DataBase;
using Password2Go.Data;
using Password2Go.Modules.PrivateCard;
using Password2Go.Modules.PrivateCardList;
using Password2Go.Modules.Preview;

namespace Password2Go.Services.Mappers.CardDataMapper.DataBase
{
    public static class DatabaseCardDataTypeExtension
    {
        public static PrivateCardListViewModel MapToListItem(this DatabaseCardDataType data)
        {
            return new DatabaseCardListViewModel()
            {
                CardType = PrivateCardTypeEnum.Database,
                ID = data.ID, //.ToString(),
                CardName = $"<html><b> {data.Title}</b>\n<size=7> {data.DatabaseName} at {data.Address}",
                CardImage = Password2Go.Properties.Resources.if_database_35948_32x32, // .if_gnome_fs_server_21123,
                Title = data.Title,
                IsSSHTerminalEnabled = false
            };
        }

        public static DatabaseCardPublicViewModel MapToPublicItem(this DatabaseCardDataType data /*, TreeViewModel treeViewModel*/)
        {
            return new DatabaseCardPublicViewModel()
            {
                ID = data.ID,
                CardType = PrivateCardTypeEnum.Database,
                Title = data.Title,
                Address = data.Address,
                Port = data.Port,
                Login = data.Login,
                CommentPublic = data.PublicComment,
                CreatedDate = data.CreatedDate,
                CategoryID = data.CategoryID,
                DatabaseName = data.DatabaseName
            };
        }

        public static DatabasePreviewViewModel MapToPreview(this DatabaseCardDataType data)
        {
            return MapToPreview(data, null);
        }


        public static DatabasePreviewViewModel MapToPreview(this DatabaseCardDataType data, DatabaseSecretData secretData)
        {
            var viewModel = new DatabasePreviewViewModel()
            {
                IsDecrypted = false,
                ID = data.ID,
                Title = data.Title,
                Login = data.Login,
                Address = data.Address,
                Port = data.Port,
                PublicComment = data.PublicComment,
                DatabaseName = data.DatabaseName
            };

            if (secretData != null)
            {
                viewModel.IsDecrypted = true;
                viewModel.Password = secretData.Password;
                viewModel.PrivateComment = secretData.Comment;
            }

            return viewModel;
        }
    }
}
