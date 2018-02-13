// <copyright file="Node.cs" company="Rocket Robin">
// Copyright (c) Rocket Robin. All rights reserved.
// Licensed under the Apache v2 license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace Myrmec
{
    /// <summary>
    /// node
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        public Node()
        {
        }

        /// <summary>
        /// Gets or sets children.
        /// </summary>
        public SortedList<byte, Node> Children { get; set; }

        /// <summary>
        /// Gets or sets depth.
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// Gets or sets extentions.
        /// </summary>
        public List<string> Extentions { get; set; }

        /// <summary>
        /// Gets or sets parent node.
        /// </summary>
        public Node Parent { get; set; }
    }
}