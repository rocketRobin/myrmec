namespace Myrmec
{
    /// <summary>
    /// Representing a section of offset.
    /// </summary>
    public class Offset
    {
        /// <summary>
        /// Count of data array.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Start position of data array.
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// The AscII string corresponding to the binary value of this data
        /// </summary>
        public string Value { get; set; }
    }
}