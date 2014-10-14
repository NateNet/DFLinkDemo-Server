// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILog.cs" company="Demandforce">
//   TODO:
// </copyright>
// <summary>
//   Interface to the Log DAL
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Demandforce.DFLinkServer.IDAL
{
    #region

    using System.Collections.Generic;

    using Demandforce.DFLinkServer.Model;

    #endregion

    /// <summary>
    ///     Interface to the Log DAL
    /// </summary>
    public interface ILog
    {
        #region Public Methods and Operators

        /// <summary>
        /// Get logs list by task id.
        /// </summary>
        /// <param name="taskId">
        /// task id 
        /// </param>
        /// <param name="licenseKey">
        /// The license Key. 
        /// </param>
        /// <returns>
        /// The list of LogItem 
        /// </returns>
        IList<LogItem> GetLogs(int taskId, string licenseKey);

        /// <summary>
        /// Insert a new log item 
        /// </summary>
        /// <param name="logItem">
        /// an instance of LogItem
        /// </param>
        /// <param name="licenseKey">
        /// The business license Key.
        /// </param>
        /// <returns>
        /// true: succeeded, false: failed.
        /// </returns>
        bool Upload(LogItem logItem, string licenseKey);

        #endregion
    }
}