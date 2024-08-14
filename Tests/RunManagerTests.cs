using Microsoft.CST.AttackSurfaceAnalyzer.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.CST.AttackSurfaceAnalyzer.Tests
{
    [TestClass]
    public class RunManagerTests
    {
        [TestMethod]
        public void RunManagerConstructorTest()
        {
            // Arrange & Act
            var runManagerInstance = new RunManager();

            // Assert
            Assert.IsNotNull(runManagerInstance, "RunManager instance should not be null.");
        }
    }
}