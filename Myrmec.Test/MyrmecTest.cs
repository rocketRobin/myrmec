using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Myrmec.Test
{
    [TestClass]
    public class MyrmecTest
    {
        private Sniffer _sniffer;

        public MyrmecTest()
        {
            _sniffer = new Sniffer();
            _sniffer.Populate(FileTypes.CommonFileTypes);
        }

        [TestMethod]
        public void AddTest()
        {
            var data = new byte[]
            {
                0x11,
                0x22,
                0x33
            };
            _sniffer.Add(data, new[] { "what", "file", "type" });

            var result = _sniffer.Match(data);

            Assert.IsTrue(result.Contains("what"));
            Assert.IsTrue(result.Contains("file"));
            Assert.IsTrue(result.Contains("type"));
        }

        [TestMethod]
        public void FindAllTest()
        {
            var data = new byte[]
            {
                0x25,
                0x50,
                0x44,
                0x46,
                0x11
            };

            _sniffer.Add(data, new[] { "pdfx" });

            var result = _sniffer.Match(data, true);
            Assert.IsTrue(result.Contains("pdf"));
            Assert.IsTrue(result.Contains("pdfx"));
        }

        [TestMethod]
        public void MimeTest()
        {
            var head = new byte[]
            {
                0xff,
                0xd8,
                0xff,
                0xdb
            };

            var result = _sniffer.Match(head);
            var mimeType = MimeTypes.GetMimeType(result.First());
            Assert.IsTrue(mimeType == "image/jpeg");
        }

        [TestMethod]
        public void MultipleTest()
        {
            var dataZip = new byte[]
            {
                0x50,
                0x4b,
                0x03,
                0x04
            };
            var dataZipEmpty = new byte[]
            {
                0x50,
                0x4b,
                0x05,
                0x06
            };

            var resultZip = _sniffer.Match(dataZip);
            var resultZipEmpty = _sniffer.Match(dataZipEmpty);

            Assert.IsTrue(resultZip.Contains("zip"));
            Assert.IsTrue(resultZip.Contains("docx"));
            Assert.IsTrue(resultZip.Contains("apk"));

            Assert.IsTrue(resultZipEmpty.Contains("zip"));
            Assert.IsTrue(resultZipEmpty.Contains("docx"));
            Assert.IsTrue(resultZipEmpty.Contains("apk"));
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod]
        public void OverlapTest()
        {
            var data = new byte[]
            {
                0xff,
                0xd8,
                0xff,
                0xdb
            };
            _sniffer.Add(data, new[] { "jpegx" });

            var result = _sniffer.Match(data);

            Assert.IsTrue(result.Contains("jpg"));
            Assert.IsTrue(result.Contains("jpeg"));
            Assert.IsTrue(result.Contains("jpegx"));
        }

        [TestMethod]
        public void SnifferTest()
        {
            var head = new byte[]
            {
                0xff,
                0xd8,
                0xff,
                0xdb
            };

            var result = _sniffer.Match(head);

            Assert.IsTrue(result.Contains("jpg"));
            Assert.IsTrue(result.Contains("jpeg"));
        }
    }
}