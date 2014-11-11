// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskTest.cs" company="Demandforce">
//   Copyright (c) Demandforce. All rights reserved.
// </copyright>
// <summary>
//   This is a test class for TaskTest and is intended
//   to contain all TaskTest Unit Tests
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace BLL.Tests
{
    #region

    using System.Collections.Generic;

    using Demandforce.DFLinkServer.BLL;
    using Demandforce.DFLinkServer.Model;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    #endregion

    /// <summary>
    ///     This is a test class for TaskTest and is intended
    ///     to contain all TaskTest Unit Tests
    /// </summary>
    [TestClass]
    public class TaskTest
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
        ///     A test for GetTasks
        /// </summary>
        [TestMethod]
        public void GetTasksTest()
        {
            var name = "Update";
            var id = 1;
            var license = "license";

            var item = new TaskItem { Id = id, Name = name, BusinessLicense = license };
            IList<TaskItem> tasks = new List<TaskItem>();
            tasks.Add(item);

            var mock = new Mock<Demandforce.DFLinkServer.IDAL.ITask>();
            mock.Setup(p => p.GetTasks(license)).Returns(tasks);

            var target = new Task { TaskDal = mock.Object }; 

            var actual = target.GetTasks("license");

            Assert.AreEqual(actual[0].Id, id);
            Assert.AreEqual(actual[0].Name, name);
            Assert.AreEqual(actual[0].BusinessLicense, license);

            // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///     A test for Task Constructor
        /// </summary>
        [TestMethod]
        public void TaskConstructorTest()
        {
            var target = new Task();
            Assert.IsNotNull(target);

            // Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///     A test for ToXml
        /// </summary>
        [TestMethod]
        public void ToXmlTest()
        {
            var target = new Task(); 
            IList<TaskItem> tasks = null; 
            var expected = "<Tasks></Tasks>";

            var actual = target.ToXml(tasks);
            Assert.AreEqual(expected, actual);

            // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///     A test for ExecuteResult
        /// </summary>
        [TestMethod]
        public void SaveExecuteResultTest()
        {
            var mock = new Mock<Demandforce.DFLinkServer.IDAL.ITask>();
            mock.Setup(p => p.SaveExecuteResult(0, 9, "message", "license")).Returns(true);

            var target = new Task { TaskDal = mock.Object };

            bool actual = target.SaveExecuteResult(0, 9, "message", "license");
            
            Assert.AreEqual(true, actual);

            // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        #endregion
    }
}