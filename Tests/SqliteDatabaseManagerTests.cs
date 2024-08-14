using Microsoft.CST.AttackSurfaceAnalyzer.Collectors;
using Microsoft.CST.AttackSurfaceAnalyzer.Objects;
using Microsoft.CST.AttackSurfaceAnalyzer.Types;
using Microsoft.CST.AttackSurfaceAnalyzer.Utils;
using Microsoft.Data.Sqlite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.CST.AttackSurfaceAnalyzer.Tests
{
    [TestClass]
    public class SqliteDatabaseManagerTests
    {
        private string tempDatabasePath;
        private SqliteDatabaseManager dbManager;

        [TestInitialize]
        public void Initialize()
        {
            // Setup a temporary database for testing
            tempDatabasePath = Path.Combine(Path.GetTempPath(), "Test.sqlite");
            dbManager = new SqliteDatabaseManager(tempDatabasePath, new DBSettings());
            dbManager.Setup();
        }

        [TestMethod]
        public void Constructor_InitializesProperties()
        {
            // Assert that the database manager is initialized correctly
            Assert.IsNotNull(dbManager);
            Assert.AreEqual(tempDatabasePath, dbManager.Location);
            // Add more assertions as necessary
        }

        [TestMethod]
        public void HasElements_InitiallyFalse()
        {
            // Assert that HasElements is false on a new database
            Assert.IsFalse(dbManager.HasElements);
        }

        [TestMethod]
        public void BeginTransaction_Commit_Rollback()
        {
            // Begin a transaction
            dbManager.BeginTransaction();
            // Perform some operations (omitted for brevity)
            // Commit the transaction
            dbManager.Commit();

            // Begin another transaction and then roll it back
            dbManager.BeginTransaction();
            //should have transaction at this point
            Assert.IsNotNull(dbManager.MainConnection.Transaction);
            // Perform some operations (omitted for brevity)
            dbManager.RollBack();

            Assert.IsNull(dbManager.MainConnection.Transaction);
        }

        [TestMethod]
        public void Setup_ReturnsNone_WhenSuccessful()
        {
            // Arrange
            var filename = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".sqlite");
            var dbManager = new SqliteDatabaseManager(filename);

            // Act
            var result = dbManager.Setup();

            // Assert
            Assert.AreEqual(ASA_ERROR.NONE, result);

            // Cleanup
            dbManager.CloseDatabase();
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
        }

        [TestMethod]
        public void InsertRun_GetRun_Test()
        {
            // Create Test Data
            var runId = Guid.NewGuid().ToString();
            var testRun = new AsaRun(runId, DateTime.UtcNow, "TestVersion", PLATFORM.WINDOWS, new List<RESULT_TYPE>() { RESULT_TYPE.FILEMONITOR }, RUN_TYPE.MONITOR);


            dbManager.InsertRun(testRun);


            // Verify Results
            var result = dbManager.GetRun(runId);
            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(runId, result.RunId);

            var runs = dbManager.GetRuns();
            Assert.IsTrue(runs.Contains(runId));

            var monitorRuns = dbManager.GetRuns(RUN_TYPE.MONITOR);
            Assert.IsTrue(monitorRuns.Contains(runId));

            var platform = dbManager.RunIdToPlatform(runId);
            Assert.AreEqual(PLATFORM.WINDOWS, platform);

            var GetLatestRunIds = dbManager.GetLatestRunIds(1, RUN_TYPE.MONITOR);
            Assert.IsTrue(GetLatestRunIds.Contains(runId));
            //delete runid
            dbManager.DeleteRun(runId);

        }
        [TestMethod]
        public void GetNumResults_ReturnsCorrectCount()
        {

            // Setup - Begin transaction to insert test data
            dbManager.BeginTransaction();

            var runId = Guid.NewGuid().ToString();
            var testRun = new AsaRun(runId, DateTime.UtcNow, "TestVersion", PLATFORM.WINDOWS, new List<RESULT_TYPE>() { RESULT_TYPE.FILEMONITOR }, RUN_TYPE.MONITOR);


            dbManager.InsertRun(testRun);

            // dbManager.InsertResult(new FileResult { RunId = "testRun", ... });
            InsertIntoCollect(new WriteObject(new FileSystemObject(runId),runId));
            
            dbManager.Commit();

            // Act - Call GetNumResults with the test run ID and result type
            int resultCount = dbManager.GetNumResults(RESULT_TYPE.FILE, runId);

            // Assert - Verify the result count matches the expected value
            Assert.AreEqual(expected: 1, actual: resultCount);

            // Clean up - Delete test database
        }
        private bool InsertIntoCollect(WriteObject objIn)
        {
            if (objIn == null)
            {
               
                return false;
            }

            string SQL_INSERT_COLLECT_RESULT = "insert or ignore into collect (run_id, result_type, row_key, identity, serialized) values (@run_id, @result_type, @row_key, @identity, @serialized)";

            try
            {
                using var cmd = new SqliteCommand(SQL_INSERT_COLLECT_RESULT, dbManager.MainConnection.Connection, dbManager.MainConnection.Transaction);
                cmd.Parameters.AddWithValue("@run_id", objIn.RunId);
                cmd.Parameters.AddWithValue("@result_type", objIn.ColObj?.ResultType.ToString());
                cmd.Parameters.AddWithValue("@row_key", objIn.RowKey);
                cmd.Parameters.AddWithValue("@identity", objIn.ColObj?.Identity);
                cmd.Parameters.AddWithValue("@serialized", objIn.Serialized);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            return true;
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Clean up the temporary database
            dbManager.CloseDatabase();
        }
    }
}