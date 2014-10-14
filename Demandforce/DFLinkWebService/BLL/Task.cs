﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Task.cs" company="Demandforce">
//   TODO:
// </copyright>
// <summary>
//   The business component to manage tasks
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Demandforce.DFLinkServer.BLL
{
    #region

    using System.Collections.Generic;
    using System.Linq;

    using Demandforce.DFLinkServer.DALFactory;
    using Demandforce.DFLinkServer.IDAL;
    using Demandforce.DFLinkServer.Model;

    #endregion

    /// <summary>
    ///     The business component to manage tasks
    /// </summary>
    public class Task
    {
        #region Fields

        /// <summary>
        ///     Get an instance of the Task DAL using DALFactory.
        /// </summary>
        private readonly ITask taskDAL = DataAccess.CreateTaskDAL();

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Get the tasks list by a business license key
        /// </summary>
        /// <param name="licenseKey">
        /// business license key
        /// </param>
        /// <returns>
        /// the list of TaskItem
        /// </returns>
        public IList<TaskItem> GetTasks(string licenseKey)
        {
            var tasks = this.taskDAL.GetTasks(licenseKey);
            if (tasks != null)
            {
                foreach (var t in tasks)
                {
                    t.Parameters = this.taskDAL.GetTaskParameters(t.Id, licenseKey);
                    t.Schedule = this.taskDAL.GetTaskSchedule(t.Id, licenseKey);
                }
            }

            return tasks;
        }

        /// <summary>
        /// The to xml.
        /// </summary>
        /// <param name="tasks">
        /// The task list you want to convert to xml. 
        /// </param>
        /// <returns>
        /// The xml string 
        /// </returns>
        public string ToXml(IList<TaskItem> tasks)
        {
            string xml = "<Tasks>";
            if (tasks != null)
            {
                foreach (var task in tasks)
                {
                    xml += "<Task>";
                    xml += "<Action>" + task.Action + "</Action>";
                    xml += "<BusinessLicense>" + task.BusinessLicense + "</BusinessLicense>";
                    xml += "<Description>" + task.Description + "</Description>";
                    xml += "<Id>" + task.Id + "</Id>";
                    xml += "<Name>" + task.Name + "</Name>";
                    if (task.Parameters != null)
                    {
                        xml += "<Parameters>";
                        xml = task.Parameters.Aggregate(
                            xml, 
                            (current, par) => current + ("<" + par.Key + ">" + par.Value + "</" + par.Key + ">"));
                        xml += "</Parameters>";
                    }

                    if (task.Schedule != null)
                    {
                        string schPars = string.Empty;
                        string schType = string.Empty;
                        foreach (var sch in task.Schedule)
                        {
                            if (sch.Key.ToUpper() == "TYPE")
                            {
                                schType = "<Type>" + sch.Value + "</Type>";
                            }
                            else
                            {
                                schPars += "<" + sch.Key + ">" + sch.Value + "</" + sch.Key + ">";
                            }
                        }

                        xml += "<Schedule>";
                        xml += schType;
                        if (schPars != string.Empty)
                        {
                            xml += "<Parameters>" + schPars + "</Parameters>";
                        }

                        xml += "</Schedule>";
                    }

                    xml += "</Task>";
                }
            }

            xml += "</Tasks>";
            return xml;
        }

        /// <summary>
        /// Update task status
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
            return this.taskDAL.UpdateTaskStatus(taskId, newStatus, licenseKey);
        }

        #endregion
    }
}