using Demandforce.DFLinkServer.BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Demandforce.DFLinkServer.Model;
using System.Collections.Generic;

namespace BLL.Tests
{
    
    
    /// <summary>
    ///This is a test class for LogTest and is intended
    ///to contain all LogTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LogTest
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
        ///A test for Log Constructor
        ///</summary>
        [TestMethod()]
        public void LogConstructorTest()
        {
            Log target = new Log();
            Assert.IsNotNull(target);
            //Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetLogs
        ///</summary>
        [TestMethod()]
        public void GetLogsTest()
        {
            Log target = new Log(); // TODO: Initialize to an appropriate value
            int taskId = 1; // TODO: Initialize to an appropriate value
            string licenseKey = "xxxxx-xxxxxx"; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            IList<LogItem> actual;
            actual = target.GetLogs(taskId, licenseKey);
            Assert.AreEqual(expected, actual.Count);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Upload
        ///</summary>
        [TestMethod()]
        public void UploadTest()
        {
            Log target = new Log(); // TODO: Initialize to an appropriate value
            LogItem log = new LogItem { CreateDate=DateTime.Now, Message="BLL upload log test", TaskId=0}; // TODO: Initialize to an appropriate value
            string licenseKey = "xxxxx-xxxxxx"; // TODO: Initialize to an appropriate value
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Upload(log, licenseKey);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
