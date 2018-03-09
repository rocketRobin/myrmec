// <copyright file="MyrmecTest.cs" company="Rocket Robin">
// Copyright (c) Rocket Robin. All rights reserved.
// Licensed under the Apache v2 license. See LICENSE file in the project root for full license information.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Myrmec.Test
{
    [TestClass]
    public class MyrmecTest
    {
        [TestMethod]
        public void AddTest()
        {
            var sniffer = new Sniffer();

            var data = new byte[]
            {
                0x11,
                0x22,
                0x33
            };
            sniffer.Add(data, new[] { "what", "file", "type" });

            var result = sniffer.Match(data);

            Assert.IsTrue(result.Contains("what"));
            Assert.IsTrue(result.Contains("file"));
            Assert.IsTrue(result.Contains("type"));
        }

        [TestMethod]
        public void ComplexFileTypeTest()
        {
            var sniffer = new Sniffer();

            Record record = new Record()
            {
                Extentions = "a,b,c",
                Hex = "0x11 0x22 ?? ?? ?? 0x33",
                Offset = 2
            };

            sniffer.Add(record);
            var data = new byte[]
            {
                0x11, 0x11, 0x11, 0x22, 0xff, 0xdd, 0x1d, 0x33
            };
            var result = sniffer.Match(data);

            Assert.IsTrue(result.Contains("a"));
            Assert.IsTrue(result.Contains("b"));
            Assert.IsTrue(result.Contains("c"));
        }

        [TestMethod]
        public void ComplextJpgTest()
        {
            var sniffer = new Sniffer();
            sniffer.Populate(FileTypes.Common);

            var data = new byte[]
            {
                0xff, 0xd8, 0xff, 0xe0,
                0x66, 0x74, 0x4a, 0x46,
                0x49, 0x46, 0x00, 0x01,
            };

            var result = sniffer.Match(data);

            Assert.IsTrue(result.Contains("jpg"));
            Assert.IsTrue(result.Contains("jpeg"));
        }

        [TestMethod]
        public void ComplextJpgTest2()
        {
            var sniffer = new Sniffer();
            sniffer.Populate(FileTypes.Common);

            var data = new byte[]
            {
                0xff, 0xd8, 0xff, 0xe1,
                0x66, 0x74, 0x45, 0x78,
                0x69, 0x66, 0x00, 0x00,
            };

            var result = sniffer.Match(data);

            Assert.IsTrue(result.Contains("jpg"));
            Assert.IsTrue(result.Contains("jpeg"));
        }

        [TestMethod]
        public void FindAllTest()
        {
            var sniffer = new Sniffer();
            sniffer.Populate(FileTypes.Common);
            sniffer.Populate(FileTypes.Unfrequent);

            var data = new byte[]
            {
                0x25,
                0x50,
                0x44,
                0x46,
                0x11
            };

            sniffer.Add(data, new[] { "pdfx" });

            var result = sniffer.Match(data, true);
            Assert.IsTrue(result.Contains("pdf"));
            Assert.IsTrue(result.Contains("pdfx"));
        }

        [TestMethod]
        public void Gp3Test()
        {
            var sniffer = new Sniffer();
            sniffer.Populate(FileTypes.Unfrequent);
            var data = new byte[]
            {
                0x11, 0x11, 0x11, 0x22,
                0x66, 0x74, 0x79, 0x70,
                0x33, 0x67
            };
            var result = sniffer.Match(data);
            Assert.IsTrue(result.Any());
            Assert.IsTrue(result.Contains("3gp"));
            Assert.IsTrue(result.Contains("3g2"));
        }

        [TestMethod]
        public void MimeTest()
        {
            var sniffer = new Sniffer();
            sniffer.Populate(FileTypes.Common);
            sniffer.Populate(FileTypes.Unfrequent);

            var head = new byte[]
            {
                0xff,
                0xd8,
                0xff,
                0xdb
            };

            var result = sniffer.Match(head);
            var mimeType = MimeTypes.GetMimeType(result.First());
            Assert.IsTrue(mimeType == "image/jpeg");
        }

        [TestMethod]
        public void MultipleTest()
        {
            var sniffer = new Sniffer();
            sniffer.Populate(FileTypes.Common);
            sniffer.Populate(FileTypes.Unfrequent);
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

            var resultZip = sniffer.Match(dataZip);
            var resultZipEmpty = sniffer.Match(dataZipEmpty);

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
            var sniffer = new Sniffer();
            sniffer.Populate(FileTypes.Common);
            sniffer.Populate(FileTypes.Unfrequent);

            var data = new byte[]
            {
                0xff,
                0xd8,
                0xff,
                0xdb
            };
            sniffer.Add(data, new[] { "jpegx" });

            var result = sniffer.Match(data);

            Assert.IsTrue(result.Contains("jpg"));
            Assert.IsTrue(result.Contains("jpeg"));
            Assert.IsTrue(result.Contains("jpegx"));
        }

        [TestMethod]
        public void PdbTest()
        {
            var sniffer = new Sniffer();
            sniffer.Populate(FileTypes.Unfrequent);
            var data = new byte[]
            {
                0x11, 0x11, 0x11, 0x22, 0x00,
                0x66, 0x74, 0x79, 0x70, 0x00,
                0x33, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00,
                0x20, 0xff, 0x11, 0x1f, 0x40
            };
            var result = sniffer.Match(data);
            Assert.IsTrue(result.Contains("pdb"));
        }

        [TestMethod]
        public void SnifferTest()
        {
            var sniffer = new Sniffer();
            sniffer.Populate(FileTypes.Common);
            sniffer.Populate(FileTypes.Unfrequent);
            var head = new byte[]
            {
                0xff,
                0xd8,
                0xff,
                0xdb
            };

            var result = sniffer.Match(head);

            Assert.IsTrue(result.Contains("jpg"));
            Assert.IsTrue(result.Contains("jpeg"));
        }


        [TestMethod]
        public void GifTest()
        {
            var sniffer = new Sniffer();
            sniffer.Populate(FileTypes.Common);

            var data = new byte[]
            {
                0x47, 0x49, 0x46, 0x38, 0x39,
                0x61, 0x2c, 0x01, 0xe0, 0x00
            };
            var results = sniffer.Match(data, true);

            Assert.IsTrue(results.Contains("gif"));
        }
    }
}