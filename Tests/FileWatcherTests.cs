using Microsoft.CST.AttackSurfaceAnalyzer.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace Microsoft.CST.AttackSurfaceAnalyzer.Tests
{
    [TestClass]
    public class FileWatcherTests
    {
        [TestMethod]
        public void Constructor_Default_Initializes()
        {
            var watcher = new FileWatcher();
            Assert.IsNotNull(watcher);
        }

        [TestMethod]
        public void Constructor_DirectoryName_Initializes()
        {
            // Setup: Create a temporary directory
            string tempDirectoryPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectoryPath);

            try
            {
                // Act: Initialize FileWatcher with the temporary directory
                var watcher = new FileWatcher(tempDirectoryPath);

                // Assert: Verify the watcher was successfully initialized
                Assert.IsNotNull(watcher);
            }
            finally
            {
                // Teardown: Delete the temporary directory
                if (Directory.Exists(tempDirectoryPath))
                {
                    Directory.Delete(tempDirectoryPath, true);
                }
            }
        }

        [TestMethod]
        public void StartStop_IsRunning_UpdatesCorrectly()
        {
            var watcher = new FileWatcher();
            watcher.Start();
            Assert.IsTrue(watcher.IsRunning());
            watcher.Stop();
            Assert.IsFalse(watcher.IsRunning());
        }

        [TestMethod]
        public void Dispose_NoExceptions()
        {
            var watcher = new FileWatcher();
            // The test passes if no exception is thrown during disposal
            watcher.Dispose();

        }

        [TestMethod]
        public void FileCreation_IsDetected()
        {
            string tempDirectoryPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectoryPath);

            try
            {
                // Adjusted to use the constructor that allows specifying actions for events
                var watcher = new FileWatcher(tempDirectoryPath,
                                  e => { }, // Placeholder for OnChanged
                                  e => { }, // Placeholder for OnCreated
                                  e => { }, // Placeholder for OnDeleted
                                  e => { }); // Placeholder for OnRenamed

                watcher.Start();

                string newFilePath = Path.Combine(tempDirectoryPath, "newFile.txt");
                File.Create(newFilePath).Dispose(); // Create new file and immediately release it

                // Introducing a small delay to ensure the event is captured
                System.Threading.Thread.Sleep(100);

                bool fileCreatedEventReceived = watcher.EventList.Any(e => e is FileSystemEventArgs args && args.ChangeType == WatcherChangeTypes.Created && args.FullPath == newFilePath);

                Assert.IsTrue(fileCreatedEventReceived, "File creation event was not detected.");

                watcher.Stop();
            }
            finally
            {
                if (Directory.Exists(tempDirectoryPath))
                {
                    Directory.Delete(tempDirectoryPath, true);
                }
            }
        }
        [TestMethod]
        public void FileDeletion_IsDetected()
        {
            string tempDirectoryPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectoryPath);

            try
            {
                var watcher = new FileWatcher(tempDirectoryPath,
                          e => { },
                          e => { },
                          e => { },
                          e => { });

                watcher.Start();

                string filePath = Path.Combine(tempDirectoryPath, "fileToDelete.txt");
                var fileStream = File.Create(filePath);
                fileStream.Dispose(); // Ensure the file is created and closed
                File.Delete(filePath); // Delete the file

                System.Threading.Thread.Sleep(100); // Wait for the event

                bool fileDeletedEventReceived = watcher.EventList.Any(e => e is FileSystemEventArgs args && args.ChangeType == WatcherChangeTypes.Deleted && args.FullPath == filePath);

                Assert.IsTrue(fileDeletedEventReceived, "File deletion event was not detected.");

                watcher.Stop();
            }
            finally
            {
                if (Directory.Exists(tempDirectoryPath))
                {
                    Directory.Delete(tempDirectoryPath, true);
                }
            }
        }

        [TestMethod]
        public void FileChange_IsDetected()
        {
            string tempDirectoryPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectoryPath);

            try
            {
                var watcher = new FileWatcher(tempDirectoryPath,
                          e => { },
                          e => { },
                          e => { },
                          e => { });

                watcher.Start();

                string filePath = Path.Combine(tempDirectoryPath, "fileToModify.txt");
                using (var fileStream = File.Create(filePath))
                {
                    byte[] info = new System.Text.UTF8Encoding(true).GetBytes("This is some text in the file.");
                    fileStream.Write(info, 0, info.Length);
                }

                System.Threading.Thread.Sleep(100); // Wait for the creation event

                using (var fileStream = File.OpenWrite(filePath))
                {
                    byte[] info = new System.Text.UTF8Encoding(true).GetBytes("This is some new text.");
                    fileStream.Write(info, 0, info.Length);
                }

                System.Threading.Thread.Sleep(100); // Wait for the change event

                bool fileChangedEventReceived = watcher.EventList.Any(e => e is FileSystemEventArgs args && args.ChangeType == WatcherChangeTypes.Changed && args.FullPath == filePath);

                Assert.IsTrue(fileChangedEventReceived, "File change event was not detected.");

                watcher.Stop();
            }
            finally
            {
                if (Directory.Exists(tempDirectoryPath))
                {
                    Directory.Delete(tempDirectoryPath, true);
                }
            }
        }

        [TestMethod]
        public void FileRename_IsDetected()
        {
            string tempDirectoryPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectoryPath);

            try
            {
                var watcher = new FileWatcher(tempDirectoryPath,
                          e => { },
                          e => { },
                          e => { },
                          e => { });

                watcher.Start();

                string originalFilePath = Path.Combine(tempDirectoryPath, "originalFileName.txt");
                string newFilePath = Path.Combine(tempDirectoryPath, "newFileName.txt");
                File.Create(originalFilePath).Dispose(); // Create and close the file

                System.Threading.Thread.Sleep(100); // Wait for the creation event

                File.Move(originalFilePath, newFilePath); // Rename the file

                System.Threading.Thread.Sleep(100); // Wait for the rename event

                bool fileRenamedEventReceived = watcher.EventList.Any(e => e is RenamedEventArgs args && args.ChangeType == WatcherChangeTypes.Renamed && args.FullPath == newFilePath);

                Assert.IsTrue(fileRenamedEventReceived, "File rename event was not detected.");

                watcher.Stop();
            }
            finally
            {
                if (Directory.Exists(tempDirectoryPath))
                {
                    Directory.Delete(tempDirectoryPath, true);
                }
            }
        }
    }
}