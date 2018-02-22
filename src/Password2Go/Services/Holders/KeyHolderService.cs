using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using Password2Go.Data.Configs;

namespace Password2Go.Services.Holders
{
    public class KeyHolderService
    {
        KeysConfig _keysConfig;

        public KeyHolderService Init(KeysConfig keysConfig)
        {
            _keysConfig = keysConfig;
            return this;
        }

        public byte[] GetPublicKey()
        {
            return File.ReadAllBytes(_keysConfig.Keys.First().PublicKeyPath);
        }

        public byte[] GetPrivateKey(string id)
        {
            return File.ReadAllBytes(_keysConfig.Keys.First().PrivateKeyPath);
        }
    }
}
