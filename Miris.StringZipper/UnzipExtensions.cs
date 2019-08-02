using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Miris.StringZipper
{
    public static class UnzipExtensions
    {

        public static string Unzip64BasedString(this string str) 
            => Convert.FromBase64String(str).UnzipString();

        public static string UnzipString(this byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                    gs.CopyTo(mso);

                var array = mso.ToArray();

                return Encoding.UTF8.GetString(array, 0, array.Length);
            }
        }

    }
}
