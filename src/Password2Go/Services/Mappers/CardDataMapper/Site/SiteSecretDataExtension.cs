using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Password2Go.Data;
using Password2Go.Modules.PrivateCard;

namespace Password2Go.Services.Mappers.CardDataMapper.Site
{
    public static class SiteSecretDataExtension
    {
        public static SiteCardPrivateViewModel MapToSiteCardPrivateViewModel(this SiteSecretData data)
        {
            return new SiteCardPrivateViewModel() { Password = data.Password, CommentProtected = data.Comment };
        }
    }
}
