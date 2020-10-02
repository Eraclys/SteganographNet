using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using StenographNet.Common;

namespace StenographNet.Payload
{
    public class PayloadWriter : IPayloadWriter, IDisposable
    {
        readonly Stream _stream;
        List<bool> _bits;

        public PayloadWriter(Stream stream)
        {
            _stream = stream;
            _bits = new List<bool>(8);
        }
        
        public void Write(byte target, byte bitsToKeep)
        {
            var toWrite = new BitArray(new[]{target});

            for (var i = 0; i < bitsToKeep; i++)
            {
                _bits.Add(toWrite.Get(i));

                if (_bits.Count == 8)
                {
                    _bits.Reverse();
                    _stream.WriteByte(_bits.ConvertBoolArrayToByte());
                    _bits = new List<bool>(8);
                }
            }
        }

        public void Flush()
        {
            if (_bits.Count > 0)
            {
                Write(0, (byte)(8 -_bits.Count));
            }
        }

        public void Dispose()
        {
            Flush();
        }
    }
}