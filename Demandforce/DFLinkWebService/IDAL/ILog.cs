// -----------------------------------------------------------------------
// <copyright file="ILog.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Demandforce.DFLinkServer.IDAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Demandforce.DFLinkServer.Model;

    /// <summary>
    /// Interface to the Log DAL
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// Insert a new log item
        /// </summary>
        /// <param name="logItem">an instance of LogItem</param>
        /// <param name="errmsg">out error message when exception happend</param>
        /// <returns>true: successed, false: failed.</returns>
        bool Upload(LogItem logItem, string licenseKey);
        
        /// <summary>
        /// Get logs list by task id.
        /// </summary>
        /// <param name="taskId">task id</param>
        /// <param name="errmsg">out error message when exception happend</param>
        /// <returns>The list of LogItem</returns>
        IList<LogItem> GetLogs(int taskId, string licenseKey);
    }
}
