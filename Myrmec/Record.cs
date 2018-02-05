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
        /// Gets or sets file extentions.
        /// </summary>
        public string Extentions { get; set; }

        /// <summary>
        /// Gets or sets offset
        /// </summary>
        public int Offset { get; set; }

        public string Hex { get; set; }

        public string Description { get; set; }
    }
}
