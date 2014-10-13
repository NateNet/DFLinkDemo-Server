// -----------------------------------------------------------------------
// <copyright file="ITask.cs" company="">
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
    /// The interface to the Task DAL.
    /// </summary>
    public interface ITask
    {
        /// <summary>
        /// get tasks lists by business license key
        /// </summary>
        /// <param name="licenseKey">business license key</param>
        /// <param name="errmsg">out error message when exception happend</param>
        /// <returns>the list of TaskItem</returns>
        IList<TaskItem> GetTasks(string licenseKey);

        /// <summary>
        /// update task status by task id
        /// </summary>
        /// <param name="taskId">task id</param>
        /// <param name="newStatus">new status</param>
        /// <param name="errmsg"></param>
        /// <returns></returns>
        bool UpdateTaskStatus(int taskId, int newStatus, string licenseKey);

        /// <summary>
        /// Get task parameters to a dictionary(key=value)
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="licenseKey"></param>
        /// <returns></returns>
        Dictionary<string, string> GetTaskParameters(int taskId, string licenseKey);

        /// <summary>
        /// Get task schedule to a dictionary(key=value)
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="licenseKey"></param>
        /// <returns></returns>
        Dictionary<string, string> GetTaskSchedule(int taskId, string licenseKey);
    }
}
