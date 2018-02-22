using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Password2Go.Data;
using Password2Go.Modules.PrivateCard;

namespace Password2Go.Services.Mappers.CardDataMapper.CreditCard
{
    public static class CreditCardSecretDataExtension
    {
        public static CreditCardPrivateViewModel MapToCreditcardPrivateViewModel(this CreditCardSecretData data)
        {
            return new CreditCardPrivateViewModel()
            {
                 CVV = data.CVV,
                 Holder = data.Holder,
                 Number = data.Number,
                 ValidTill = data.ValidTill,
                 Pin = data.Pin
            };
        }
    }
}
