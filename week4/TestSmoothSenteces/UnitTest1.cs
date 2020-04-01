using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmoothSentences;

namespace TestSmoothSenteces
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIsSmoothMethod()
        {
            string test1 = "Carlos swam masterfully.";
            var result   = Program.IsSmooth(test1);

            Assert.IsTrue(result);

            string test2 = "Is not a smooth sentence.";
            result = Program.IsSmooth(test2);

            Assert.IsFalse(result);
        }
    }
}
