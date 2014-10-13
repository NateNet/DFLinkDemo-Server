// -----------------------------------------------------------------------
// <copyright file="Log.cs" company="">
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
    /// a DAL class implement ILog
    /// </summary>
    public partial class Log : ILog
    {
        /// <summary>
        /// insert a log item to database.
        /// </summary>
        /// <param name="log">an instance of LogItem</param>
        /// <param name="errmsg">out error message when exception happend</param>
        /// <returns>true: successed, false: failed.</returns>
        public bool Upload(LogItem log, string licenseKey)
        {
            var taskLog = new Data.TaskLog()
            {
                Id = log.Id,
                TaskId = log.TaskId,
                Message = log.Message,
                CreateTime = DateTime.Now,
                LicenseKey = licenseKey
            };

            using (Data.DFLinkSTEntities dfEnt = new Data.DFLinkSTEntities())
            {
                dfEnt.TaskLogs.AddObject(taskLog);
                dfEnt.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Get the logs list by a task id.
        /// </summary>
        /// <param name="taskId">task id</param>
        /// <param name="errmsg">out error message when exception happend</param>
        /// <returns>true: successed, false: failed.</returns>
        public IList<LogItem> GetLogs(int taskId, string licenseKey)
        {
            var logs = new List<LogItem>();

            var dfEnt = new Data.DFLinkSTEntities();
            var rows = from l1 in dfEnt.TaskLogs
                       where l1.TaskId == taskId & l1.LicenseKey == licenseKey
                       select l1;
            if (rows.Count() > 0)
            {
                foreach (var r in rows)
                {
                    LogItem log = new LogItem();
                    log.Id = r.Id;
                    log.TaskId = r.TaskId;
                    log.Message = r.Message;
                    log.CreateDate = r.CreateTime;
                    logs.Add(log);
                }
                return logs;
            }
            else
            {
                return null;
            }
        }
    }
}