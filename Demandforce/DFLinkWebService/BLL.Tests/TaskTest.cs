// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskTest.cs" company="Demandforce">
//   TODO:
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
            Task target = new Task(); // TODO: Initialize to an appropriate value
            string licenseKey = "xxxxx-xxxxxx"; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            IList<TaskItem> actual;
            actual = target.GetTasks(licenseKey);
            Assert.AreNotEqual(expected, actual.Count);

            // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///     A test for Task Constructor
        /// </summary>
        [TestMethod]
        public void TaskConstructorTest()
        {
            Task target = new Task();
            Assert.IsNotNull(target);

            // Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///     A test for ToXml
        /// </summary>
        [TestMethod]
        public void ToXmlTest()
        {
            Task target = new Task(); // TODO: Initialize to an appropriate value
            IList<TaskItem> tasks = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ToXml(tasks);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///     A test for UpdateTaskStatus
        /// </summary>
        [TestMethod]
        public void UpdateTaskStatusTest()
        {
            Task target = new Task(); // TODO: Initialize to an appropriate value
            int taskId = 0; // TODO: Initialize to an appropriate value
            int newStatus = 9; // TODO: Initialize to an appropriate value
            string licenseKey = "xxxxx-xxxxxx"; // TODO: Initialize to an appropriate value
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.UpdateTaskStatus(taskId, newStatus, licenseKey);
            Assert.AreEqual(expected, actual);

            // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        #endregion
    }
}