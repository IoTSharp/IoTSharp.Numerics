using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
namespace IoTSharp.Numerics
{


    [InlineArray(8)]
    struct BEUI64
    {
        byte Value;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct BigEndianUInt64 : IEquatable<BigEndianUInt64>
    {
        [MarshalAs(UnmanagedType.Struct, SizeConst = 1)]
        BEUI64 data;


        public static implicit operator ulong(BigEndianUInt64 d)
        {
            return BitConverter.IsLittleEndian ?
                BinaryPrimitives.ReadUInt64BigEndian(d.data) :
                BinaryPrimitives.ReadUInt64LittleEndian(d.data);
        }
        public static implicit operator BigEndianUInt64(ulong d)
        {
            BigEndianUInt64 bigEndianUInt64 = new BigEndianUInt64();
            if (BitConverter.IsLittleEndian)
            {
                BinaryPrimitives.WriteUInt64BigEndian(bigEndianUInt64.data, d);
            }
            else
            {
                BinaryPrimitives.WriteUInt64LittleEndian(bigEndianUInt64.data, d);
            }
            return bigEndianUInt64;
        }
        public readonly bool Equals(BigEndianUInt64 other) => data.Equals(other.data);
        public readonly override bool Equals([NotNullWhen(true)] object? obj) => obj is BigEndianUInt64 other && Equals(other);
        public readonly override int GetHashCode() => data.GetHashCode();
        public readonly override string? ToString() => Convert.ToHexString(data);

        public static bool operator ==(BigEndianUInt64 a, BigEndianUInt64 b) => (UInt64)a == (UInt64)b;
        public static bool operator !=(BigEndianUInt64 a, BigEndianUInt64 b) => (UInt64)a != (UInt64)b;


        public static implicit operator BigEndianUInt64(byte[] d) => MemoryMarshal.AsRef<BigEndianUInt64>(d);
        public static implicit operator byte[](BigEndianUInt64 d) => MemoryMarshal.AsBytes(new ReadOnlySpan<BigEndianUInt64>(ref d)).ToArray();
    }


}



