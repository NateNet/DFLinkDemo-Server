// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BusinessConfigTest.cs" company="Demandforce">
//   Copyright (c) Demandforce. All rights reserved.
// </copyright>
// <summary>
//   This is a test class for BusinessConfigTest and is intended
//   to contain all BusinessConfigTest Unit Tests
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace BLL.Tests
{
    #region

    using System;

    using Demandforce.DFLinkServer.BLL;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    #endregion

    /// <summary>
    ///     This is a test class for BusinessConfigTest and is intended
    ///     to contain all BusinessConfigTest Unit Tests
    /// </summary>
    [TestClass]
    public class BusinessConfigTest
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
        ///     A test for Save
        /// </summary>
        [TestMethod]
        public void SaveTest()
        {
            var taskId = 0; 
            var license = "license";
            var configContent = "config content";
            var createTime = Convert.ToDateTime("2014-10-01");

            var mock = new Mock<Demandforce.DFLinkServer.IDAL.IBusinessConfig>();
            mock.Setup(p => p.Insert(taskId, license, configContent, createTime)).Returns(true);

            var target = new BusinessConfig();
            target.Dal = mock.Object;

            bool actual;
            actual = target.Save(taskId, license, configContent);
            Assert.AreEqual(true, actual);
        }

        #endregion
    }
}