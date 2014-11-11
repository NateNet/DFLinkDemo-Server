// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogTest.cs" company="Demandforce">
//   Copyright (c) Demandforce. All rights reserved.
// </copyright>
// <summary>
//   This is a test class for LogTest and is intended
//   to contain all LogTest Unit Tests
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace BLL.Tests
{
    #region

    using System;
    using System.Collections.Generic;

    using Demandforce.DFLinkServer.BLL;
    using Demandforce.DFLinkServer.Model;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    #endregion

    /// <summary>
    ///     This is a test class for LogTest and is intended
    ///     to contain all LogTest Unit Tests
    /// </summary>
    [TestClass]
    public class LogTest
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the test context which provides
        ///     information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        #endregion

        // You can use the following additional attributes as you write your tests:
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext)
        // {
        // }
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup()
        // {
        // }
        // Use TestInitialize to run code before running each test
        // [TestInitialize()]
        // public void MyTestInitialize()
        // {
        // }
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup()
        // {
        // }
        #region Public Methods and Operators

        /// <summary>
        ///     A test for GetLogs
        /// </summary>
        [TestMethod]
        public void GetLogsTest()
        {
            var license = "license";
            var taskId = 0;
            var id = 1;
            var message = "get log test";

            var logs = new List<LogItem>();
            var item = new LogItem { Id = id, TaskId = taskId, Message = message };
            logs.Add(item);

            var mock = new Mock<Demandforce.DFLinkServer.IDAL.ILog>();
            mock.Setup(p => p.GetLogs(taskId, license)).Returns(logs);

            var target = new Log(); // TODO: Initialize to an appropriate value
            target.Dal = mock.Object;

            var actual = target.GetLogs(taskId, license);
            Assert.AreEqual(actual[0].Id, id);
            Assert.AreEqual(actual[0].TaskId, taskId);
            Assert.AreEqual(actual[0].Message, message);
        }

        /// <summary>
        ///     A test for Log Constructor
        /// </summary>
        [TestMethod]
        public void LogConstructorTest()
        {
            var target = new Log();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///     A test for Upload
        /// </summary>
        [TestMethod]
        public void UploadTest()
        {
            var log = new LogItem { CreateDate = DateTime.Now, Message = "BLL upload log test", TaskId = 0 };
            var license = "license";

            var mock = new Mock<Demandforce.DFLinkServer.IDAL.ILog>();
            mock.Setup(p => p.Upload(log, license)).Returns(true);

            var target = new Log();
            target.Dal = mock.Object;

            var actual = target.Upload(log, license);
            Assert.AreEqual(true, actual);
        }

        #endregion
    }
}