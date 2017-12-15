using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Miris.StringZipper
{
    public static class ZipExtensions
    {

        public static byte[] Zip(this string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);

            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                    msi.CopyTo(gs);

                return mso.ToArray();
            }
        }

        public static string ZipTo64BasedString(this string str)
            => Convert.ToBase64String(str.Zip());

    }
}
