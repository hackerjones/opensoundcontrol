using System.Text;
using OpenSoundControl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace UnitTests
{


    /// <summary>
    ///This is a test class for OscTypeTagStringTest and is intended
    ///to contain all OscTypeTagStringTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OscTypeTagStringTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

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


        /// <summary>
        ///A test for OscTypeTagString Constructor
        ///</summary>
        [TestMethod()]
        public void OscTypeTagStringConstructorTest()
        {
            IEnumerable<OscElementType> args = new[]
                                                   {
                                                       OscElementType.Address, OscElementType.Blob,
                                                       OscElementType.Bundle,
                                                       OscElementType.False, OscElementType.Float32,
                                                       OscElementType.Impulse, OscElementType.Int32,
                                                       OscElementType.Message, OscElementType.Null,
                                                       OscElementType.String, OscElementType.Timetag,
                                                       OscElementType.True, OscElementType.TypeTagString,
                                                       OscElementType.UInt32
                                                   };
            OscTypeTagString target = new OscTypeTagString(args);
            Assert.IsFalse(target.Arguments.Contains(OscElementType.Address));
            Assert.IsTrue(target.Arguments.Contains(OscElementType.Blob));
            Assert.IsFalse(target.Arguments.Contains(OscElementType.Bundle));
            Assert.IsTrue(target.Arguments.Contains(OscElementType.False));
            Assert.IsTrue(target.Arguments.Contains(OscElementType.Float32));
            Assert.IsTrue(target.Arguments.Contains(OscElementType.Impulse));
            Assert.IsTrue(target.Arguments.Contains(OscElementType.Int32));
            Assert.IsFalse(target.Arguments.Contains(OscElementType.Message));
            Assert.IsTrue(target.Arguments.Contains(OscElementType.Null));
            Assert.IsTrue(target.Arguments.Contains(OscElementType.String));
            Assert.IsTrue(target.Arguments.Contains(OscElementType.Timetag));
            Assert.IsTrue(target.Arguments.Contains(OscElementType.True));
            Assert.IsFalse(target.Arguments.Contains(OscElementType.TypeTagString));
            Assert.IsTrue(target.Arguments.Contains(OscElementType.UInt32));
        }

        /// <summary>
        ///A test for OscTypeTagString Constructor
        ///</summary>
        [TestMethod()]
        public void OscTypeTagStringConstructorTest1()
        {
            OscTypeTagString target = new OscTypeTagString();
            Assert.IsFalse(target.Arguments.Count() > 0);
        }

        /// <summary>
        ///A test for FilterArguments
        ///</summary>
        [TestMethod()]
        [DeploymentItem("OpenSoundControl.dll")]
        public void FilterArgumentsTest()
        {
            var target = new OscTypeTagString_Accessor();
            IEnumerable<OscElementType> args = new[]
                                                   {
                                                       OscElementType.Address, OscElementType.Blob,
                                                       OscElementType.Bundle,
                                                       OscElementType.False, OscElementType.Float32,
                                                       OscElementType.Impulse, OscElementType.Int32,
                                                       OscElementType.Message, OscElementType.Null,
                                                       OscElementType.String, OscElementType.Timetag,
                                                       OscElementType.True, OscElementType.TypeTagString,
                                                       OscElementType.UInt32
                                                   };
            target.FilterArguments(args);
            Assert.IsFalse(target.Arguments.Contains(OscElementType.Address));
            Assert.IsTrue(target.Arguments.Contains(OscElementType.Blob));
            Assert.IsFalse(target.Arguments.Contains(OscElementType.Bundle));
            Assert.IsTrue(target.Arguments.Contains(OscElementType.False));
            Assert.IsTrue(target.Arguments.Contains(OscElementType.Float32));
            Assert.IsTrue(target.Arguments.Contains(OscElementType.Impulse));
            Assert.IsTrue(target.Arguments.Contains(OscElementType.Int32));
            Assert.IsFalse(target.Arguments.Contains(OscElementType.Message));
            Assert.IsTrue(target.Arguments.Contains(OscElementType.Null));
            Assert.IsTrue(target.Arguments.Contains(OscElementType.String));
            Assert.IsTrue(target.Arguments.Contains(OscElementType.Timetag));
            Assert.IsTrue(target.Arguments.Contains(OscElementType.True));
            Assert.IsFalse(target.Arguments.Contains(OscElementType.TypeTagString));
            Assert.IsTrue(target.Arguments.Contains(OscElementType.UInt32));
        }

        /// <summary>
        ///A test for ToPacketArray
        ///</summary>
        [TestMethod()]
        public void ToPacketArrayTest()
        {
            var target = new OscTypeTagString(new[]
                                                  {
                                                      OscElementType.Address, OscElementType.Blob,
                                                      OscElementType.Bundle,
                                                      OscElementType.False, OscElementType.Float32,
                                                      OscElementType.Impulse, OscElementType.Int32,
                                                      OscElementType.Message, OscElementType.Null,
                                                      OscElementType.String, OscElementType.Timetag,
                                                      OscElementType.True, OscElementType.TypeTagString,
                                                      OscElementType.UInt32
                                                  });
            var expected = new byte[] { 0x2c, 0x62, 0x46, 0x66, 0x49, 0x69, 0x4e, 0x73, 0x74, 0x54, 0x75, 0x0 };
            byte[] actual;
            actual = target.ToPacketArray();
            Assert.IsTrue(actual.Length == expected.Length, "Array size not equal");
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.IsTrue(expected[i] == actual[i], String.Format("expected[{0}] != actual[{0}]", i));
            }
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            OscTypeTagString target = new OscTypeTagString(new[]
                                                        {
                                                            OscElementType.Address, OscElementType.Blob,
                                                            OscElementType.Bundle,
                                                            OscElementType.False, OscElementType.Float32,
                                                            OscElementType.Impulse, OscElementType.Int32,
                                                            OscElementType.Message, OscElementType.Null,
                                                            OscElementType.String, OscElementType.Timetag,
                                                            OscElementType.True, OscElementType.TypeTagString,
                                                            OscElementType.UInt32
                                                        });
            string expected = ",bFfIiNstTu";
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for TypeTagChar
        ///</summary>
        [TestMethod()]
        [DeploymentItem("OpenSoundControl.dll")]
        public void TypeTagCharTest()
        {
            OscElementType type = new OscElementType();
            char expected = 'i';
            char actual;
            actual = OscTypeTagString_Accessor.TypeTagChar(OscElementType.Int32);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Arguments
        ///</summary>
        [TestMethod()]
        public void ArgumentsTest()
        {
            var target = new OscTypeTagString();
            var expected = new List<OscElementType>(new[]
                                                        {
                                                            OscElementType.Address, OscElementType.Blob,
                                                            OscElementType.Bundle,
                                                            OscElementType.False, OscElementType.Float32,
                                                            OscElementType.Impulse, OscElementType.Int32,
                                                            OscElementType.Message, OscElementType.Null,
                                                            OscElementType.String, OscElementType.Timetag,
                                                            OscElementType.True, OscElementType.TypeTagString,
                                                            OscElementType.UInt32
                                                        });
            List<OscElementType> actual;
            target.Arguments = expected;
            actual = target.Arguments;
            Assert.IsFalse(actual.Contains(OscElementType.Address));
            Assert.IsTrue(actual.Contains(OscElementType.Blob));
            Assert.IsFalse(actual.Contains(OscElementType.Bundle));
            Assert.IsTrue(actual.Contains(OscElementType.False));
            Assert.IsTrue(actual.Contains(OscElementType.Float32));
            Assert.IsTrue(actual.Contains(OscElementType.Impulse));
            Assert.IsTrue(actual.Contains(OscElementType.Int32));
            Assert.IsFalse(actual.Contains(OscElementType.Message));
            Assert.IsTrue(actual.Contains(OscElementType.Null));
            Assert.IsTrue(actual.Contains(OscElementType.String));
            Assert.IsTrue(actual.Contains(OscElementType.Timetag));
            Assert.IsTrue(actual.Contains(OscElementType.True));
            Assert.IsFalse(actual.Contains(OscElementType.TypeTagString));
            Assert.IsTrue(actual.Contains(OscElementType.UInt32));
        }

        /// <summary>
        ///A test for ElementType
        ///</summary>
        [TestMethod()]
        public void ElementTypeTest()
        {
            OscTypeTagString target = new OscTypeTagString();
            OscElementType actual;
            actual = target.ElementType;
            Assert.AreEqual(actual, OscElementType.TypeTagString);
        }

        /// <summary>
        ///A test for IsArgument
        ///</summary>
        [TestMethod()]
        public void IsArgumentTest()
        {
            OscTypeTagString target = new OscTypeTagString();
            bool actual;
            actual = target.IsArgument;
            Assert.IsFalse(actual);
        }

        /// <summary>
        ///A test for Value
        ///</summary>
        [TestMethod()]
        public void ValueTest()
        {
            OscTypeTagString target = new OscTypeTagString(new[]
                                                               {
                                                                   OscElementType.Address, OscElementType.Blob,
                                                                   OscElementType.Bundle,
                                                                   OscElementType.False, OscElementType.Float32,
                                                                   OscElementType.Impulse, OscElementType.Int32,
                                                                   OscElementType.Message, OscElementType.Null,
                                                                   OscElementType.String, OscElementType.Timetag,
                                                                   OscElementType.True, OscElementType.TypeTagString,
                                                                   OscElementType.UInt32
                                                               });
            OscString actual;
            actual = target.Value;
            Assert.AreEqual(actual.ToString(), ",bFfIiNstTu");
        }
    }
}
