using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Password2Go.Data;
using Password2Go.Modules.PrivateCard;

namespace Password2Go.Services.Mappers.CardDataMapper.Device
{
    public static class DatabaseSecretDataExtension
    {
        public static DatabaseCardPrivateViewModel MapToDeviceCardPrivateViewModel(this DatabaseSecretData data)
        {
            return new DatabaseCardPrivateViewModel() { Password = data.Password, CommentProtected = data.Comment };
        }
    }
}
