using System;
using System.Buffers.Binary;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace IoTSharp.Numerics
{
    [InlineArray(3)]
     struct BEUI24
    {
        byte Value;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct BigEndianUInt24 : IEquatable<BigEndianUInt24>
    {

        [MarshalAs(UnmanagedType.Struct, SizeConst = 1)]
        BEUI24 data;
        public static implicit operator uint(BigEndianUInt24 d)
        {
             if ( BitConverter.IsLittleEndian)
            {
                var bytes = new byte[4] ;
                bytes[1] = d.data[0];
                bytes[2] = d.data[1];
                bytes[3] = d.data[2];
                return BinaryPrimitives.ReadUInt32BigEndian(bytes);
            }
            else
            {
                var bytes = new byte[4];
                bytes[0] = d.data[0];
                bytes[1] = d.data[1];
                bytes[2] = d.data[2];
                return BinaryPrimitives.ReadUInt32LittleEndian(bytes);
            }
            
        }
        public static implicit operator ulong(BigEndianUInt24 d) => (uint)d;
        public static implicit operator long(BigEndianUInt24 d) => (uint)d;

        public static implicit operator BigEndianUInt24(uint d)
        {
            BigEndianUInt24 BigEndianUInt24 = new BigEndianUInt24();
            if (BitConverter.IsLittleEndian)
            {
                var bytes = new byte[4];
                BinaryPrimitives.WriteUInt32BigEndian(bytes, d);
                BigEndianUInt24.data[0] = bytes[1];
                BigEndianUInt24.data[1] = bytes[2];
                BigEndianUInt24.data[2] = bytes[3];
            }
            else
            {
                var bytes = new byte[4];
                BinaryPrimitives.WriteUInt32LittleEndian(bytes, d);
                BigEndianUInt24.data[0] = bytes[0];
                BigEndianUInt24.data[1] = bytes[1];
                BigEndianUInt24.data[2] = bytes[2];
            }
            return BigEndianUInt24;
        }
        public readonly bool Equals(BigEndianUInt24 other) => data.Equals(other.data);
        public readonly override bool Equals([NotNullWhen(true)] object? obj) => obj is BigEndianUInt24 other && Equals(other);
        public readonly override int GetHashCode() => data.GetHashCode();
        public readonly override string? ToString() => Convert.ToHexString(data);

        public static bool operator ==(BigEndianUInt24 a, BigEndianUInt24 b) => (UInt32)a == (UInt32)b;
        public static bool operator !=(BigEndianUInt24 a, BigEndianUInt24 b) => (UInt32)a != (UInt32)b;
    }
   
}
