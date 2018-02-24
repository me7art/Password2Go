using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password2Go.Data.Configs
{
    public class Image
    {
        public string Name;
        public string Filename;
    }

    public class ImagesConfig
    {
        public List<Image> Images = new List<Image>();
    }
}
