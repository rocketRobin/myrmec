// <copyright file="Sniffer.cs" company="Rocket Robin">
// Copyright (c) Rocket Robin. All rights reserved.
// Licensed under the Apache v2 license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;

namespace Myrmec
{
    /// <summary>
    /// sniffer
    /// </summary>
    public class Sniffer
    {
        /// <summary>
        /// You can get the file extention name detail in this wikipedia page.
        /// </summary>
        public const string FileExtentionHelpUrl = "https://en.wikipedia.org/wiki/List_of_file_signatures";

        private Node _root;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sniffer"/> class.
        /// </summary>
        public Sniffer()
        {
            _root = new Node()
            {
                Children = new SortedList<byte, Node>(128),
                Depth = -1,
            };
            ComplexMetadatas = new List<Metadata>(10);
        }

        /// <summary>
        /// Gets or sets ComplexMetadatas.
        /// </summary>
        public List<Metadata> ComplexMetadatas { get; set; }

        /// <summary>
        /// Add a record to matadata tree.
        /// </summary>
        /// <param name="data">file head.</param>
        /// <param name="extentions">file extention list.</param>
        public void Add(byte[] data, string[] extentions)
        {
            Add(data, _root, extentions, 0);
        }
        public void Add(Record record)
        {
            if (record.IsComplexMetadata)
            {
                ComplexMetadatas.Add(record);
            }
            else
            {
                Add(record.Hex.GetByte(), record.Extentions.Split(',', ' '));
            }
        }

        /// <summary>
        /// Find extentions that match the file hex head.
        /// </summary>
        /// <param name="data">file hex head</param>
        /// <param name="matchAll">match all result or only the first.</param>
        /// <returns>matched result</returns>
        public List<string> Match(byte[] data, bool matchAll = false)
        {
            List<string> extentionStore = new List<string>(4);
            Match(data, 0, _root, extentionStore, matchAll);

            if (matchAll || !extentionStore.Any())
            {
                // Match data from complex metadata.
                extentionStore.AddRange(ComplexMetadatas.Match(data, matchAll));
            }

            // Remove repeated extentions.
            if (matchAll && extentionStore.Any())
            {
                extentionStore = extentionStore.Distinct().ToList();
            }

            return extentionStore;
        }

        private void Add(byte[] data, Node parent, string[] extentions, int depth)
        {
            Node current = null;

            if (parent.Children == null)
            {
                parent.Children = new SortedList<byte, Node>(Convert.ToInt32(128 / Math.Pow(2, depth)));
            }

            // if not contains current byte index, create node and put it into children.
            if (!parent.Children.ContainsKey(data[depth]))
            {
                current = new Node
                {
                    Depth = depth,
                    Parent = parent
                };
                parent.Children.Add(data[depth], current);
            }
            else
            {
                if (!parent.Children.TryGetValue(data[depth], out current))
                {
                    throw new Exception("No possibility, something fucked up...");
                }

            }

            // last byte, put extentions into Extentions.
            if (depth == (data.Length - 1))
            {
                if (current.Extentions == null)
                {
                    current.Extentions = new List<string>(4);
                }

                current.Extentions.AddRange(extentions);
                return;
            }

            Add(data, current, extentions, depth + 1);
        }

        private void Match(byte[] data, int depth, Node node, List<string> extentionStore, bool matchAll)
        {
            // if depth out of data.Length's index then data end.
            if (data.Length == depth)
            {
                return;
            }

            node.Children.TryGetValue(data[depth], out Node current);

            // can't find matched node, match ended.
            if (current == null)
            {
                return;
            }

            // now extentions not null, this node is a final node and this is a result.
            if (current.Extentions != null)
            {
                extentionStore.AddRange(current.Extentions);

                // if only match first matched.
                if (!matchAll)
                {
                    return;
                }
            }

            // children is null, match ended.
            if (current.Children == null)
            {
                return;
            }

            // children not null, keep match.
            Match(data, depth + 1, current, extentionStore, matchAll);
        }
    }
}