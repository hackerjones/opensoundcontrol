using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenSoundControl;

namespace UnitTests
{
    ///<summary>
    ///  This is a test class for OscUdpIoDeviceTest and is intended
    ///  to contain all OscUdpIoDeviceTest Unit Tests
    ///</summary>
    [TestClass]
    public class OscUdpIoDeviceTest
    {
        ///<summary>
        ///  Gets or sets the test context which provides
        ///  information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes

        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //

        #endregion

        ///<summary>
        ///  A test for OscUdpIoDevice Constructor
        ///</summary>
        [TestMethod]
        public void OscUdpIoDeviceConstructorTest()
        {
            IPEndPoint localEP = null; // TODO: Initialize to an appropriate value
            var target = new OscUdpIoDevice(localEP);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        ///<summary>
        ///  A test for OscUdpIoDevice Constructor
        ///</summary>
        [TestMethod]
        public void OscUdpIoDeviceConstructorTest1()
        {
            int localPort = 0; // TODO: Initialize to an appropriate value
            var target = new OscUdpIoDevice(localPort);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        ///<summary>
        ///  A test for BeginReceive
        ///</summary>
        [TestMethod]
        [DeploymentItem("OpenSoundControl.dll")]
        public void BeginReceiveTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            var target = new OscUdpIoDevice_Accessor(param0); // TODO: Initialize to an appropriate value
            target.BeginReceive();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        ///<summary>
        ///  A test for Dispose
        ///</summary>
        [TestMethod]
        [DeploymentItem("OpenSoundControl.dll")]
        public void DisposeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            var target = new OscUdpIoDevice_Accessor(param0); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        ///<summary>
        ///  A test for Dispose
        ///</summary>
        [TestMethod]
        public void DisposeTest1()
        {
            IPEndPoint localEP = null; // TODO: Initialize to an appropriate value
            var target = new OscUdpIoDevice(localEP); // TODO: Initialize to an appropriate value
            target.Dispose();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        ///<summary>
        ///  A test for Finalize
        ///</summary>
        [TestMethod]
        [DeploymentItem("OpenSoundControl.dll")]
        public void FinalizeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            var target = new OscUdpIoDevice_Accessor(param0); // TODO: Initialize to an appropriate value
            target.Finalize();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        ///<summary>
        ///  A test for OnReceive
        ///</summary>
        [TestMethod]
        [DeploymentItem("OpenSoundControl.dll")]
        public void OnReceiveTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            var target = new OscUdpIoDevice_Accessor(param0); // TODO: Initialize to an appropriate value
            IAsyncResult ar = null; // TODO: Initialize to an appropriate value
            target.OnReceive(ar);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        ///<summary>
        ///  A test for OnSend
        ///</summary>
        [TestMethod]
        [DeploymentItem("OpenSoundControl.dll")]
        public void OnSendTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            var target = new OscUdpIoDevice_Accessor(param0); // TODO: Initialize to an appropriate value
            IAsyncResult ar = null; // TODO: Initialize to an appropriate value
            target.OnSend(ar);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        ///<summary>
        ///  A test for Send
        ///</summary>
        [TestMethod]
        public void SendTest()
        {
            IPEndPoint localEP = null; // TODO: Initialize to an appropriate value
            var target = new OscUdpIoDevice(localEP); // TODO: Initialize to an appropriate value
            OscBundle bundle = null; // TODO: Initialize to an appropriate value
            OscIoDeviceAddress deviceAddress = null; // TODO: Initialize to an appropriate value
            target.Send(bundle, deviceAddress);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        ///<summary>
        ///  A test for Send
        ///</summary>
        [TestMethod]
        public void SendTest1()
        {
            IPEndPoint localEP = null; // TODO: Initialize to an appropriate value
            var target = new OscUdpIoDevice(localEP); // TODO: Initialize to an appropriate value
            OscMessage message = null; // TODO: Initialize to an appropriate value
            OscIoDeviceAddress deviceAddress = null; // TODO: Initialize to an appropriate value
            target.Send(message, deviceAddress);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
