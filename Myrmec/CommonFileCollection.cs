// <copyright file="CommonFileCollection.cs" company="Rocket Robin">
// Copyright (c) Rocket Robin. All rights reserved.
// Licensed under the Apache v2 license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace Myrmec.CommonFileFormat
{
    public static class CommonFileCollection 
    {
        private static List<Record> _collection;

      

        private void Init()
        {
            Add(new Record("jpg,jpeg", "ff,d8,ff,db"));
            Add(new Record("png", "89,50,4e,47,0d,0a,1a,0a"));
        }
    }
}