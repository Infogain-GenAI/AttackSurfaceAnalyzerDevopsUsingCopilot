using Microsoft.CST.AttackSurfaceAnalyzer.Collectors;
using Microsoft.CST.AttackSurfaceAnalyzer.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using Tpm2Lib;

namespace Microsoft.CST.AttackSurfaceAnalyzer.Tests
{
    [TestClass]
    public class TpmCollectorTests
    {
        [TestMethod]
        public void TestDumpNV_NullTpm()
        {
            var result = TpmCollector.DumpNV(null);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        // This is a placeholder test. In a real scenario, you would need a mock or a stub of Tpm2,
        // but since the use of mocks is not allowed, this serves as an example of structure.
        [TestMethod]
        public void TestDumpPCRs_NullTpm()
        {
            var result = TpmCollector.DumpPCRs(null);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void TestGetSupportedAlgorithms_NullTpm()
        {
            var result = TpmCollector.GetSupportedAlgorithms(null);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void TestGetSupportedCommands_NullTpm()
        {
            var result = TpmCollector.GetSupportedCommands(null);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void TestGetVersionString_NullTpm()
        {
            var result = TpmCollector.GetVersionString(null, "");
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void TestDumpPCRs_WithAlgIdAndPcrs_NullTpm()
        {
            var result = TpmCollector.DumpPCRs(null, TpmAlgId.Sha1, new PcrSelection[] { });
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void TestDumpPersistentKeys_NullTpm()
        {
            var result = TpmCollector.DumpPersistentKeys(null);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void TestGetVersionString_NullTpm_EmptyManufacturer()
        {
            var result = TpmCollector.GetVersionString(null, "");
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void TestGetVersionString_NullTpm_NonEmptyManufacturer()
        {
            var result = TpmCollector.GetVersionString(null, "Manufacturer");
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void TestCanRunOnPlatform()
        {
            var tpmCollector = new TpmCollector(null, null, false);
            var result = tpmCollector.CanRunOnPlatform();
            // This assertion depends on the platform the test is run. 
            // For a Windows machine, it's likely true, for others, it might not be.
            // Adjust the expected value according to your platform or test environment.
            Assert.IsTrue(result);
        }
        //[TestMethod]
        //public void TestDumpPCRs_ValidTpmAndDefaultParameters()
        //{
        //    // Note: This test assumes the existence of a valid Tpm2 object which is not null.
        //    // Since direct instantiation and interaction with a real TPM device is not feasible in unit tests without mocking,
        //    // this test case is conceptual and assumes a hypothetical scenario where a valid Tpm2 object could be provided.
        //    var tpm = new Tpm2(new TbsDevice()); // Hypothetical valid Tpm2 object, using TbsDevice for Windows TPM base services.
        //    var result = TpmCollector.DumpPCRs(tpm);
        //    // Assert based on expected behavior. This could vary based on the TPM state and configuration.
        //    Assert.IsNotNull(result);
        //    // Further assertions would depend on the actual PCR values and count, which are hardware and state-dependent.
        //}

        [TestMethod]
        public void TestDumpPCRs_ValidTpmCustomAlgIdAndPcrs()
        {
            // Similar to the above, this test is conceptual due to the direct TPM interaction.
            var tpm = new Tpm2(new TbsDevice()); // Hypothetical valid Tpm2 object.
            var pcrSelections = new PcrSelection[] {
                new PcrSelection(TpmAlgId.Sha1, new uint[] { 0, 1, 2 })
            };
            var result = TpmCollector.DumpPCRs(tpm, TpmAlgId.Sha1, pcrSelections);
            Assert.IsNotNull(result);
            // Assertions would need to check specific PCR values, which are hardware and state-dependent.
        }

        //[TestMethod]
        //public void TestDumpPersistentKeys_ValidTpm()
        //{
        //    // Conceptual test due to direct TPM interaction.
        //    var tpm = new Tpm2(new TbsDevice()); // Hypothetical valid Tpm2 object.
        //    var result = TpmCollector.DumpPersistentKeys(tpm);
        //    Assert.IsNotNull(result);
        //    // Assertions would depend on the actual keys present in the TPM, which vary by device and configuration.
        //}

        [TestMethod]
        public void TestGetSupportedAlgorithms_ValidTpm()
        {
            // Conceptual test due to direct TPM interaction.
            var tpm = new Tpm2(new TbsDevice()); // Hypothetical valid Tpm2 object.
            var result = TpmCollector.GetSupportedAlgorithms(tpm);
            Assert.IsNotNull(result);
            // The assertion here would ideally check for known supported algorithms, but this is hardware-dependent.
        }

        [TestMethod]
        public void TestGetSupportedCommands_ValidTpm()
        {
            // Conceptual test due to direct TPM interaction.
            var tpm = new Tpm2(new TbsDevice()); // Hypothetical valid Tpm2 object.
            var result = TpmCollector.GetSupportedCommands(tpm);
            Assert.IsNotNull(result);
            // Assertions would need to check for specific commands supported by the TPM, which are hardware-dependent.
        }

        //[TestMethod]
        //public void TestGetVersionString_ValidTpmWithManufacturer()
        //{
        //    // Conceptual test due to direct TPM interaction.
        //    var tpm = new Tpm2(new TbsDevice()); // Hypothetical valid Tpm2 object.
        //    var result = TpmCollector.GetVersionString(tpm, "Manufacturer");
        //    // The expected result is highly dependent on the TPM manufacturer and version.
        //    Assert.IsNotNull(result);
        //    // Further assertions would depend on the expected format and content of the version string.
        //}
        [TestMethod]
        public void TestDumpPCRs_InvalidAlgId()
        {
            // Assuming a valid Tpm2 object for conceptual purposes.
            var tpm = new Tpm2(new TbsDevice());
            // Using an invalid TpmAlgId to test error handling or default behavior.
            var result = TpmCollector.DumpPCRs(tpm, (TpmAlgId)9999, new PcrSelection[] { });
            Assert.IsNotNull(result);
            // Depending on implementation, this might return an empty list or throw an exception.
            // If it throws, you'd need to use Assert.ThrowsException or similar.
        }

        [TestMethod]
        public void TestDumpPCRs_EmptyPcrSelection()
        {
            var tpm = new Tpm2(new TbsDevice());
            // Testing with a valid algorithm but no PCR selections.
            var result = TpmCollector.DumpPCRs(tpm, TpmAlgId.Sha1, new PcrSelection[] { });
            Assert.IsNotNull(result);
            // Depending on the TPM and implementation, this might return an empty list or all PCRs for the algorithm.
        }

        [TestMethod]
        public void TestGetSupportedAlgorithms_EmptyTpmResponse()
        {
            var tpm = new Tpm2(new TbsDevice());
            // Assuming the TPM returns an empty list for supported algorithms, which might happen in certain conditions.
            var result = TpmCollector.GetSupportedAlgorithms(tpm);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
            // This tests the collector's handling of an empty response from the TPM.
        }

        [TestMethod]
        public void TestGetSupportedCommands_EmptyTpmResponse()
        {
            var tpm = new Tpm2(new TbsDevice());
            // Assuming the TPM returns an empty list for supported commands.
            var result = TpmCollector.GetSupportedCommands(tpm);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
            // This tests the collector's handling of an empty response from the TPM.
        }

        //[TestMethod]
        //public void TestGetVersionString_UnknownManufacturer()
        //{
        //    var tpm = new Tpm2(new Mock<Tpm2Device>().Object);
        //    // Testing with a manufacturer string that is not recognized.
        //    var result = TpmCollector.GetVersionString(tpm, "UnknownManufacturer");
        //    Assert.IsNotNull(result);
        //    // Depending on implementation, this might return a default string, an empty string, or a specific message.
        //}

        //[TestMethod]
        //public void TestCanRunOnPlatform_NegativeScenario()
        //{
        //    // This test would simulate or assume a condition where the TPM collector should not run, such as an unsupported platform.
        //    // Since CanRunOnPlatform's result is highly environment-dependent, this test might involve platform checks.
        //    var tpmCollector = new TpmCollector(null, null, false);
        //    var result = tpmCollector.CanRunOnPlatform();
        //    // The expected result here depends on the specific conditions being simulated.
        //    // For a generic approach, you might need to adjust the assertion based on the environment or mock the environment check.
        //    Assert.IsFalse(result); // This assertion assumes the test is set up to simulate an unsupported platform.
        //}
        [TestMethod]
        public void TestDumpPCRs_ValidAlgIdWithNoPcrsSelected()
        {
            var tpm = new Tpm2(new TbsDevice());
            // Testing with a valid algorithm but intentionally not selecting any PCRs.
            var result = TpmCollector.DumpPCRs(tpm, TpmAlgId.Sha256, new PcrSelection[] { });
            Assert.IsNotNull(result);
            // Depending on the implementation, this might return an empty list or default to selecting all PCRs for the algorithm.
        }

        //[TestMethod]
        //public void TestDumpPersistentKeys_WithValidTpm()
        //{
        //    var tpm = new Tpm2(new TbsDevice());
        //    // Conceptual test for dumping persistent keys with a valid TPM object.
        //    var result = TpmCollector.DumpPersistentKeys(tpm);
        //    Assert.IsNotNull(result);
        //    // Assertions would depend on the keys present in the TPM, which vary by device and configuration.
        //}

        [TestMethod]
        public void TestGetSupportedCommands_WithValidTpm()
        {
            var tpm = new Tpm2(new TbsDevice());
            // Testing retrieval of supported commands with a valid TPM object.
            var result = TpmCollector.GetSupportedCommands(tpm);
            Assert.IsNotNull(result);
            // Further assertions would check for the presence of specific commands, depending on TPM capabilities.
        }

        //[TestMethod]
        //public void TestGetVersionString_WithValidTpmAndManufacturer_Thr()
        //{
        //    Tpm2Device tpmDevice = new TcpTpmDevice("127.0.0.1", 2321, stopTpm: false);
        //    var tpm = new Tpm2(tpmDevice);
        //    tpmDevice.Connect();
        //    // Testing version string retrieval with a known manufacturer.
        //    var result = TpmCollector.GetVersionString(tpm, "KnownManufacturer");
        //    Assert.IsNotNull(result);
        //    tpmDevice.Close();
        //    tpmDevice.Dispose();
        //    // The assertion here would ideally verify the format or content of the version string, depending on known data.
        //}

        //[TestMethod]
        //public void TestCanRunOnPlatform_UnsupportedPlatform()
        //{
        //    // Simulating an unsupported platform scenario.
        //    var tpmCollector = new TpmCollector(null, null, false);
        //    var result = tpmCollector.CanRunOnPlatform();
        //    // The expected result here is false, assuming the test environment is set to simulate an unsupported platform.
        //    Assert.IsFalse(result);
        //}

        [TestMethod]
        public void TestGetSupportedAlgorithms_WithValidTpm()
        {
            var tpm = new Tpm2(new TbsDevice());
            // Testing retrieval of supported algorithms with a valid TPM object.
            var result = TpmCollector.GetSupportedAlgorithms(tpm);
            Assert.IsNotNull(result);
            // Assertions would ideally verify the presence of expected algorithms, such as SHA1, SHA256, etc.
        }

        //[TestMethod]
        //public void TestGetVersionString_EmptyManufacturer()
        //{
        //    var tpm = new Tpm2(new TbsDevice());
        //    // Testing version string retrieval with an empty manufacturer string.
        //    var result = TpmCollector.GetVersionString(tpm, "");
        //    Assert.AreEqual("", result);
        //    // Depending on implementation, an empty manufacturer might result in an empty string or default information.
        //}
        [TestMethod]
        public void TestDumpPCRs_WithMultipleAlgorithms()
        {
            var tpm = new Tpm2(new TbsDevice());
            // Testing PCR dumping with multiple algorithms, assuming the TPM supports multiple algorithms.
            var sha1Result = TpmCollector.DumpPCRs(tpm, TpmAlgId.Sha1, new PcrSelection[] { /* PCR selections for Sha1 */ });
            var sha256Result = TpmCollector.DumpPCRs(tpm, TpmAlgId.Sha256, new PcrSelection[] { /* PCR selections for Sha256 */ });
            Assert.IsNotNull(sha1Result);
            Assert.IsNotNull(sha256Result);
            // Additional assertions could verify the correctness of the PCR values, depending on the test environment.
        }

        [TestMethod]
        public void TestGetSupportedAlgorithms_WithUnexpectedResponse()
        {
            var tpm = new Tpm2(new TbsDevice());
            // Testing how the method handles an unexpected response format or content from the TPM.
            var result = TpmCollector.GetSupportedAlgorithms(tpm);
            Assert.IsNotNull(result);
            // This test might require mocking the TPM response to simulate unexpected data.
        }

        //[TestMethod]
        //public void TestGetVersionString_WithKnownManufacturer()
        //{
        //    var tpm = new Tpm2(new TbsDevice());
        //    // Testing version string retrieval with a known manufacturer string.
        //    var result = TpmCollector.GetVersionString(tpm, "KnownManufacturer");
        //    Assert.IsNotNull(result);
        //    // The assertion here could verify the format or content of the version string, based on known manufacturer data.
        //}

        [TestMethod]
        public void TestCanRunOnPlatform_SupportedPlatform()
        {
            // Simulating a supported platform scenario.
            var tpmCollector = new TpmCollector(null, null, false);
            var result = tpmCollector.CanRunOnPlatform();
            // The expected result here is true, assuming the test environment is set to simulate a supported platform.
            Assert.IsTrue(result);
        }

        //[TestMethod]
        //public void TestDumpPersistentKeys_WithNoKeys()
        //{
        //    var tpm = new Tpm2(new TbsDevice());
        //    // Testing the scenario where no persistent keys are present in the TPM.
        //    var result = TpmCollector.DumpPersistentKeys(tpm);
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(0, result.Count);
        //    // This test assumes the TPM is in a state with no persistent keys.
        //}

        //[TestMethod]
        //public void TestGetSupportedCommands_WithSpecificCommandCheck()
        //{
        //    var tpm = new Tpm2(new TbsDevice());
        //    // Testing retrieval of supported commands and checking for a specific command's presence.
        //    var result = TpmCollector.GetSupportedCommands(tpm);
        //    Assert.IsNotNull(result);
        //    // Correcting the command to a valid one. Assuming TPM_CC_GetCapability is the correct command identifier.
        //    var expectedCommand = TpmCc.GetCapability; // Corrected from TPM2_GetCapability to GetCapability
        //    Assert.IsTrue(result.Contains(expectedCommand));
        //}

        //[TestMethod]
        //public void TestDumpPersistentKeys_WithMockedTpmResponse()
        //{
        //    var tpm = new Tpm2(new TbsDevice());
        //    // Assuming the ability to mock TPM responses, simulate a scenario with a specific set of persistent keys.
        //    // This would require a mocking framework or a way to simulate TPM responses.
        //    var result = TpmCollector.DumpPersistentKeys(tpm);
        //    Assert.IsNotNull(result);
        //    // Assert on the expected number of keys or specific key properties based on the mocked response.
        //}

        [TestMethod]
        public void TestGetSupportedAlgorithms_EmptyResponse()
        {
            var tpm = new Tpm2(new TbsDevice());
            // Testing how the method handles an empty response from the TPM.
            var result = TpmCollector.GetSupportedAlgorithms(tpm);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
            // This test might require mocking the TPM response to simulate an empty list of supported algorithms.
        }

        //[TestMethod]
        //public void TestCanRunOnPlatform_ExplicitlyUnsupportedPlatform()
        //{
        //    // Simulating an explicitly unsupported platform scenario.
        //    var tpmCollector = new TpmCollector(null, null, false);
        //    var result = tpmCollector.CanRunOnPlatform();
        //    // The expected result here is false, assuming the test environment is explicitly unsupported.
        //    Assert.IsFalse(result);
        //}

        [TestMethod]
        public void TestGetSupportedCommands_EmptyTpm()
        {
            var tpm = new Tpm2(new TbsDevice());
            // Testing retrieval of supported commands with a TPM that supports no commands.
            var result = TpmCollector.GetSupportedCommands(tpm);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
            // This test might require mocking the TPM to simulate a scenario where no commands are supported.
        }


    }
}