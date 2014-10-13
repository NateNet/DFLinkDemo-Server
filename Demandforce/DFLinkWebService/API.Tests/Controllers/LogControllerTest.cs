using Demandforce.DFLinkServer.API.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using Demandforce.DFLinkServer.Model.RequestBody;
using Demandforce.DFLinkServer.Model;
using System.Collections.Generic;

namespace API.Tests
{
    
    
    /// <summary>
    ///This is a test class for LogControllerTest and is intended
    ///to contain all LogControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LogControllerTest
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
        ///A test for LogController Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\workspace\\Demandforce\\DFLinkWebService\\API", "/")]
        [UrlToTest("http://localhost:20603/")]
        public void LogControllerConstructorTest()
        {
            LogController target = new LogController();
            Assert.IsNotNull(target);
            //Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Download
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\workspace\\Demandforce\\DFLinkWebService\\API", "/")]
        [UrlToTest("http://localhost:20603/")]
        public void DownloadTest()
        {
            LogController target = new LogController(); // TODO: Initialize to an appropriate value
            LogDownloadBody requestBody = new LogDownloadBody { BusinessCredentials = new BusinessCredentials { LicenseKey = "xxxxx-xxxxxx" }, TaskId = 1 }; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            IList<LogItem> actual;
            actual = target.Download(requestBody);
            Assert.AreNotEqual(expected, actual.Count);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Upload
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\workspace\\Demandforce\\DFLinkWebService\\API", "/")]
        [UrlToTest("http://localhost:20603/")]
        public void UploadTest()
        {
            LogController target = new LogController(); // TODO: Initialize to an appropriate value
            LogUploadBody requestBody = new LogUploadBody { BusinessCredentials = new BusinessCredentials { LicenseKey = "xxxxx-xxxxxx" }, Message = "upload log test", TaskId = 1 }; // TODO: Initialize to an appropriate value
            string expected = "1"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Upload(requestBody);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
