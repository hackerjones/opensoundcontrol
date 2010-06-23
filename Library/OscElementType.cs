namespace OpenSoundControl
{
    /// <summary>
    ///   Element type enumeration.
    /// </summary>
    public enum OscElementType
    {
        /// <summary>
        ///   Message
        /// </summary>
        Message,
        /// <summary>
        ///   Bundle
        /// </summary>
        Bundle,
        /// <summary>
        ///   Address
        /// </summary>
        Address,
        /// <summary>
        ///   Type tag string
        /// </summary>
        TypeTagString,
        /// <summary>
        ///   Signed integer 32-bits
        /// </summary>
        Int32,
        /// <summary>
        ///   Unsigned integer 32-bits
        /// </summary>
        UInt32,
        /// <summary>
        ///   Floating point number 32-bits
        /// </summary>
        Float32,
        /// <summary>
        ///   String
        /// </summary>
        String,
        /// <summary>
        ///   Blob
        /// </summary>
        Blob,
        /// <summary>
        ///   True
        /// </summary>
        True,
        /// <summary>
        ///   False
        /// </summary>
        False,
        /// <summary>
        ///   Null
        /// </summary>
        Null,
        /// <summary>
        ///   Impulse
        /// </summary>
        Impulse,
        /// <summary>
        ///   Timetag
        /// </summary>
        Timetag
    }
}
