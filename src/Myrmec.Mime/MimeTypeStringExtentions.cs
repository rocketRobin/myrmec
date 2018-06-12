using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myrmec.Mime
{
    public static class MimeTypeStringExtentions
    {

        /// <summary>
        /// Gets the MIME-type of the file based on the file extension.
        /// </summary>
        /// <returns>The MIME-type.</returns>
        /// <param name="extention">The file name extention.</param>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="extention"/> is <c>null</c>.
        /// </exception>
        public static string MimeType(this string extention)
        {
            return Mime.MimeType.GetMimeType(extention);
        }
    }
}
