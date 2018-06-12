
using Myrmec.Mime;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Myrmec.Mime.Test
{

    public class MimeTypesTest
    {
        [Fact]
        public void DotTest()
        {
            var extension = ".jpg";
            var result = MimeType.GetMimeType(extension);
            Assert.Equal("image/jpeg", result);
        }

        [Fact]
        public void RegularTest()
        {
            var extension = "jpg";
            var result = MimeType.GetMimeType(extension);
            Assert.Equal("image/jpeg", result);
        }
    }
}
