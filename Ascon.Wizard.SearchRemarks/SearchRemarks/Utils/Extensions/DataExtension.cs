using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SearchRemarks.Utils.Extensions
{
    public static class DataExtension
    {
        public static byte[] StringToBytes(this string source)
        {
            return Encoding.Default.GetBytes(source);
        }

        public static string BytesToString(this byte[] source)
        {
            return Encoding.UTF8.GetString(source);
        }

        public static byte[] Base64ToString(this string source)
        {
            return Convert.FromBase64String(source);
        }

        public static Stream StringToStream(this string source)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(source);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
