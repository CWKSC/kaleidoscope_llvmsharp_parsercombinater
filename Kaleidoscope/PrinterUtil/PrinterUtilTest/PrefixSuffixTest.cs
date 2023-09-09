using PrinterUtil;

namespace PrinterUtilTest
{
    [TestClass]
    public class PrefixSuffixTest
    {
        [TestMethod]
        public void TestPrefix()
        {
            Assert.AreEqual("prefix", new Printer() { prefix = "prefix" }.GetString(""));
            Assert.AreEqual("prefix42", new Printer() { prefix = "prefix" }.GetString("42"));
        }

        [TestMethod]
        public void TestSuffix()
        {
            Assert.AreEqual("suffix", new Printer() { suffix = "suffix" }.GetString(""));
            Assert.AreEqual("42suffix", new Printer() { suffix = "suffix" }.GetString("42"));
        }

    }
}