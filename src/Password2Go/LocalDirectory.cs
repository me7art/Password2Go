using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Password2Go
{
    [Serializable]
    public class LocalDirectory
    {
        public string DataDirectory;

        [XmlIgnore]
        public string LogDirectory;

        [XmlIgnore]
        public string LayoutDirectory;

        [XmlIgnore]
        public string TempDirectory;

        [XmlIgnore]
        public string ConfigDirectory;

        public string KeysDirectory;
    }
}
