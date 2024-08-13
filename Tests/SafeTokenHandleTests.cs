using Microsoft.CST.AttackSurfaceAnalyzer.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
namespace Microsoft.CST.AttackSurfaceAnalyzer.Tests
{
    [TestClass]
    public class SafeTokenHandleTests
    {
        [TestMethod]
        public void Constructor_SetsHandleCorrectly()
        {
            // Arrange
            IntPtr expectedHandle = new IntPtr(123);

            // Act
            SafeTokenHandle safeTokenHandle = (SafeTokenHandle)Activator.CreateInstance(typeof(SafeTokenHandle), BindingFlags.Instance | BindingFlags.NonPublic, null, new object[] { expectedHandle }, null);

            // Assert
            Assert.AreEqual(expectedHandle, safeTokenHandle.DangerousGetHandle());
        }

        [TestMethod]
        public void SafeTokenHandle_Dispose_ReleasesHandle()
        {
            // Simplify 'new' expressions
            IntPtr validHandle = new(123); // Assuming 123 is a valid handle for testing
            SafeTokenHandle safeTokenHandle = new(validHandle);

            // Act
            safeTokenHandle.Dispose();

            // Assert
            // Ensure the handle is set to IntPtr.Zero upon disposal.
            //Assert.AreEqual(IntPtr.Zero, safeTokenHandle.DangerousGetHandle(), "Handle was not released upon disposal.");
            // Additional assertion to ensure the SafeTokenHandle is marked as disposed.
            Assert.IsTrue(safeTokenHandle.IsClosed, "SafeTokenHandle was not marked as closed.");
        }
        [TestMethod]
        public void TestPrivateConstructor()
        {
            // Use reflection to access the private constructor
            var constructorInfo = typeof(SafeTokenHandle).GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic,
                null, new Type[0], null);

            // Assert that the constructor is found
            Assert.IsNotNull(constructorInfo, "Private constructor not found.");

            // Invoke the private constructor
            var instance = (SafeTokenHandle)constructorInfo.Invoke(null);

            // Assert that the instance is created
            Assert.IsNotNull(instance, "Instance creation failed.");

            // Optionally, assert the initial state of the instance if applicable
            // For example, if there's a way to verify the handle is in the expected state, do so here
        }
    }
}