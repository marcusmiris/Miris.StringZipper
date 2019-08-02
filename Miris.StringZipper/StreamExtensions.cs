#if NET20
using System.IO;

namespace Miris.StringZipper
{
    public static class StreamExtensions
    {
        public static void CopyTo(
            this Stream source,
            Stream destination)
        {
            byte[] buffer = new byte[32768];
            int read;
            while ((read = source.Read(buffer, 0, buffer.Length)) > 0)
            {
                destination.Write(buffer, 0, read);
            }
        }
    }
}
#endif