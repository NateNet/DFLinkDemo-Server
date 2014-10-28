// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskItem.cs" company="Demandforce">
//   Copyright (c) Demandforce. All rights reserved.
// </copyright>
// <summary>
//   the model of task
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Demandforce.DFLinkServer.Model
{
    #region

    using System.Collections.Generic;

    #endregion

    /// <summary>
    ///     the model of task
    /// </summary>
    public class TaskItem
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the action.
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        ///     Gets or sets the business license.
        /// </summary>
        public string BusinessLicense { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the parameters of this task.
        /// </summary>
        public Dictionary<string, string> Parameters { get; set; }

        /// <summary>
        ///     Gets or sets the schedule of this task.
        /// </summary>
        public Dictionary<string, string> Schedule { get; set; }

        /// <summary>
        ///     Gets or sets the schedule type.
        /// </summary>
        public int ScheduleType { get; set; }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        public int Status { get; set; }

        #endregion
    }
}