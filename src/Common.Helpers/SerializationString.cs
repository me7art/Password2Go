using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Common.Helpers
{
    public class SerializationString
    {
        public static T Clone<T>(T obj)
        {
            string stringObject = SerializeToString(obj);
            T TObject = DeSerializeObject<T>(stringObject);

            return TObject;
        }

        public static string SerializeToString<T>(/* this */ T toSerialize)
        {
            string s_result = string.Empty;

            XmlSerializer xmlSerializer =
                new XmlSerializer(toSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(textWriter))
                {
                    xmlSerializer.Serialize(writer, toSerialize);
                    s_result = textWriter.ToString();
                }
            }

            return s_result;
        }

        public static T DeSerializeObject<T>(string str)
        {
            T t_result = default(T);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (StringReader textReader = new StringReader(str))
            {
                t_result = (T)xmlSerializer.Deserialize(textReader);
            }

            return t_result;
        }
    }
}
