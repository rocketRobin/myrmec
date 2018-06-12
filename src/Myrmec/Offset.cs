// <copyright file="Offset.cs" company="Rocket Robin">
// Copyright (c) Rocket Robin. All rights reserved.
// Licensed under the Apache v2 license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Myrmec
{
    /// <summary>
    /// Representing a section of offset.
    /// </summary>
    public class Offset
    {
        /// <summary>
        /// Gets or sets the count of data array.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the start position of data array.
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// Gets or sets the AscII string corresponding to the binary value of this data
        /// </summary>
        public string Value { get; set; }
    }
}