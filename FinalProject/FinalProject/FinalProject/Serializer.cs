using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Serializer
    {
        public static MemoryStream ToStream(object obj)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);

            return stream;
        }

        public static object FromStream(MemoryStream stream)
        {
            var formatter = new BinaryFormatter();
            stream.Seek(0, SeekOrigin.Begin);

            return formatter.Deserialize(stream);
        }
    }
}
