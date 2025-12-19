using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

using Common.Helpers;

namespace Common.Repository
{
    public interface ICommonXML<T>
    {
        T Read();
        void Write(T dataObject);
        bool IsEmpty();
    }

    public class CommonXMLAdapter<T> : ICommonXML<T>
    {
        readonly string _fileName;

        public CommonXMLAdapter(string fileName)
        {
            _fileName = fileName;
        }

        public T Read()
        {
            return SerializationFile.DeSerializeObject<T>(_fileName);
        }

        public void Write(T xml)
        {
            SerializationFile.SerializeObject(xml, _fileName);
        }

        public bool IsEmpty()
        {
            return File.Exists(_fileName) == false;
        }
    }
}
