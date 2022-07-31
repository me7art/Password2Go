using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Repository.PrivateCards.Site;
using Password2Go.Data;
using Password2Go.Modules.PrivateCard;
using Password2Go.Modules.PrivateCardList;
using Password2Go.Modules.Preview;

using Password2Go.Services.Images;

namespace Password2Go.Services.Mappers.CardDataMapper.Site
{
    public static class SiteCardDataTypeExtension
    {
        static public LoadImageService ImageService;

        public static PrivateCardListViewModel MapToListItem(this SiteCardDataType data)
        {
            StringBuilder cardName = new StringBuilder();
            cardName.Append($"<html><b> {data.Title}</b>");
            if (!string.IsNullOrWhiteSpace(data.Login)) cardName.Append($"\n<size=7> {data.Login}");
            if (!string.IsNullOrWhiteSpace(data.Site)) cardName.Append($"\n<size=7> at <b>{data.Site}</b>");

            System.Drawing.Image image = Password2Go.Properties.Resources.card_chrome_317753;
            if (ImageService != null)
            {
                if (!string.IsNullOrWhiteSpace(data.Site) && ImageService.Exists(data.Site))
                {
                    image = ImageService.GetImage(data.Site).Image;
                }
            }

            return new SiteCardListViewModel()
            {
                CardType = PrivateCardTypeEnum.Site,
                ID = data.ID, //.ToString(),
                //CardName = $"<html><b> {data.Title}</b>\n<size=7> {data.Login}\n at <b>{data.Site}</b>",
                CardName = cardName.ToString(),
                CardImage = image,
                Title = data.Title,
                IsSSHTerminalEnabled = false,
                CategoryID = data.CategoryID
            };
        }

        public static SiteCardPublicViewModel MapToPublicItem(this SiteCardDataType data /*, TreeViewModel treeViewModel*/)
        {
            return new SiteCardPublicViewModel()
            {
                ID = data.ID,
                CardType = PrivateCardTypeEnum.Site,
                Title = data.Title,
                Site = data.Site,
                Login = data.Login,
                CommentPublic = data.PublicComment,
                CreatedDate = data.CreatedDate,
                CategoryID = data.CategoryID
            };
        }

        public static SitePreviewViewModel MapToPreview(this SiteCardDataType data)
        {
            return MapToPreview(data, null);
        }


        public static SitePreviewViewModel MapToPreview(this SiteCardDataType data, SiteSecretData secretData)
        {
            var viewModel = new SitePreviewViewModel()
            {
                IsDecrypted = false,
                ID = data.ID,
                Title = data.Title,
                Login = data.Login,
                Url = data.Site,
                PublicComment = data.PublicComment
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
