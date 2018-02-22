using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password2Go.Data.Configs
{
    public class KeysConfig
    {
        public List<KeysPathConfig> Keys = new List<KeysPathConfig>();
    }

    public class KeysPathConfig
    {
        public string PublicKeyPath;
        public string PrivateKeyPath;
        public string KeyID;
    }
}
