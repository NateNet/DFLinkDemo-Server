// -----------------------------------------------------------------------
// <copyright file="TaskItem.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Demandforce.DFLinkServer.Model
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;
    using System.Collections.Generic;

    /// <summary>
    /// the model of task
    /// </summary>
    public class TaskItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string BusinessLicense { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Action { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ScheduleType { get; set; }
        
        /// <summary>
        /// the schedule of this task.
        /// </summary>
        public Dictionary<string, string> Schedule { get; set; }
        
        /// <summary>
        /// the parameters of this task.
        /// </summary>
        public Dictionary<string, string> Parameters { get; set; }
    }
}