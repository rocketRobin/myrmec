// <copyright file="Record.cs" company="Rocket Robin">
// Copyright (c) Rocket Robin. All rights reserved.
// Licensed under the Apache v2 license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Myrmec
{
    /// <summary>
    /// Present one record.
    /// </summary>
    public class Record
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Record"/> class.
        /// </summary>
        public Record()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Record"/> class.
        /// </summary>
        /// <param name="extentions">extentions string ,split with "," what if it has many.</param>
        /// <param name="hex">hex string, split with ",".</param>
        /// <param name="offset">the file head offset, default is 0.</param>
        /// <param name="description">description for this format.</param>
        public Record(string extentions, string hex, int offset = 0, string description = null)
        {
            Extentions = extentions;
            Offset = offset;
            Hex = hex;
            Description = description;
        }

        /// <summary>
        /// Gets or sets Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets file extentions.
        /// </summary>
        public string Extentions { get; set; }

        /// <summary>
        /// Gets or sets Hex String.
        /// </summary>
        public string Hex { get; set; }

        /// <summary>
        /// Gets or sets offset
        /// </summary>
        public int Offset { get; set; }
    }
}
