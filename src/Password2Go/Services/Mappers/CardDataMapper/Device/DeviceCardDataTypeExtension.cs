using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Repository.PrivateCards.Device;
using Password2Go.Data;
using Password2Go.Modules.PrivateCard;
using Password2Go.Modules.PrivateCardList;
using Password2Go.Modules.Preview;
using Password2Go.Modules.CategoryTree;

namespace Password2Go.Services.Mappers.CardDataMapper.Device
{


    public static class DeviceCardDataTypeExtension
    {
        public static PrivateCardListViewModel MapToListItem(this DeviceCardDataType data)
        {
            

            var deviceVM = new DeviceCardListViewModel()
            {
                CardType = PrivateCardTypeEnum.Device,
                ID = data.ID, //.ToString(),
                CardName = $"<html><b> {data.Title}</b>\n<size=7> {data.Login}@{data.Address}:{data.Port}",
                CardImage = Password2Go.Properties.Resources.if_gnome_fs_server_21123,
                Title = data.Title,
                CategoryID = data.CategoryID
            };


            //TODO: Нужно ввести новое свойство к хосту - показать иконку удаленного подключения, и тип удаленного подключения: ssh, rdp, etc
            //TODO: И показывать или нет иконку подключения надо основываясь не на чиселку порта, а на свойство
            //TODO: а так же ввести несколько логинов для хоста, что бы можно было подключаться к хосту с разными логинами
            if (data.Port == "22")
            {
                deviceVM.IsSSHTerminalEnabled = true;
            } else
            {
                deviceVM.IsSSHTerminalEnabled = false;
            }

            if (data.Port == "3128")
            {
                deviceVM.IsRDPEnabled = true;
            } else
            {
                deviceVM.IsRDPEnabled= false;
            }

            return deviceVM;
        }

        public static DeviceCardPublicViewModel MapToPublicItem(this DeviceCardDataType data /*, TreeViewModel treeViewModel*/)
        {
            return new DeviceCardPublicViewModel()
            {
                ID = data.ID,
                CardType = PrivateCardTypeEnum.Device,
                Title = data.Title,
                Address = data.Address,
                Port = data.Port,
                Login = data.Login,
                CommentPublic = data.PublicComment,
                CreatedDate = data.CreatedDate,
                CategoryID = data.CategoryID
            };
        }

        public static DevicePreviewViewModel MapToPreview(this DeviceCardDataType data)
        {
            return MapToPreview(data, null);
        }


        public static DevicePreviewViewModel MapToPreview(this DeviceCardDataType data, DeviceSecretData secretData)
        {
            var viewModel = new DevicePreviewViewModel()
            {
                IsDecrypted = false,
                ID = data.ID,
                Title = data.Title,
                Login = data.Login,
                Address = data.Address,
                Port = data.Port,
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
