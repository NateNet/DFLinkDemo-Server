// -----------------------------------------------------------------------
// <copyright file="Task.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------
namespace Demandforce.DFLinkServer.BLL
{
    using System.Collections.Generic;
    using Demandforce.DFLinkServer.IDAL;
    using Demandforce.DFLinkServer.Model;

    /// <summary>
    /// The business component to manage tasks
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Get an instance of the Task DAL using DALFactory.
        /// </summary>
        private readonly ITask taskDAL = DALFactory.DataAccess.CreateTaskDAL();

        /// <summary>
        /// Get the tasks list by a business license key 
        /// </summary>
        /// <param name="licenseKey">business license key</param>
        /// <returns>the list of TaskItem</returns>
        public IList<TaskItem> GetTasks(string licenseKey)
        {
            IList<TaskItem> tasks = taskDAL.GetTasks(licenseKey);
            if (tasks != null)
                foreach (var t in tasks)
                {
                    t.Parameters = taskDAL.GetTaskParameters(t.Id, licenseKey);
                    t.Schedule = taskDAL.GetTaskSchedule(t.Id, licenseKey);
                }
            return tasks;
        }

        /// <summary>
        /// Update task status
        /// </summary>
        /// <param name="taskId">task id</param>
        /// <param name="newStatus">new status</param>
        /// <returns>true: succeeded, false: failed.</returns>
        public bool UpdateTaskStatus(int taskId, int newStatus, string licenseKey)
        {
            return taskDAL.UpdateTaskStatus(taskId, newStatus, licenseKey);
        }

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
                        foreach (var par in task.Parameters)
                        {
                            xml += "<" + par.Key + ">" + par.Value + "</" + par.Key + ">";
                        }
                        xml += "</Parameters>";
                    }
                    if (task.Schedule != null)
                    {
                        string schPars = string.Empty;
                        string schType = string.Empty;
                        foreach (var sch in task.Schedule)
                        {
                            if (sch.Key.ToUpper() == "TYPE")
                                schType = "<Type>" + sch.Value + "</Type>";
                            else
                                schPars += "<" + sch.Key + ">" + sch.Value + "</" + sch.Key + ">";
                        }
                        xml += "<Schedule>";
                        xml += schType;
                        if (schPars != "")
                            xml += "<Parameters>" + schPars + "</Parameters>";
                        xml += "</Schedule>";
                    }
                    xml += "</Task>";
                }
            }
            xml += "</Tasks>";
            return xml;
        }
    }
}