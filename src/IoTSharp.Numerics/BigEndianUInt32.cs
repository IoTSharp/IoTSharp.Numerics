using System;
using System.Buffers.Binary;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace IoTSharp.Numerics
{
    [InlineArray(4)]
     struct BEUI32
    {
        byte Value;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct BigEndianUInt32 : IEquatable<BigEndianUInt32>
    {

        [MarshalAs(UnmanagedType.Struct, SizeConst = 1)]
         BEUI32 data;
        public static implicit operator uint(BigEndianUInt32 d)
        {
            return BinaryPrimitives.ReadUInt32BigEndian(d.data);
        }
        public static implicit operator ulong(BigEndianUInt32 d) => (uint)d;
        public static implicit operator long(BigEndianUInt32 d) => (uint)d;

        public static implicit operator BigEndianUInt32(uint d)
        {
            BigEndianUInt32 bigEndianUInt32 = new BigEndianUInt32();
            BinaryPrimitives.WriteUInt32LittleEndian(bigEndianUInt32.data, d);
            return bigEndianUInt32;
        }
        public  bool Equals(BigEndianUInt32 other) => data.Equals(other.data);
        public  override bool Equals([NotNullWhen(true)] object? obj) => obj is BigEndianUInt32 other && Equals(other);
        public  override readonly int GetHashCode() => data.GetHashCode();
        public  override string? ToString() => ToHexString;
        public readonly string? ToHexString => Convert.ToHexString(MemoryMarshal.AsBytes(new ReadOnlySpan<BEUI32>(data)));

        public static bool operator ==(BigEndianUInt32 a, BigEndianUInt32 b) => (UInt32)a == (UInt32)b;
        public static bool operator !=(BigEndianUInt32 a, BigEndianUInt32 b) => (UInt32)a != (UInt32)b;

        public static implicit operator BigEndianUInt32(byte[] d) => MemoryMarshal.AsRef<BigEndianUInt32>(d);
        public static implicit operator byte[](BigEndianUInt32 d) => MemoryMarshal.AsBytes(new ReadOnlySpan<BigEndianUInt32>(ref d)).ToArray();
    }
   
}
