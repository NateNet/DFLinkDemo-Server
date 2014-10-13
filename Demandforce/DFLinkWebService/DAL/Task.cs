// -----------------------------------------------------------------------
// <copyright file="Task.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Demandforce.DFLinkServer.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Demandforce.DFLinkServer.IDAL;
    using Demandforce.DFLinkServer.Model;

    /// <summary>
    /// a DAL class implement ITask
    /// </summary>
    public partial class Task : ITask
    {
        // closed task
        const int TASK_STATUS_NEW = 0;
        /// <summary>
        /// Get tasks list by a business license key
        /// </summary>
        /// <param name="license">business license key.</param>
        /// <param name="errmsg">out error message when exception happend</param>
        /// <returns>true: successed, false: failed.</returns>
        public IList<TaskItem> GetTasks(string licenseKey)
        {
            using (var dfEnt = new Data.DFLinkSTEntities())
            {
                var tasklist = from t1 in dfEnt.Tasks
                               where t1.LicenseKey.Equals(licenseKey) & t1.Status == TASK_STATUS_NEW
                               select t1;

                if (tasklist.Count() > 0)
                {
                    IList<TaskItem> tasks = new List<TaskItem>();
                    foreach (var t in tasklist)
                    {
                        var task = new TaskItem();
                        task.Id = t.Id;
                        task.BusinessLicense = t.LicenseKey;
                        task.Name = t.Name;
                        task.Action = t.Action;
                        task.Description = t.Description;
                        task.ScheduleType = t.ScheduleType;
                        tasks.Add(task);
                    }
                    return tasks;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Update task status.
        /// </summary>
        /// <param name="taskId">task id</param>
        /// <param name="newStatus">new status</param>
        /// <param name="errmsg">out error message when exception happend</param>
        /// <returns>true: successed, false: failed.</returns>
        public bool UpdateTaskStatus(int taskId, int newStatus, string licenseKey)
        {
            Data.DFLinkSTEntities dfEnt = new Data.DFLinkSTEntities();
            var task = new Data.Task()
            {
                Id = taskId,
                LicenseKey = licenseKey,
                Status = newStatus
            };
            dfEnt.Tasks.Attach(task);
            dfEnt.ObjectStateManager.GetObjectStateEntry(task).SetModifiedProperty("Status");

            if (dfEnt.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Get task parameters by task id
        /// </summary>
        /// <param name="taskId">task id</param>
        /// <returns>an instance of UpdateParameters</returns>
        public Dictionary<string, string> GetTaskParameters(int taskId, string licenseKey)
        {
            var dfEnt = new Data.DFLinkSTEntities();
            var rows = from tp in dfEnt.TaskParameters
                       where tp.TaskId == taskId & tp.LicenseKey == licenseKey
                       select new {tp.Key, tp.Value};
            if (rows.Count() > 0)
            {
                Dictionary<string, string> taskPara = new Dictionary<string, string>();
                foreach (var row in rows)
                {
                    taskPara.Add(row.Key, row.Value);
                }
                return taskPara;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get real time task schedule
        /// </summary>
        /// <param name="taskId">task id</param>
        /// <returns>an instance of RealTimeSchedule</returns>
        public Dictionary<string, string> GetTaskSchedule(int taskId, string licenseKey)
        {
            var dfEnt = new Data.DFLinkSTEntities();
            var rows = from ts in dfEnt.TaskSchedules
                       where ts.LicenseKey == licenseKey & ts.TaskId == taskId
                       select new { ts.Key, ts.Value};
            if (rows.Count() > 0)
            {
                Dictionary<string, string> taskSch = new Dictionary<string, string>();
                foreach (var row in rows)
                {
                    taskSch.Add(row.Key, row.Value);
                }
                return taskSch;
            }
            else
            {
                return null;
            }
        }
    }
}