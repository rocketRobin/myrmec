// <copyright file="FileTypes.cs" company="Rocket Robin">
// Copyright (c) Rocket Robin. All rights reserved.
// Licensed under the Apache v2 license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

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
                new Record("jpg,jpeg", "ff,d8,ff,db"),
                new Record("png", "89,50,4e,47,0d,0a,1a,0a"),
                new Record("zip,jar,odt,ods,odp,docx,xlsx,pptx,vsdx,apk,aar", "50,4b,03,04"),
                new Record("zip,jar,odt,ods,odp,docx,xlsx,pptx,vsdx,apk,aar", "50,4b,07,08"),
                new Record("zip,jar,odt,ods,odp,docx,xlsx,pptx,vsdx,apk,aar", "50,4b,05,06"),
                new Record("rar", "52,61,72,21,1a,07,00"),
                new Record("rar", "52,61,72,21,1a,07,01,00"),
                new Record("class", "CA FE BA BE"),
                new Record("pdf", "25 50 44 46"),
                new Record("rpm", "ed ab ee db"),
                new Record("bin", "53 50 30 31"),
                new Record("ico", "00 00 01 00"),
                new Record("z,tar.z", "1F 9D"),
                new Record("z,tar.z", "1F A0"),
                new Record("bac", "42 41 43 4B 4D 49 4B 45 44 49 53 4B"),
                new Record("bz2", "42 5A 68"),
                new Record("gif", "47 49 46 38 37 61"),
                new Record("gif", "47 49 46 38 39 61"),
                new Record("tif tiff", "49 49 2A 00"),
                new Record("tif tiff", "4D 4D 00 2A"),
                new Record("cr2", "49 49 2A 00 10 00 00 00 43 52"),
                new Record("cin", "80 2A 5F D7"),
                new Record("exr", "76 2F 31 01"),
                new Record("dpx", "53 44 50 58"),
                new Record("dpx", "58 50 44 53"),
                new Record("bpg", "42 50 47 FB"),
                new Record("lz", "4C 5A 49 50"),
                new Record("exe", "4D 5A"),
                new Record("ps", "25 21 50 53"),
                new Record("asf wma wmv", "30 26 B2 75 8E 66 CF 11 A6 D9 00 AA 00 62 CE 6C"),
                new Record("ogg oga ogv", "4F 67 67 53"),
                new Record("psd", "38 42 50 53"),
                new Record("mp3", "FF FB"),
                new Record("mp3", "49 44 33"),
                new Record("bmp dib", "42 4D"),
                new Record("fits", "3D 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 54"),
                new Record("flac", "66 4C 61 43"),
                new Record("mid midi", "4D 54 68 64"),
                new Record("doc xls ppt msg", "D0 CF 11 E0 A1 B1 1A E1"),
                new Record("dex", "64 65 78 0A 30 33 35 00"),
                new Record("vmdk", "4B 44 4D"),
                new Record("crx", "43 72 32 34"),
                new Record("cwk", "05 07 00 00 42 4F 42 4F 05 07 00 00 00 00 00 00 00 00 00 00 00 01"),
                new Record("fh8", "41 47 44 33"),
                new Record("cwk", "06 07 E1 00 42 4F 42 4F 06 07 E1 00 00 00 00 00 00 00 00 00 00 01"),
                new Record("toast", "45 52 02 00 00 00"),
                new Record("toast", "8B 45 52 02 00 00 00"),
                new Record("dmg", "78 01 73 0D 62 62 60"),
                new Record("xar", "78 61 72 21"),
                new Record("dat", "50 4D 4F 43 43 4D 4F 43"),
                new Record("nes", "4E 45 53 1A"),
                new Record("tox", "74 6F 78 33"),
                new Record("MLV", "4D 4C 56 49"),
                new Record("7z", "37 7A BC AF 27 1C"),
                new Record("gz tar.gz", "1F 8B"),
                new Record("xz tar.xz", "FD 37 7A 58 5A 00 00"),
                new Record("lz4", "04 22 4D 18"),
                new Record("cab", "4D 53 43 46"),
                new Record("flif", "46 4C 49 46"),
                new Record("mkv mka mks mk3d webm", "1A 45 DF A3"),
                new Record("stg", "4D 49 4C 20"),
                new Record("der", "30 82"),
                new Record("woff", "77 4F 46 46"),
                new Record("woff2", "77 4F 46 32"),
                new Record("XML", "3c 3f 78 6d 6c 20"),
                new Record("wasm", "00 61 73 6d"),
                new Record("lep", "cf 84 01"),
                new Record("swf", "43 57 53"),
                new Record("swf", "46 57 53"),
                new Record("deb", "21 3C 61 72 63 68 3E"),
                new Record("rtf", "7B 5C 72 74 66 31"),
                new Record("m2p vob", "00 00 01 BA"),
                new Record("mpg mpeg", "00 00 01 BA"),
                new Record("mpg mpeg", "47"),
                new Record("mpg mpeg", "00 00 01 B3"),
                new Record("zlib", "78 01"),
                new Record("zlib", "78 9c"),
                new Record("zlib", "78 da"),
                new Record("lzfse", "62 76 78 32"),
                new Record("orc", "4F 52 43"),
                new Record("avro", "4F 62 6A 01"),
                new Record("rc", "53 45 51 36"),

                // Complex file type.
                new Record("PDB", "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00", 11),
                new Record("3gp 3g2", "66 74 79 70 33 67", 4),
                new Record("iso", "43 44 30 30 31", 32769),
                new Record("iso", "43 44 30 30 31", 34817),
                new Record("iso", "43 44 30 30 31", 36865),
                new Record("tar", "75 73 74 61 72", 257),
            };
        }

        /// <summary>
        /// Gets CommonFileTypes
        /// </summary>
        public static List<Record> CommonFileTypes { get; private set; }
    }
}