// -----------------------------------------------------------------------
// <copyright file="Log.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------
namespace Demandforce.DFLinkServer.BLL
{
    using System.Collections.Generic;
    using Demandforce.DFLinkServer.IDAL;
    using Demandforce.DFLinkServer.Model;

    /// <summary>
    /// The business component to manage logs
    /// </summary>
    public class Log
    {
        /// <summary>
        /// Get an instance of the Log DAL using DALFactory.
        /// </summary>
        private readonly ILog dal = DALFactory.DataAccess.CreateLogDAL();

        /// <summary>
        /// upload log to message.
        /// </summary>
        /// <param name="log">an instance of LogItem</param>
        /// <returns>true: success, false: failed.</returns>
        public bool Upload(LogItem log, string licenseKey)
        {
            return dal.Upload(log, licenseKey);
        }

        /// <summary>
        /// Get the log list by a task id.
        /// </summary>
        /// <param name="taskId">task id</param>
        /// <returns>the array list of LogItem</returns>
        public IList<LogItem> GetLogs(int taskId, string licenseKey)
        {
            return dal.GetLogs(taskId, licenseKey);
        }
    }
}