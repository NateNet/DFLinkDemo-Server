// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITask.cs" company="Demandforce">
//   Copyright (c) Demandforce. All rights reserved.
// </copyright>
// <summary>
//   The interface to the Task DAL.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Demandforce.DFLinkServer.IDAL
{
    #region

    using System.Collections.Generic;

    using Demandforce.DFLinkServer.Model;

    #endregion

    /// <summary>
    ///     The interface to the Task DAL.
    /// </summary>
    public interface ITask
    {
        #region Public Methods and Operators

        /// <summary>
        /// Get task parameters to a dictionary(key=value)
        /// </summary>
        /// <param name="taskId">
        /// task id
        /// </param>
        /// <param name="licenseKey">
        /// business license key 
        /// </param>
        /// <returns>
        /// the key=value object list of the task
        /// </returns>
        Dictionary<string, string> GetTaskParameters(int taskId, string licenseKey);

        /// <summary>
        /// Get task schedule to a dictionary(key=value)
        /// </summary>
        /// <param name="taskId">
        /// task id
        /// </param>
        /// <param name="licenseKey">
        /// business license key 
        /// </param>
        /// <returns>
        /// the key=value object list 
        /// </returns>
        Dictionary<string, string> GetTaskSchedule(int taskId, string licenseKey);

        /// <summary>
        /// get tasks lists by business license key
        /// </summary>
        /// <param name="licenseKey">
        /// business license key
        /// </param>
        /// <returns>
        /// the list of TaskItem
        /// </returns>
        IList<TaskItem> GetTasks(string licenseKey);

        /// <summary>
        /// update task status by task id
        /// </summary>
        /// <param name="taskId">
        /// task id
        /// </param>
        /// <param name="newStatus">
        /// new status
        /// </param>
        /// <param name="message">returned message of a task</param>
        /// <param name="licenseKey">
        /// business license key
        /// </param>
        /// <returns>
        /// true: succeeded, false: failed
        /// </returns>
        bool SaveExecuteResult(int taskId, int newStatus, string message, string licenseKey);

        #endregion
    }
}