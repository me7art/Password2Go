using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Repository.PrivateCards;
using Common.Repository.PrivateCards.Device;
using Common.Helpers;
using Password2Go.Modules.PrivateCard;
using Password2Go.Modules.PrivateCardList;
using Password2Go.Data;
using Password2Go.Services.Holders;
using Password2Go.Modules.Preview;

namespace Password2Go.Services.Mappers.CardDataMapper.Device
{
    public class DeviceCardDataMapper : BaseCardDataMapper<DeviceEncryptedData>
    {
        public DeviceCardDataMapper(KeyHolderService keyHolderService) : base(keyHolderService)
        {
        }

        public DeviceCardDataType Map(DeviceCardPublicViewModel publicVM, DeviceCardPrivateViewModel privateVM, DateTime createdDate)
        {
            var result = new DeviceCardDataType()
            {
                CategoryID = publicVM.CategoryID, 
                CreatedDate = createdDate,
                ModifiedDate = DateTime.Now,
                Login = publicVM.Login,
                PublicComment = publicVM.CommentPublic,
                Address = publicVM.Address,
                Port = publicVM.Port,
                Title = publicVM.Title
            };

            ApplySecret(result, 
                SerializationString.SerializeToString(
                    MapToSecretData(privateVM)));

            if (publicVM.ID >= 0) result.ID = publicVM.ID;

            return result;
        }

        DeviceSecretData MapToSecretData(DeviceCardPrivateViewModel priv)
        {
            DeviceSecretData cardSecretData = new DeviceSecretData()
            {
                Password = priv.Password,
                Comment = priv.CommentProtected
            };

            return cardSecretData;
        }
    }




}
