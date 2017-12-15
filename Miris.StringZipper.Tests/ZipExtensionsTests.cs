using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Miris.StringZipper.Tests
{
    [TestClass]
    public class ZipExtensionsTests
    {
        [TestMethod]
        public void CompressionAndDecompressionTest()
        {
            var candidate = new Func<int, string>(size =>
            {
                var random = new Random(Seed: size);
                return new string(
                    Enumerable.Range(1, size)
                    .Select(idx => (char) random.Next('A', 'Z'))
                    .ToArray());
            })(1000);

            var zipped = candidate.ZipTo64BasedString();

            Assert.IsTrue(zipped.Length < candidate.Length, "Parece que não compactou");
            Assert.AreEqual(candidate, zipped.Unzip64BasedString());

        }
    }
}
