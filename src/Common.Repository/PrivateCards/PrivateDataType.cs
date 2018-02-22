using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository.PrivateCards
{
    public class BaseEncryptedData
    {
        //public byte[] SecretBytes;
        public string SecretBytes; // armored bytes
        public string KeyID;
    }

    public class SiteEncryptedData : BaseEncryptedData
    {
    }

    public class NoteEncryptedData : BaseEncryptedData
    {
    }

    public class DeviceEncryptedData : BaseEncryptedData
    {
    }

    public class DatabaseEncryptedData : BaseEncryptedData
    {
    }

    public class CreditCardEncryptedData : BaseEncryptedData
    {
    }

    // TODO:
    // public class ImageEncryptedData :  BaseEncryptedData
    //{
    //}
    //public class DocumentEncryptedData : BaseEncryptedData
    //{
    //}
    //// //
}
