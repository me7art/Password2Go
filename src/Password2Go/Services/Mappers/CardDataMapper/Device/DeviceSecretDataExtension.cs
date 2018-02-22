using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Password2Go.Data;
using Password2Go.Modules.PrivateCard;

namespace Password2Go.Services.Mappers.CardDataMapper.Device
{
    public static class DeviceSecretDataExtension
    {
        public static DeviceCardPrivateViewModel MapToDeviceCardPrivateViewModel(this DeviceSecretData data)
        {
            return new DeviceCardPrivateViewModel() { Password = data.Password, CommentProtected = data.Comment };
        }
    }
}
