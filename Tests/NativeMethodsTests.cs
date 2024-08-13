using Microsoft.CST.AttackSurfaceAnalyzer.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
namespace Microsoft.CST.AttackSurfaceAnalyzer.Tests
{
    [TestClass]
    public class NativeMethodsTests
    {
        [TestMethod]
        public void Test_GetFinalPathName_ValidPath()
        {
            // Arrange
            string tempFilePath = Path.GetTempFileName();

            // Act
            string result = NativeMethods.GetFinalPathName(tempFilePath);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
            Assert.IsTrue(result.Contains(Path.GetFileName(tempFilePath)));

            // Cleanup
            File.Delete(tempFilePath);
        }

        [TestMethod]
        [ExpectedException(typeof(Win32Exception))]
        public void Test_GetFinalPathName_InvalidPath()
        {
            // Arrange
            string invalidPath = @"Z:\nonexistent\file.txt";

            // Act
            NativeMethods.GetFinalPathName(invalidPath);

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(Win32Exception))]
        public void Test_GetFinalPathName_LongPath()
        {
            // Arrange
            string longPath = new string('a', 1025);

            // Act
            NativeMethods.GetFinalPathName(longPath);

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(Win32Exception))]
        public void Test_GetFinalPathName_EmptyString()
        {
            // Act
            NativeMethods.GetFinalPathName(string.Empty);

            // Assert is handled by ExpectedException
        }
        
    }
}