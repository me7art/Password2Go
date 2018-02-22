using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Password2Go.Data.Configs
{
    [Serializable]
    public class CategoryTreeConfig
    {
        public const string ID_ALL = "id_all";
        public const string ID_RECYCLEBIN = "id_recyclebin";
        public List<CategoryNode> Nodes = new List<CategoryNode>();
    }

    [Serializable]
    public class CategoryNode
    {
        [XmlAttribute("id")]
        public string ID { get; set; }

        // [XmlAttribute("iconname")]
        // @@@ TODO : public string IconName { get; set; }

        public string Name { get; set; }

        public List<CategoryNode> ChildNodes = new List<CategoryNode>();
    }
}
