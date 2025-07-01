namespace IoTSharp.Numerics.TestProject
{
    [TestClass]
    public sealed class BEAreEqualLETest
    {
        [TestMethod]
        public void BEU16()
        {
           Assert.AreEqual((UInt16)(BigEndianUInt16)(0x1234) ,(UInt16)0x3412);
        }
        [TestMethod]
        public void BEU24()
        {
            Assert.AreEqual((UInt32)(BigEndianUInt24)(0x123456), (UInt32)0x563412);
        }
        [TestMethod]
        public void BEU32()
        {
            Assert.AreEqual((UInt32)(BigEndianUInt32)(0x12345678), (UInt32)0x78563412);
        }

        [TestMethod]
        public void BEU64()
        {
            Assert.AreEqual((UInt64)(BigEndianUInt64)(0x1234567812345678), (UInt64)0x7856341278563412);
        }
    }
}
