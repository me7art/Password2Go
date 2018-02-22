using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Repository.PrivateCards;
using Common.Repository.PrivateCards.Site;
using Common.Helpers;
using Password2Go.Modules.PrivateCard;
using Password2Go.Modules.PrivateCardList;
using Password2Go.Data;
using Password2Go.Services.Holders;
using Password2Go.Modules.Preview;

namespace Password2Go.Services.Mappers.CardDataMapper.Site
{
    public class SiteCardDataMapper : BaseCardDataMapper<SiteEncryptedData>
    {
        public SiteCardDataMapper(KeyHolderService keyHolderService) : base(keyHolderService)
        {
        }

        public SiteCardDataType Map(SiteCardPublicViewModel publicVM, SiteCardPrivateViewModel privateVM, DateTime createdDate)
        {
            var result = new SiteCardDataType()
            {
                CategoryID = publicVM.CategoryID, // .CategoryNode?.NodeID ?? "id_all",
                CreatedDate = createdDate,
                ModifiedDate = DateTime.Now,
                Login = publicVM.Login,
                PublicComment = publicVM.CommentPublic,
                Site = publicVM.Site,
                Title = publicVM.Title
            };

            ApplySecret(result, 
                SerializationString.SerializeToString(
                    MapToSecretData(privateVM)));

            if (publicVM.ID >= 0) result.ID = publicVM.ID;

            return result;
        }

        SiteSecretData MapToSecretData(SiteCardPrivateViewModel priv)
        {
            SiteSecretData siteSecretData = new SiteSecretData()
            {
                Password = priv.Password,
                Comment = priv.CommentProtected
            };

            return siteSecretData;
        }
    }




}
