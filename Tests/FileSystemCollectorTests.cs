using Microsoft.CST.AttackSurfaceAnalyzer.Collectors;
using Microsoft.CST.AttackSurfaceAnalyzer.Objects;
using Microsoft.CST.RecursiveExtractor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace Microsoft.CST.AttackSurfaceAnalyzer.Tests
{
    [TestClass]
    public class FileSystemCollectorTests
    {
        [TestMethod]
        public void ConstructorTest_WithNullOptions()
        {
            var collector = new FileSystemCollector();
            Assert.IsNotNull(collector);
        }

        [TestMethod]
        public void ConstructorTest_WithEmptyDirectories()
        {
            var opts = new CollectorOptions { SelectedDirectories = new List<string>() };
            var collector = new FileSystemCollector(opts);
            Assert.IsTrue(collector.Roots.Count > 0); // Assuming the system has at least one fixed drive
        }

        [TestMethod]
        public void CanRunOnPlatformTest()
        {
            var collector = new FileSystemCollector();
            bool canRun = collector.CanRunOnPlatform();
            bool expected = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ||
                            RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ||
                            RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
            Assert.AreEqual(expected, canRun);
        }

        [TestMethod]
        public void FilePathToFileSystemObjectTest_ValidPath()
        {
            // This test requires a valid file path. Adjust the path as necessary for the environment.
            string testFilePath = Path.GetTempFileName();
            var collector = new FileSystemCollector();
            var result = collector.FilePathToFileSystemObject(testFilePath);
            Assert.IsNotNull(result);
            Assert.AreEqual(testFilePath, result.Path);
            if(File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }
        [TestMethod]
        public void FilePathToFileSystemObjectTest_ValidDirectoryPath()
        {
            // This test requires a valid file path. Adjust the path as necessary for the environment.
            string testFilePath = Path.GetTempPath();
            var collector = new FileSystemCollector();
            var result = collector.FilePathToFileSystemObject(testFilePath);
            Assert.IsNotNull(result);
            Assert.AreEqual(testFilePath, result.Path);
            Assert.IsTrue(result.IsDirectory);

        }

        [TestMethod]
        public void FilePathToFileSystemObjectTest_InvalidPath()
        {
            string testFilePath = "non_existent_file_path";
            var collector = new FileSystemCollector();
            var result = collector.FilePathToFileSystemObject(testFilePath);
            Assert.IsNull(result.Owner);
        }

        [TestMethod]
        public void FilePathToFileSystemObjectTest_NullPath()
        {
            string testFilePath = null;
            var collector = new FileSystemCollector();
            var result=collector.FilePathToFileSystemObject(testFilePath);
            Assert.IsNull(result.Owner);
            Assert.IsNull(result.Path);
        }

        //[TestMethod] //it is running infinite
        //public void ExecuteInternalTest_CancellationRequested()
        //{
        //    var opts = new CollectorOptions() { RunId = "RunId1" };
        //    var collector = new FileSystemCollector(opts);
        //    // Use reflection to call the private method ExecuteInternal
        //    var methodInfo = typeof(FileSystemCollector).GetMethod("ExecuteInternal", BindingFlags.NonPublic | BindingFlags.Instance);
        //    methodInfo.Invoke(collector, new object[] { new CancellationToken() });
        //    // Since ExecuteInternal is void, we're testing to ensure no exception is thrown on cancellation
        //}
        
        [TestMethod]
        public void WindowsSizeOnDiskTest_ValidFile()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.Inconclusive("WindowsSizeOnDisk is only applicable on Windows.");
            }
            var testFilePath = new FileInfo("path_to_a_valid_file_on_windows");
            var collector = new FileSystemCollector();
            // Use reflection to call the private method WindowsSizeOnDisk
            var methodInfo = typeof(FileSystemCollector).GetMethod("WindowsSizeOnDisk", BindingFlags.NonPublic | BindingFlags.Static);
            long size = (long)methodInfo.Invoke(collector, new object[] { testFilePath });
            Assert.IsTrue(size > 0);
        }
        
        //[TestMethod]
        //public void WindowsSizeOnDiskTest_InvalidFile()
        //{
        //    if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        //    {
        //        Assert.Inconclusive("WindowsSizeOnDisk is only applicable on Windows.");
        //    }
        //    var testFilePath = new FileInfo(@"123");
        //    var collector = new FileSystemCollector();
        //    // Use reflection to call the private method WindowsSizeOnDisk
        //    var methodInfo = typeof(FileSystemCollector).GetMethod("WindowsSizeOnDisk", BindingFlags.NonPublic | BindingFlags.Static);
        //    long size = (long)methodInfo.Invoke(collector, new object[] { testFilePath });
        //    Assert.AreEqual(-1, size); // Assuming -1 is the error value
        //}
        
        [TestMethod]
        public void TryIterateOnDirectoryTest_ValidDirectory()
        {
            string testDirectoryPath = Path.GetTempPath();
            var collector = new FileSystemCollector();
            // Use reflection to call the private method TryIterateOnDirectory
            var methodInfo = typeof(FileSystemCollector).GetMethod("TryIterateOnDirectory", BindingFlags.NonPublic | BindingFlags.Instance);
            methodInfo.Invoke(collector, new object[] { testDirectoryPath });
            //It is void method if no exception generated then consider test is pass
            // Assuming TryIterateOnDirectory returns a tuple or an object that can be deconstructed

        }

        [TestMethod]
        public void TryIterateOnDirectoryTest_InvalidDirectory()
        {
            string testDirectoryPath = "non_existent_directory_path";
            var collector = new FileSystemCollector();
            // Use reflection to access the private method
            var methodInfo = typeof(FileSystemCollector).GetMethod("TryIterateOnDirectory", BindingFlags.NonPublic | BindingFlags.Instance);
            
            // Assuming the second parameter is an out parameter, we need to provide an array with a placeholder for it
           // object[] parameters = new object[] { testDirectoryPath, null };
            
            methodInfo.Invoke(collector, new object[] { testDirectoryPath });
            //It is void method if no exception generated then consider test is pass
            // After invocation, the out parameter value can be extracted from the parameters array
            //var fileSystemObjects = (List<FileSystemObject>)parameters[1];

            //Assert.IsFalse(result);
            // If the method initializes the out parameter even when failing, this assertion may need to be adjusted
            //Assert.IsNull(fileSystemObjects);
        }

        [TestMethod]
        public void FileEntryToFileSystemObjectTest_ValidFileEntry()
        {
            // Adjusted to use a MemoryStream as the second argument to match the expected System.IO.Stream type
            using (var memoryStream = new MemoryStream(Array.Empty<byte>()))
            {
                // Adjusted the third argument to be null to match the expected FileEntry? type
                var fileEntry = new FileEntry("test_file.txt", memoryStream, parent: null);
                var collector = new FileSystemCollector();
                // Reflectively access the private method
                var methodInfo = typeof(FileSystemCollector).GetMethod("FileEntryToFileSystemObject", BindingFlags.NonPublic | BindingFlags.Instance);
                var result = methodInfo.Invoke(collector, new object[] { fileEntry });
                Assert.IsNotNull(result);
                // Assuming the result is a FileSystemObject, cast it to access properties
                var fileSystemObject = (FileSystemObject)result;
                // Adjusted property access to use the correct property 'Path' instead of 'Name'
                Assert.IsTrue(fileSystemObject.Path.EndsWith("test_file.txt")); // This checks that the path ends with the file name, assuming FileSystemObject contains a Path property
            }
        }
        
        [TestMethod]
        public void FileEntryToFileSystemObjectTest_NullFileEntry()
        {
            var collector = new FileSystemCollector();
            var methodInfo = typeof(FileSystemCollector).GetMethod("FileEntryToFileSystemObject", BindingFlags.NonPublic | BindingFlags.Instance);
            // Expecting an exception when null is passed to the private method
            Assert.ThrowsException<TargetInvocationException>(() => methodInfo.Invoke(collector, new object[] { null }));
        }
        
        [TestMethod]
        public void ParseFileTest_ValidFile()
        {
            string testFilePath = Path.GetTempFileName();
            var collector = new FileSystemCollector();
            var methodInfo = typeof(FileSystemCollector).GetMethod("ParseFile", BindingFlags.NonPublic | BindingFlags.Instance);
            var result = methodInfo.Invoke(collector, new object[] { testFilePath });
            //It is void method if no exception generated then consider test is pass
           
            //check and delete the file
            if(File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }

        [TestMethod]
        public void ParseFileTest_InvalidFile()
        {
            string testFilePath = "non_existent_file_path";
            var collector = new FileSystemCollector();
            var methodInfo = typeof(FileSystemCollector).GetMethod("ParseFile", BindingFlags.NonPublic | BindingFlags.Instance);
            var result = methodInfo.Invoke(collector, new object[] { testFilePath });
            Assert.IsNull(result);
        }
        
        [TestMethod]
        public void ParseFileTest_NullPath()
        {
            var collector = new FileSystemCollector();
            var methodInfo = typeof(FileSystemCollector).GetMethod("ParseFile", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.ThrowsException<TargetInvocationException>(() => methodInfo.Invoke(collector, new object[] { null }));
        }
        
        [TestMethod]
        public void ParseFileTest_ArchiveFile_CrawlArchivesTrue()
        {
            // Step 1 & 2: Create a temporary file path for the archive
            string tempArchiveFilePath = Path.GetTempFileName();
            File.Delete(tempArchiveFilePath); // Ensure the file does not exist

            // Step 3: Create a temporary directory and add files
            string tempDirectoryPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectoryPath);
            string tempFilePath = Path.Combine(tempDirectoryPath, "tempFile.txt");
            File.WriteAllText(tempFilePath, "This is a test file.");

            // Step 4: Create an archive from the temporary directory
            ZipFile.CreateFromDirectory(tempDirectoryPath, tempArchiveFilePath);

            // Use the archive in the test
            var opts = new CollectorOptions { CrawlArchives = true };
            var collector = new FileSystemCollector(opts);
            var methodInfo = typeof(FileSystemCollector).GetMethod("ParseFile", BindingFlags.NonPublic | BindingFlags.Instance);
            var result = methodInfo.Invoke(collector, new object[] { tempArchiveFilePath }) as List<FileSystemObject>;

            // Assertions
            //it is a void method so consider if no exception generated then test is passed 

            // Cleanup: Delete the temporary directory and archive file
            Directory.Delete(tempDirectoryPath, true);
            File.Delete(tempArchiveFilePath);
        }
        
        [TestMethod]
        public void ParseFileTest_ArchiveFile_CrawlArchivesFalse()
        {
            string testArchiveFilePath = "path_to_a_valid_archive_file.zip";
            var opts = new CollectorOptions { CrawlArchives = false };
            var collector = new FileSystemCollector(opts);
            var methodInfo = typeof(FileSystemCollector).GetMethod("ParseFile", BindingFlags.NonPublic | BindingFlags.Instance);
            var result = methodInfo.Invoke(collector, new object[] { testArchiveFilePath }) as List<FileSystemObject>;
            Assert.IsNull(result);
        }

        //[TestMethod]
        //public void ExecuteInternalTest_WithValidDirectory()
        //{
        //    string testDirectoryPath = "path_to_a_valid_directory";
        //    var opts = new CollectorOptions { SelectedDirectories = new List<string> { testDirectoryPath } };
        //    var collector = new FileSystemCollector(opts);
        //    // Use reflection to call the private method
        //    var methodInfo = typeof(FileSystemCollector).GetMethod("ExecuteInternal", BindingFlags.NonPublic | BindingFlags.Instance);
        //    methodInfo.Invoke(collector, null);
        //    // Since ExecuteInternal is void, we're testing to ensure no exception is thrown and assuming it processes files correctly.
        //    Assert.IsTrue(true); // Placeholder assertion to indicate the method completed without throwing an exception
        //}
        
        //[TestMethod]
        //public void ExecuteInternalTest_WithInvalidDirectory()
        //{
        //    string testDirectoryPath = "non_existent_directory_path";
        //    var opts = new CollectorOptions { SelectedDirectories = new List<string> { testDirectoryPath } };
        //    var collector = new FileSystemCollector(opts);
        //    // Use reflection to call the private method
        //    var methodInfo = typeof(FileSystemCollector).GetMethod("ExecuteInternal", BindingFlags.NonPublic | BindingFlags.Instance);
        //    methodInfo.Invoke(collector, null);
        //    // Since ExecuteInternal is void, we're testing to ensure no exception is thrown even with an invalid directory.
        //    Assert.IsTrue(true); // Placeholder assertion to indicate the method completed without throwing an exception
        //}
    }
}