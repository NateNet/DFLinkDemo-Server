// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogItem.cs" company="Demandforce">
//   Copyright (c) Demandforce. All rights reserved.
// </copyright>
// <summary>
//   the model of log item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Demandforce.DFLinkServer.Model
{
    #region

    using System;

    #endregion

    /// <summary>
    ///     the model of log item.
    /// </summary>
    public class LogItem
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets created date time.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///     Gets or sets the task id.
        /// </summary>
        public int TaskId { get; set; }

        #endregion
    }
}