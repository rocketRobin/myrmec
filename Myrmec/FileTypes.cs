// <copyright file="FileTypes.cs" company="Rocket Robin">
// Copyright (c) Rocket Robin. All rights reserved.
// Licensed under the Apache v2 license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace Myrmec
{
    /// <summary>
    /// Common file types for populate a new sniffer instance.
    /// </summary>
    public class FileTypes
    {
        static FileTypes()
        {
            CommonFileTypes = new List<Record>
            {
                new Record ("jpg,jpeg", "ff,d8,ff,db"),
                new Record("png", "89,50,4e,47,0d,0a,1a,0a")
            };
        }

        /// <summary>
        /// Gets CommonFileTypes
        /// </summary>
        public static List<Record> CommonFileTypes { get; private set; }
    }
}
