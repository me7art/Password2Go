using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Password2Go.Data
{
    [Serializable]
    [XmlInclude(typeof(SiteSecretData))]
    [XmlInclude(typeof(NoteSecretData))]
    [XmlInclude(typeof(DeviceSecretData))]
    [XmlInclude(typeof(DatabaseSecretData))]
    [XmlInclude(typeof(CreditCardSecretData))]
    public class SecretBase
    {
    }

    [Serializable]
    public class SiteSecretData : SecretBase
    {
        public string Password;
        public string Comment;
    }

    [Serializable]
    public class NoteSecretData : SecretBase
    {
        public string Note;
    }

    [Serializable]
    public class DeviceSecretData : SecretBase
    {
        public string Password;
        public string Comment;
    }

    [Serializable]
    public class DatabaseSecretData : SecretBase
    {
        public string Password;
        public string Comment;
    }

    [Serializable]
    public class CreditCardSecretData : SecretBase
    {
        public string Number;
        public string Holder;
        public string ValidTill; // @@@ TODO: replace by DateTime
        public string CVV;
        public string Pin;
    }
}
