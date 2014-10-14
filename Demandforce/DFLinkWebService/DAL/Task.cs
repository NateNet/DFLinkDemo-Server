// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Task.cs" company="Demandforce">
//   TODO:
// </copyright>
// <summary>
//   a DAL class implement ITask
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Demandforce.DFLinkServer.DAL
{
    #region

    using System.Collections.Generic;
    using System.Linq;

    using Demandforce.DFLinkServer.DAL.Data;
    using Demandforce.DFLinkServer.IDAL;
    using Demandforce.DFLinkServer.Model;

    #endregion

    /// <summary>
    ///     a DAL class implement ITask
    /// </summary>
    public class Task : ITask
    {
        #region Constants

        /// <summary>
        ///     the task status that can be sent to client
        /// </summary>
        private const int TASK_STATUS_NEW = 0;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Get task parameters by task id
        /// </summary>
        /// <param name="taskId">
        /// task id
        /// </param>
        /// <param name="licenseKey">
        /// business license key 
        /// </param>
        /// ///
        /// <returns>
        /// an instance of UpdateParameters
        /// </returns>
        public Dictionary<string, string> GetTaskParameters(int taskId, string licenseKey)
        {
            var dfEnt = new DFLinkSTEntities();
            var rows = from tp in dfEnt.TaskParameters
                       where tp.TaskId == taskId & tp.LicenseKey == licenseKey
                       select new { tp.Key, tp.Value };
            if (rows.Any())
            {
                return rows.ToDictionary(row => row.Key, row => row.Value);
            }

            return null;
        }

        /// <summary>
        /// Get real time task schedule
        /// </summary>
        /// <param name="taskId">
        /// task id
        /// </param>
        /// <param name="licenseKey">
        /// business license key
        /// </param>
        /// ///
        /// <returns>
        /// an instance of RealTimeSchedule
        /// </returns>
        public Dictionary<string, string> GetTaskSchedule(int taskId, string licenseKey)
        {
            var dfEnt = new DFLinkSTEntities();
            var rows = from ts in dfEnt.TaskSchedules
                       where ts.LicenseKey == licenseKey & ts.TaskId == taskId
                       select new { ts.Key, ts.Value };
            if (rows.Any())
            {
                return rows.ToDictionary(row => row.Key, row => row.Value);
            }

            return null;
        }

        /// <summary>
        /// Get tasks list by a business license key
        /// </summary>
        /// <param name="licenseKey">
        /// business license key. 
        /// </param>
        /// <returns>
        /// true: succeeded, false: failed.
        /// </returns>
        public IList<TaskItem> GetTasks(string licenseKey)
        {
            using (var dfEnt = new DFLinkSTEntities())
            {
                var tasklist = from t1 in dfEnt.Tasks
                               where t1.LicenseKey.Equals(licenseKey) & t1.Status == TASK_STATUS_NEW
                               select t1;

                if (tasklist.Any())
                {
                    IList<TaskItem> tasks = new List<TaskItem>();
                    foreach (var t in tasklist)
                    {
                        var task = new TaskItem
                                       {
                                           Id = t.Id, 
                                           BusinessLicense = t.LicenseKey, 
                                           Name = t.Name, 
                                           Action = t.Action, 
                                           Description = t.Description, 
                                           ScheduleType = t.ScheduleType
                                       };
                        tasks.Add(task);
                    }

                    return tasks;
                }

                return null;
            }
        }

        /// <summary>
        /// Update task status.
        /// </summary>
        /// <param name="taskId">
        /// task id 
        /// </param>
        /// <param name="newStatus">
        /// new status 
        /// </param>
        /// <param name="licenseKey">
        /// business license key 
        /// </param>
        /// <returns>
        /// true: succeeded, false: failed.
        /// </returns>
        public bool UpdateTaskStatus(int taskId, int newStatus, string licenseKey)
        {
            DFLinkSTEntities dfEnt = new DFLinkSTEntities();
            var task = new Data.Task { Id = taskId, LicenseKey = licenseKey, Status = newStatus };
            dfEnt.Tasks.Attach(task);
            dfEnt.ObjectStateManager.GetObjectStateEntry(task).SetModifiedProperty("Status");

            return dfEnt.SaveChanges() > 0;
        }

        #endregion
    }
}