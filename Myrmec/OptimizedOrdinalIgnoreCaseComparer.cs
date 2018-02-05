// <copyright file="OptimizedOrdinalIgnoreCaseComparer.cs" company="Rocket Robin">
// Copyright (c) Rocket Robin. All rights reserved.
// Licensed under the Apache v2 license. See LICENSE file in the project root for full license information.
// </copyright>

// This file copied from mimekit repo see https://github.com/jstedfast/MimeKit .
using System;
using System.Collections.Generic;

namespace Myrmec
{
    /// <summary>
    /// An optimized version of <see cref="StringComparer.OrdinalIgnoreCase">StringComparer.OrdinalIgnoreCase</see>.
    /// </summary>
    public class OptimizedOrdinalIgnoreCaseComparer : IEqualityComparer<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OptimizedOrdinalIgnoreCaseComparer"/> class.
        /// </summary>
        public OptimizedOrdinalIgnoreCaseComparer()
        {
        }

        /// <summary>
        /// Compare the input strings for equality.
        /// </summary>
        /// <remarks>
        /// Compares the input strings for equality.
        /// </remarks>
        /// <returns><c>true</c>if <paramref name="x"/> and <paramref name="y"/> refer to the same object,
        /// or <paramref name="x"/> and <paramref name="y"/> are equal,
        /// or <paramref name="x"/> and <paramref name="y"/> are <c>null</c>;
        /// otherwise, <c>false</c>.</returns>
        /// <param name="x">A string to compare to <paramref name="y"/>.</param>
        /// <param name="y">A string to compare to <paramref name="x"/>.</param>
        public bool Equals(string x, string y)
        {
            if (x.Length != y.Length)
            {
                return false;
            }

            for (int i = 0; i < x.Length; i++)
            {
                if (ToUpper(x[i]) != ToUpper(y[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Get the hash code for the specified string.
        /// </summary>
        /// <returns>A 32-bit signed hash code calculated from the value of the <paramref name="obj"/> parameter.</returns>
        /// <param name="obj">The string.</param>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="obj"/> is <c>null</c>.
        /// </exception>
        public int GetHashCode(string obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            unsafe
            {
                unchecked
                {
                    fixed (char* src = obj)
                    {
                        int hash1 = 5381;
                        int hash2 = hash1;
                        char* s = src;
                        int c;

                        while ((c = s[0]) != 0)
                        {
                            hash1 = ((hash1 << 5) + hash1) ^ ToUpper(c);

                            if ((c = s[1]) == 0)
                            {
                                break;
                            }

                            hash2 = ((hash2 << 5) + hash2) ^ ToUpper(c);
                            s += 2;
                        }

                        return hash1 + (hash2 * 1566083941);
                    }
                }
            }
        }

        private static int ToUpper(int c)
        {
            if (c >= 0x61 && c <= 0x7A)
            {
                return c - 0x20;
            }

            return c;
        }
    }
}
