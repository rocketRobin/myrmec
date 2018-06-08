using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Myrmec.Test
{
    [TestClass]
    public class MimeTypesTest
    {
        [TestMethod]
        public void DotTest()
        {
            var extension = ".jpg";
            var result = MimeTypes.GetMimeType(extension);
            Assert.AreEqual<string>("image/jpeg", result);
        }

        [TestMethod]
        public void RegularTest()
        {
            var extension = "jpg";
            var result = MimeTypes.GetMimeType(extension);
            Assert.AreEqual<string>("image/jpeg", result);
        }

    }
}
