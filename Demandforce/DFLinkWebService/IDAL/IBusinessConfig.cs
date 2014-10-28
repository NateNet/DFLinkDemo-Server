// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBusinessConfig.cs" company="Demandforce">
//   Copyright (c) Demandforce. All rights reserved.
// </copyright>
// <summary>
//   TODO: Update summary.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Demandforce.DFLinkServer.IDAL
{
    #region

    using System;

    #endregion

    /// <summary>
    ///     TODO: Update summary.
    /// </summary>
    public interface IBusinessConfig
    {
        #region Public Methods and Operators

        /// <summary>
        /// The insert function.
        /// </summary>
        /// <param name="taskId">
        /// Task id.
        /// </param>
        /// <param name="licenseKey">
        /// Business license key.
        /// </param>
        /// <param name="content">
        /// The content of business config.
        /// </param>
        /// <param name="createDate">
        /// The create date of this record
        /// </param>
        /// <returns>
        /// success or failed.
        /// </returns>
        bool Insert(int taskId, string licenseKey, string content, DateTime createDate);

        #endregion
    }
}