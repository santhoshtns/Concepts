using ConceptTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Concepts.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var output = Program.pokerChips2(new int[] { 6, 2, 4, 10, 3 });
            Assert.AreEqual(4, output);
        }
    }
}
