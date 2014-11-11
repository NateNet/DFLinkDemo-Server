// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Log.cs" company="Demandforce">
//   Copyright (c) Demandforce. All rights reserved.
// </copyright>
// <summary>
//   a DAL class implement ILog
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Demandforce.DFLinkServer.DAL
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Demandforce.DFLinkServer.DAL.Data;
    using Demandforce.DFLinkServer.IDAL;
    using Demandforce.DFLinkServer.Model;

    #endregion

    /// <summary>
    ///     a DAL class implement ILog
    /// </summary>
    public class Log : ILog
    {
        #region Public Methods and Operators

        /// <summary>
        /// Get the logs list by a task id.
        /// </summary>
        /// <param name="taskId">
        /// task id 
        /// </param>
        /// <param name="licenseKey">
        /// business license key 
        /// </param>
        /// <returns>
        /// true: succeeded, false: failed.
        /// </returns>
        public IList<LogItem> GetLogs(int taskId, string licenseKey)
        {
            var logs = new List<LogItem>();

            var dfEnt = new DFLinkSTEntities();
            var rows = from l1 in dfEnt.TaskLogs where l1.TaskId == taskId & l1.LicenseKey == licenseKey select l1;
            if (rows.Any())
            {
                logs.AddRange(
                    rows.Select(
                        r =>
                        new LogItem
                            {
                                Id = r.Id, TaskId = r.TaskId, Message = r.Message, CreateDate = r.CreateTime
                            }));
                return logs;
            }

            return null;
        }

        /// <summary>
        /// insert a log item to database.
        /// </summary>
        /// <param name="log">
        /// an instance of LogItem 
        /// </param>
        /// <param name="licenseKey">
        /// business license key 
        /// </param>
        /// <returns>
        /// true: succeeded, false: failed.
        /// </returns>
        public bool Upload(LogItem log, string licenseKey)
        {
            var taskLog = new TaskLog
                              {
                                  Id = log.Id, 
                                  TaskId = log.TaskId, 
                                  Message = log.Message, 
                                  CreateTime = DateTime.Now, 
                                  LicenseKey = licenseKey
                              };

            using (var dfEnt = new DFLinkSTEntities())
            {
                dfEnt.TaskLogs.AddObject(taskLog);
                dfEnt.SaveChanges();
                return true;
            }
        }

        #endregion
    }
}