/*
 * Copyright (C) Mark Alan Jones 2010
 * This code is published under the Microsoft Public License (Ms-Pl)
 * A copy of the Ms-Pl license is included with the source and 
 * binary distributions or online at
 * http://www.microsoft.com/opensource/licenses.mspx#Ms-PL
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenSoundControl
{
    /// <summary>
    /// Encapsulates an OSC blob.
    /// </summary>
    public class OscBlob : IOscDataType
    {
        private List<byte> buffer = new List<byte>();
    
        public OscBlob()
        {
            
        }

        public OscBlob(byte[] buffer)
        {        
            Buffer.AddRange(buffer);
        }

        public OscBlob(ArraySegment<byte> bufferSeg)
        {            
            for (int i = bufferSeg.Offset; i < (bufferSeg.Offset + bufferSeg.Count); i++)
            {
                Buffer.Add(bufferSeg.Array[i]);
            }
        }

        public OscDataType DataType 
        { 
            get 
            { 
                return OscDataType.Blob; 
            } 
        }

        public List<byte> Buffer
        {
            get
            {
                return buffer;
            }
            set
            {
                // don't allow the list to be set to null
                if (value == null)
                    buffer.Clear();
                else
                    buffer = value;
            }
        }

        public override string ToString()
        {
            return Encoding.UTF8.GetString(buffer.ToArray());
        }        
    }
}
